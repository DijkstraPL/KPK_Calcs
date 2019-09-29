using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.DeleteParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.UpdateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Controllers.ScriptInterpreterController
{
    [TestFixture]
    public class ParametersQueriesAndCommandsTests
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

            _mapper.Setup(m => m.Map<IEnumerable<Parameter>, IEnumerable<ParameterResource>>(It.IsAny<IEnumerable<Parameter>>()))
                .Returns(new List<ParameterResource> { new ParameterResource(), new ParameterResource() });
        }

        [Test]
        public void GetParametersTest_Success()
        {
            IEnumerable<Parameter> parameters = new List<Parameter> { new Parameter(), new Parameter() };
            _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
                .Returns(Task.FromResult(parameters));
            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(
                Task.FromResult(new Script { DefaultLanguage = Language.English })));

            var getAllParametersForScriptQuery = new GetAllParametersForScriptQuery.Handler(
               _parameterRepository.Object, _scriptRepository.Object,
                _translationService.Object, _mapper.Object);

            var result = getAllParametersForScriptQuery.Handle(
                new GetAllParametersForScriptQuery { ScriptId = 1 },
                CancellationToken.None).Result;

            _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CreateParameterTest_Success()
        {
            var parameterResource = new ParameterResource();
            var parameter = new Parameter();

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(Task.Run(() => new Script())));
            _parameterRepository.Setup(pr => pr.AddAsync(parameter))
                .Returns(Task.FromResult(default(object)));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var scriptMappingProfile = new Mock<IScriptMappingProfile>();

            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(dt => dt.Now).Returns(new System.DateTime());

            var createParameterCommand = new CreateParameterCommand.Handler(
                _scriptRepository.Object, _parameterRepository.Object,
                _unitOfWork.Object, scriptMappingProfile.Object, dateTime.Object);

            var cancellationToken = CancellationToken.None;
            var command = new CreateParameterCommand
            {
                ScriptId = 1,
                Name = "new",
                ValueOptions = new List<ValueOptionResource>()
            };
            var result = createParameterCommand.Handle( command, cancellationToken).Result;

            _parameterRepository.Verify(pr => pr.AddAsync(It.IsAny<Parameter>()));
            _unitOfWork.Verify(sr => sr.CompleteAsync(cancellationToken));
            scriptMappingProfile.Verify(smp => smp.UpdateValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            scriptMappingProfile.Verify(smp => smp.RemoveNotAddedValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            scriptMappingProfile.Verify(smp => smp.AddNewValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            dateTime.Verify(dt => dt.Now);
            Assert.That(result, Is.Not.Null);
        }

        // TODO: Add this.
        //[Test]
        //public void CreateParameterTest_InvalidModel_Success()
        //{
        //    var parameterResource = new ParameterResource();

        //    var parametersController = new ParametersController(
        //        _scriptRepository.Object, _parameterRepository.Object,
        //        _translationService.Object, _unitOfWork.Object, _mapper.Object);
        //    parametersController.ModelState.AddModelError("error", "model not valid");

        //    var result = parametersController.CreateParameter(1, parameterResource).Result;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        //}

        [Test]
        public void CreateParameterTest_NoScript_Success()
        {
            var parameterResource = new ParameterResource();

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(Task.Run(() => default(Script))));

            var scriptMappingProfile = new Mock<IScriptMappingProfile>();

            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(dt => dt.Now).Returns(new System.DateTime());

            var createParameterCommand = new CreateParameterCommand.Handler(
                _scriptRepository.Object, _parameterRepository.Object,
                _unitOfWork.Object, scriptMappingProfile.Object, dateTime.Object);

            var command = new CreateParameterCommand
            {
                ScriptId = 1,
                Name = "new",
                ValueOptions = new List<ValueOptionResource>()
            };
            Assert.ThrowsAsync<NotFoundException>(() => createParameterCommand.Handle(command, CancellationToken.None));
        }

        [Test]
        public void UpdateParameterTest_Success()
        {
            var script = new Script();
            var parameterResource = new ParameterResource();
            var parameter = new Parameter { Name = "a" };

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(Task.FromResult(script)));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(parameter));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var scriptMappingProfile = new Mock<IScriptMappingProfile>();

            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(dt => dt.Now).Returns(new System.DateTime());

            var updateParameterCommand = new UpdateParameterCommand.Handler(
                _scriptRepository.Object, _parameterRepository.Object,
                _unitOfWork.Object, scriptMappingProfile.Object, dateTime.Object);

            var cancellationToken = CancellationToken.None;
            var command = new UpdateParameterCommand
            {
                ScriptId = 1,
                Name = "new",
                ValueOptions = new List<ValueOptionResource>(),
                Id = 2
            };
            var result = updateParameterCommand.Handle(command, cancellationToken).Result;
            
            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _parameterRepository.Verify(pr => pr.GetParameterWithAllDependanciesAsync(2));
            _unitOfWork.Verify(uow => uow.CompleteAsync());
            scriptMappingProfile.Verify(smp => smp.UpdateValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            scriptMappingProfile.Verify(smp => smp.RemoveNotAddedValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            scriptMappingProfile.Verify(smp => smp.AddNewValueOptions(command.ValueOptions, It.IsAny<Parameter>()));
            dateTime.Verify(dt => dt.Now);
            Assert.That(result, Is.Not.Null);
        }

        //[Test]
        //public void UpdateParameterTest_InvalidModel_Success()
        //{
        //    var parameterResource = new ParameterResource();

        //    var parametersController = new ParametersController(
        //        _scriptRepository.Object, _parameterRepository.Object,
        //        _translationService.Object, _unitOfWork.Object, _mapper.Object);
        //    parametersController.ModelState.AddModelError("error", "model not valid");

        //    var result = parametersController.UpdateParameter(1, 2, parameterResource).Result;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        //}

        [Test]
        public void UpdateParameterTest_NoneScript_Success()
        {
            var parameterResource = new ParameterResource();
            var parameter = new Parameter { Name = "a" };

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(Task.FromResult(default(Script))));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(parameter));

            var scriptMappingProfile = new Mock<IScriptMappingProfile>();

            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(dt => dt.Now).Returns(new System.DateTime());

            var updateParameterCommand = new UpdateParameterCommand.Handler(
                _scriptRepository.Object, _parameterRepository.Object,
                _unitOfWork.Object, scriptMappingProfile.Object, dateTime.Object);

            var cancellationToken = CancellationToken.None;
            var command = new UpdateParameterCommand
            {
                ScriptId = 1,
                Name = "new",
                ValueOptions = new List<ValueOptionResource>(),
                Id = 2
            };

            Assert.ThrowsAsync<NotFoundException>(() => updateParameterCommand.Handle(command, cancellationToken));
        }

        [Test]
        public void UpdateParameterTest_NoneParameter_Success()
        {
            var parameterResource = new ParameterResource();
            var script = new Script();

            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(new ValueTask<Script>(Task.FromResult(script)));
            _parameterRepository.Setup(pr => pr.GetParameterWithAllDependanciesAsync(2))
                .Returns(Task.FromResult(default(Parameter)));

            var scriptMappingProfile = new Mock<IScriptMappingProfile>();

            var dateTime = new Mock<IDateTime>();
            dateTime.Setup(dt => dt.Now).Returns(new System.DateTime());

            var updateParameterCommand = new UpdateParameterCommand.Handler(
                _scriptRepository.Object, _parameterRepository.Object,
                _unitOfWork.Object, scriptMappingProfile.Object, dateTime.Object);

            var cancellationToken = CancellationToken.None;
            var command = new UpdateParameterCommand
            {
                ScriptId = 1,
                Name = "new",
                ValueOptions = new List<ValueOptionResource>(),
                Id = 2
            };

            Assert.ThrowsAsync<NotFoundException>(() => updateParameterCommand.Handle(command, cancellationToken));
        }

        [Test]
        public void DeleteParameterTest_Success()
        {
            var parameter = new Parameter();
            _parameterRepository.Setup(pr => pr.GetAsync(1))
                .Returns(new ValueTask<Parameter>(Task.FromResult(parameter)));

            _parameterRepository.Setup(sr => sr.Remove(parameter));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var cancellationToken = CancellationToken.None;
            var deleteParameterCommand = new DeleteParameterCommand.Handler(
                _parameterRepository.Object, _unitOfWork.Object);

            var result = deleteParameterCommand.Handle(
                new DeleteParameterCommand { Id = 1 },
                cancellationToken);
            
            _parameterRepository.Verify(pr => pr.GetAsync(1));
            _parameterRepository.Verify(pr => pr.Remove(parameter));
            _unitOfWork.Verify(uow => uow.CompleteAsync(cancellationToken));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void DeleteScriptTest_NoneScript_Success()
        {
            _parameterRepository.Setup(pr => pr.GetAsync(1))
                .Returns(new ValueTask<Parameter>(Task.FromResult(default(Parameter))));

            var cancellationToken = CancellationToken.None;
            var deleteParameterCommand = new DeleteParameterCommand.Handler(
                _parameterRepository.Object, _unitOfWork.Object);

            Assert.ThrowsAsync<NotFoundException>(() => deleteParameterCommand.Handle(
                new DeleteParameterCommand { Id = 1 },
                cancellationToken));
        }

        //[Test]
        //public void CopyParametersToTest_Success()
        //{
        //    var parameter1 = new Parameter();
        //    var parameter2 = new Parameter();
        //    IEnumerable<Parameter> parameters = new List<Parameter> { parameter1, parameter2 };
        //    var inputParameters = parameters.ToList();
        //    List<ParameterResource> parameterResources = new List<ParameterResource> { new ParameterResource(), new ParameterResource() };
        //    var script = new Script();

        //    _scriptRepository.Setup(sr => sr.GetAsync(2))
        //        .Returns(Task.FromResult(script));
        //    _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
        //        .Returns(Task.FromResult(parameters));
        //    _parameterRepository.Setup(pr => pr.AddAsync(parameter1));
        //    _parameterRepository.Setup(pr => pr.AddAsync(parameter2));

        //    _mapper.Setup(m => m.Map<List<ParameterResource>, List<Parameter>>(parameterResources))
        //        .Returns(inputParameters);
        //    _mapper.Setup(m => m.Map<List<Parameter>, List<ParameterResource>>(inputParameters))
        //        .Returns(parameterResources);

        //    _unitOfWork.Setup(uow => uow.CompleteAsync())
        //        .Returns(Task.FromResult(1));

        //    var parametersController = new ParametersController(
        //        _scriptRepository.Object, _parameterRepository.Object,
        //        _translationService.Object, _unitOfWork.Object, _mapper.Object);

        //    var result = parametersController.CopyParametersTo(1, 2).Result;

        //    _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
        //    _scriptRepository.Verify(sr => sr.GetAsync(2));
        //    _unitOfWork.Verify(uow => uow.CompleteAsync());
        //    Assert.That(parameter1.Script, Is.SameAs(script));
        //    Assert.That(parameter2.Script, Is.SameAs(script));
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
        //    Assert.That((result as OkObjectResult).Value, Is.EqualTo(2));
        //}

        //[Test]
        //public void CopyParametersToTest_NoScript_Success()
        //{
        //    var parameter1 = new Parameter();
        //    var parameter2 = new Parameter();
        //    IEnumerable<Parameter> parameters = new List<Parameter> { parameter1, parameter2 };
        //    var inputParameters = parameters.ToList();
        //    List<ParameterResource> parameterResources = new List<ParameterResource> { new ParameterResource(), new ParameterResource() };
        //    var script = new Script();

        //    _scriptRepository.Setup(sr => sr.GetAsync(2))
        //        .Returns(Task.FromResult(default(Script)));
        //    _parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
        //        .Returns(Task.FromResult(parameters));

        //    _mapper.Setup(m => m.Map<List<ParameterResource>, List<Parameter>>(parameterResources))
        //        .Returns(inputParameters);
        //    _mapper.Setup(m => m.Map<List<Parameter>, List<ParameterResource>>(inputParameters))
        //        .Returns(parameterResources);

        //    var parametersController = new ParametersController(
        //        _scriptRepository.Object, _parameterRepository.Object,
        //        _translationService.Object, _unitOfWork.Object, _mapper.Object);

        //    var result = parametersController.CopyParametersTo(1, 2).Result;

        //    _parameterRepository.Verify(pr => pr.GetAllParametersForScriptAsync(1));
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        //}
    }
}
