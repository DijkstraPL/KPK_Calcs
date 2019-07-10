using AutoMapper;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Controllers.ScriptInterpreterController
{
    [TestFixture]
    public class ParametersControllerTests
    {
        private Mock<IScriptRepository> _scriptRepository;
        private Mock<IParameterRepository> _parameterRepository;
        private Mock<ITranslationService> _translationService;
        private Mock<IScriptInterpreterUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _scriptRepository = new Mock<IScriptRepository>();
            _parameterRepository = new Mock<IParameterRepository>();
            _translationService = new Mock<ITranslationService>();
            _unitOfWork = new Mock<IScriptInterpreterUnitOfWork>();
            _mapper = new Mock<IMapper>();

            _mapper.Setup(m => m.Map<List<Parameter>, List<ParameterResource>>(It.IsAny<List<Parameter>>()))
                .Returns(new List<ParameterResource> { new ParameterResource(), new ParameterResource() });
        }

        [Test]
        public void GetParametersTest_Success()
        {
            IEnumerable<Parameter> parameters = new List<Parameter> { new Parameter(), new Parameter() };
            _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
                .Returns(Task.FromResult(parameters));
            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(new Script { DefaultLanguage = Language.English }));

            var parametersController = new ParametersController( 
                _scriptRepository.Object, _parameterRepository.Object, 
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.GetAllParameters(1).Result;

            _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CreateParameterTest_Success()
        {
            var parameterResource = new ParameterResource();
            var parameter = new Parameter();
            _mapper.Setup(m => m.Map<ParameterResource, Parameter>(parameterResource))
                .Returns(parameter);
            _mapper.Setup(m => m.Map<Parameter, ParameterResource>(parameter))
                .Returns(parameterResource);

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.Run(() => new Script()));
            _parameterRepository.Setup(pr => pr.AddAsync(parameter))
                .Returns(Task.FromResult(default(object)));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.CreateParameter(1, parameterResource).Result;
            var resultParameter = (result as OkObjectResult).Value as ParameterResource;

            _parameterRepository.Verify(pr => pr.AddAsync(parameter));
            _unitOfWork.Verify(sr => sr.CompleteAsync());
            _mapper.Verify(m => m.Map<ParameterResource, Parameter>(parameterResource));
            _mapper.Verify(m => m.Map<Parameter, ParameterResource>(parameter));
            Assert.That(resultParameter, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
        }
        
        [Test]
        public void CreateParameterTest_InvalidModel_Success()
        {
            var parameterResource = new ParameterResource();

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);
            parametersController.ModelState.AddModelError("error", "model not valid");

            var result = parametersController.CreateParameter(1, parameterResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void CreateParameterTest_NoScript_Success()
        {
            var parameterResource = new ParameterResource();

            _scriptRepository.Setup(sr => sr.GetAsync(1)).Returns(Task.Run(() => default(Script)));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.CreateParameter(1, parameterResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void UpdateParameterTest_Success()
        {
            var script = new Script();
            var parameterResource = new ParameterResource();
            var parameter = new Parameter { Name = "a" };
            _mapper.Setup(m => m.Map<ParameterResource, Parameter>(parameterResource, parameter))
                .Returns(parameter);
            _mapper.Setup(m => m.Map<Parameter, ParameterResource>(parameter))
                .Returns(parameterResource);

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(script));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(parameter));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.UpdateParameter(1, 2, parameterResource).Result;
            var resultParameter = (result as OkObjectResult).Value as Parameter;

            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(2), Times.Exactly(2));
            _unitOfWork.Verify(uow => uow.CompleteAsync());
            _mapper.Verify(m => m.Map<ParameterResource, Parameter>(parameterResource, parameter));
            _mapper.Verify(m => m.Map<Parameter, ParameterResource>(parameter));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
        }

        [Test]
        public void UpdateParameterTest_InvalidModel_Success()
        {
            var parameterResource = new ParameterResource();

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);
            parametersController.ModelState.AddModelError("error", "model not valid");

            var result = parametersController.UpdateParameter(1, 2, parameterResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void UpdateParameterTest_NoneScript_Success()
        {
            var parameterResource = new ParameterResource();
            var parameter = new Parameter { Name = "a" };

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(default(Script)));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(parameter));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.UpdateParameter(1, 2, parameterResource).Result;

            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(2));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void UpdateParameterTest_NoneParameter_Success()
        {
            var parameterResource = new ParameterResource();
            var script = new Script();

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(script));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(default(Parameter)));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.UpdateParameter(1, 2, parameterResource).Result;

            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(2));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void DeleteParameterTest_Success()
        {
            var parameter = new Parameter();
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(1))
                .Returns(Task.FromResult(parameter));

            _parameterRepository.Setup(sr => sr.Remove(parameter));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.DeleteParameter(1).Result;

            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(1));
            _parameterRepository.Verify(pr => pr.Remove(parameter));
            _unitOfWork.Verify(uow => uow.CompleteAsync());           
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.EqualTo(1));
        }

        [Test]
        public void DeleteScriptTest_NoneScript_Success()
        {
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(1))
                .Returns(Task.FromResult(default(Parameter)));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.DeleteParameter(1).Result;

            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void CopyParametersToTest_Success()
        {
            var parameter1 = new Parameter();
            var parameter2 = new Parameter();
            IEnumerable<Parameter> parameters = new List<Parameter> { parameter1, parameter2 };
            var inputParameters = parameters.ToList();
            List<ParameterResource> parameterResources = new List<ParameterResource> { new ParameterResource(), new ParameterResource() };
            var script = new Script();

            _scriptRepository.Setup(sr => sr.GetAsync(2))
                .Returns(Task.FromResult(script));
            _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
                .Returns(Task.FromResult(parameters));
            _parameterRepository.Setup(pr => pr.AddAsync(parameter1));
            _parameterRepository.Setup(pr => pr.AddAsync(parameter2));

            _mapper.Setup(m => m.Map<List<ParameterResource>, List<Parameter>>(parameterResources))
                .Returns(inputParameters);
            _mapper.Setup(m => m.Map<List<Parameter>, List<ParameterResource>>(inputParameters))
                .Returns(parameterResources);

            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.CopyParametersTo(1, 2).Result;

            _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
            _scriptRepository.Verify(sr => sr.GetAsync(2));
            _unitOfWork.Verify(uow => uow.CompleteAsync());
            Assert.That(parameter1.Script, Is.SameAs(script));
            Assert.That(parameter2.Script, Is.SameAs(script));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.EqualTo(2));
        }

        [Test]
        public void CopyParametersToTest_NoScript_Success()
        {
            var parameter1 = new Parameter();
            var parameter2 = new Parameter();
            IEnumerable<Parameter> parameters = new List<Parameter> { parameter1, parameter2 };
            var inputParameters = parameters.ToList();
            List<ParameterResource> parameterResources = new List<ParameterResource> { new ParameterResource(), new ParameterResource() };
            var script = new Script();

            _scriptRepository.Setup(sr => sr.GetAsync(2))
                .Returns(Task.FromResult(default(Script)));
            _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
                .Returns(Task.FromResult(parameters));

            _mapper.Setup(m => m.Map<List<ParameterResource>, List<Parameter>>(parameterResources))
                .Returns(inputParameters);
            _mapper.Setup(m => m.Map<List<Parameter>, List<ParameterResource>>(inputParameters))
                .Returns(parameterResources);

            var parametersController = new ParametersController(
                _scriptRepository.Object, _parameterRepository.Object,
                _translationService.Object, _unitOfWork.Object, _mapper.Object);

            var result = parametersController.CopyParametersTo(1, 2).Result;

            _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }
    }
}
