using AutoMapper;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Controllers.ScriptInterpreterController
{
    [TestFixture]
    public class ScriptsControllerTests
    {
        private Mock<IScriptRepository> _scriptRepository;
        private Mock<ITranslationService> _translationService;
        private Mock<IScriptInterpreterUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;
        private Mock<IDateTime> _dateTime;

        [SetUp]
        public void SetUp()
        {
            _scriptRepository = new Mock<IScriptRepository>();
            _translationService = new Mock<ITranslationService>();
            _unitOfWork = new Mock<IScriptInterpreterUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _dateTime = new Mock<IDateTime>();
            _dateTime.Setup(dt => dt.Now).Returns(new DateTime(2000, 1, 1));

            _mapper.Setup(m => m.Map<List<Script>, List<ScriptResource>>(It.IsAny<List<Script>>()))
                .Returns(new List<ScriptResource> { new ScriptResource(), new ScriptResource() });
        }

        [Test]
        public void GetScriptsTest_Success()
        {
            IEnumerable<Script> scripts = new List<Script> { new Script(), new Script() };
            _scriptRepository.Setup(sr => sr.GetAllScriptsWithTagsAsync())
                .Returns(Task.FromResult(scripts));

            var scriptsController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object, 
                _translationService.Object, _unitOfWork.Object);

            var result = scriptsController.GetScripts().Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That(((result as OkObjectResult).Value as List<ScriptResource>).Count, Is.EqualTo(2));
        }

        [Test]
        public void GetScriptsTest_NoneScripts_Success()
        {
            IEnumerable<Script> scripts = new List<Script>();
            _scriptRepository.Setup(sr => sr.GetAllScriptsWithTagsAsync())
                .Returns(Task.FromResult(scripts));

            var scriptsController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptsController.GetScripts().Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void GetScriptTest_Success()
        {
            var script = new Script();
            var scriptResource = new ScriptResource();
            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(script));
            _mapper.Setup(m => m.Map<Script, ScriptResource>(script))
                .Returns(scriptResource);

            var scriptsController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptsController.GetScript(1).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.SameAs(scriptResource));
        }

        [Test]
        public void GetScriptTest_NoneScript_Success()
        {
            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(default(Script)));

            var scriptsController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptsController.GetScript(1).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void CreateScriptTest_Success()
        {
            var scriptResource = new ScriptResource();
            var script = new Script();
            _mapper.Setup(m => m.Map<ScriptResource, Script>(scriptResource))
                .Returns(script);
            _mapper.Setup(m => m.Map<Script, ScriptResource>(script))
                .Returns(scriptResource);

            _scriptRepository.Setup(tr => tr.AddAsync(script))
                .Returns(Task.FromResult(default(object)));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptController.CreateScript(scriptResource).Result;
            var resultScript = (result as OkObjectResult).Value as Script;

            _scriptRepository.Verify(sr => sr.AddAsync(script));
            _unitOfWork.Verify(sr => sr.CompleteAsync());
            _mapper.Verify(m => m.Map<ScriptResource, Script>(scriptResource));
            _mapper.Verify(m => m.Map<Script, ScriptResource>(script));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That(script.Version, Is.EqualTo("1"));
        }


        [Test]
        public void CreateScriptTest_InvalidModel_Success()
        {
            var scriptResource = new ScriptResource();

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);
            scriptController.ModelState.AddModelError("error", "model not valid");

            var result = scriptController.CreateScript(scriptResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void UpdateScriptTest_Success()
        {
            var scriptResource = new ScriptResource();
            var script = new Script { Version = "1" };
            _mapper.Setup(m => m.Map<ScriptResource, Script>(scriptResource, script))
                .Returns(script);
            _mapper.Setup(m => m.Map<Script, ScriptResource>(script))
                .Returns(scriptResource);

            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(script));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptController.UpdateScript(1, scriptResource).Result;
            var resultScript = (result as OkObjectResult).Value as Script;

            _scriptRepository.Verify(sr => sr.GetScriptWithTagsAsync(1), Times.Exactly(2));
            _unitOfWork.Verify(uow => uow.CompleteAsync());
            _mapper.Verify(m => m.Map<ScriptResource, Script>(scriptResource, script));
            _mapper.Verify(m => m.Map<Script, ScriptResource>(script));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That(script.Version, Is.EqualTo("1"));
            Assert.That(script.Modified, Is.GreaterThan(script.Added));
        }

        [Test]
        public void UpdateScriptTest_InvalidModel_Success()
        {
            var scriptResource = new ScriptResource();

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);
            scriptController.ModelState.AddModelError("error", "model not valid");

            var result = scriptController.UpdateScript(1, scriptResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void UpdateScriptTest_NoneScript_Success()
        {
            var scriptResource = new ScriptResource();

            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(default(Script)));

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptController.UpdateScript(1, scriptResource).Result;

            _scriptRepository.Verify(sr => sr.GetScriptWithTagsAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void DeleteScriptTest_Success()
        {
            var script = new Script();
            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(script));

            _scriptRepository.Setup(sr => sr.Remove(script));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptController.DeleteScript(1).Result;

            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _scriptRepository.Verify(sr => sr.Remove(script));
            _unitOfWork.Verify(uow => uow.CompleteAsync());           
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.EqualTo(1));
        }

        [Test]
        public void DeleteScriptTest_NoneScript_Success()
        {
            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(default(Script)));

            var scriptController = new ScriptsController(
                _mapper.Object, _dateTime.Object, _scriptRepository.Object,
                _translationService.Object, _unitOfWork.Object);

            var result = scriptController.DeleteScript(1).Result;

            _scriptRepository.Verify(sr => sr.GetAsync(1));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }
    }
}
