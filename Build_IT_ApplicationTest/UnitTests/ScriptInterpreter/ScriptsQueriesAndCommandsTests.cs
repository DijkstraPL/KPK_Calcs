using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.UpdateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetScript;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Controllers.ScriptInterpreterController
{
    [TestFixture]
    public class ScriptsQueriesAndCommandsTests
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
        }

        [Test]
        public void GetScriptsTest_Success()
        {
            IEnumerable<Script> scripts = new List<Script> { new Script(), new Script() };
            _scriptRepository.Setup(sr => sr.GetAllScriptsWithTagsAsync())
                .Returns(Task.FromResult(scripts));

            _mapper.Setup(m => m.Map<IEnumerable<Script>, IEnumerable<ScriptResource>>(It.IsAny<IEnumerable<Script>>()))
                .Returns(new List<ScriptResource> { new ScriptResource(), new ScriptResource() });

            var getAllScripts = new GetAllScriptsQuery.Handler(
                _scriptRepository.Object, _translationService.Object, _mapper.Object);

           var result = getAllScripts.Handle(
               new GetAllScriptsQuery { Language = TranslationService.DefaultLanguageCode  },
               CancellationToken.None).Result;

            _scriptRepository.Verify(sr => sr.GetAllScriptsWithTagsAsync());
            _mapper.Verify(m => m.Map<IEnumerable<Script>, IEnumerable<ScriptResource>>(scripts));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetScriptsTest_NoneScripts_Success()
        {
            IEnumerable<Script> scripts = new List<Script>();
            _scriptRepository.Setup(sr => sr.GetAllScriptsWithTagsAsync())
                .Returns(Task.FromResult(scripts));

            _mapper.Setup(m => m.Map<IEnumerable<Script>, IEnumerable<ScriptResource>>(It.IsAny<IEnumerable<Script>>()))
                .Returns(new List<ScriptResource> ());

            var getAllScriptsQuery = new GetAllScriptsQuery.Handler(
             _scriptRepository.Object, _translationService.Object, _mapper.Object);

            var result = getAllScriptsQuery.Handle(
                new GetAllScriptsQuery { Language = TranslationService.DefaultLanguageCode },
                CancellationToken.None).Result;

            _scriptRepository.Verify(sr => sr.GetAllScriptsWithTagsAsync());
            _mapper.Verify(m => m.Map<IEnumerable<Script>, IEnumerable<ScriptResource>>(scripts));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
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

            var getScriptQuery = new GetScriptQuery.Handler(
                _scriptRepository.Object, _translationService.Object, _mapper.Object);

            var result = getScriptQuery.Handle(
                new GetScriptQuery { Id = 1, Language = TranslationService.DefaultLanguageCode },
                CancellationToken.None).Result;

            _scriptRepository.Verify(sr => sr.GetScriptWithTagsAsync(1));
            _mapper.Verify(m => m.Map<Script, ScriptResource>(script));
            _translationService.Verify(ts => ts.SetScriptTranslation(TranslationService.DefaultLanguageCode, scriptResource));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(scriptResource));
        }

        [Test]
        public void GetScriptTest_NoneScript_Success()
        {
            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(default(Script)));

            var getScriptQuery = new GetScriptQuery.Handler(
                _scriptRepository.Object, _translationService.Object, _mapper.Object);
            
            Assert.ThrowsAsync<NotFoundException>(() => getScriptQuery.Handle(
                new GetScriptQuery { Id =1 , Language =TranslationService.DefaultLanguageCode },
                CancellationToken.None));
        }

        [Test]
        public void CreateScriptTest_Success()
        {
            var script = new Script();

            var mediator = new Mock<IMediator>();

            _scriptRepository.Setup(tr => tr.AddAsync(script))
                .Returns(Task.FromResult(default(object)));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var cancellationToken = CancellationToken.None;

            var createScriptCommand = new CreateScriptCommand.Handler(
                _dateTime.Object,  _scriptRepository.Object, _unitOfWork.Object, mediator.Object);

            var result = createScriptCommand.Handle(
                new CreateScriptCommand { Name = "name", Tags =new List<TagResource>() },
                cancellationToken).Result;
            
            _scriptRepository.Verify(sr => sr.AddAsync(It.IsAny<Script>()));
            _unitOfWork.Verify(sr => sr.CompleteAsync(cancellationToken));
            Assert.That(result, Is.Not.Null);
        }


        //[Test]
        //public void CreateScriptTest_InvalidModel_Success()
        //{
        //    var scriptResource = new ScriptResource();

        //    var scriptController = new ScriptsController(
        //        _mapper.Object, _dateTime.Object, _scriptRepository.Object,
        //        _translationService.Object, _unitOfWork.Object);
        //    scriptController.ModelState.AddModelError("error", "model not valid");

        //    var result = scriptController.CreateScript(scriptResource).Result;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        //}

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
            
            var updateScriptCommand = new UpdateScriptCommand.Handler(
              _dateTime.Object, _scriptRepository.Object, _unitOfWork.Object);

            var result = updateScriptCommand.Handle(
                new UpdateScriptCommand { Id = 1, Name = "name", Tags = new List<TagResource>() },
                CancellationToken.None).Result;
            
            _scriptRepository.Verify(sr => sr.GetScriptWithTagsAsync(1));
            _unitOfWork.Verify(uow => uow.CompleteAsync());
        }

        //[Test]
        //public void UpdateScriptTest_InvalidModel_Success()
        //{
        //    var scriptResource = new ScriptResource();

        //    var scriptController = new ScriptsController(
        //        _mapper.Object, _dateTime.Object, _scriptRepository.Object,
        //        _translationService.Object, _unitOfWork.Object);
        //    scriptController.ModelState.AddModelError("error", "model not valid");

        //    var result = scriptController.UpdateScript(1, scriptResource).Result;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        //}

        [Test]
        public void UpdateScriptTest_NoneScript_Success()
        {
            var scriptResource = new ScriptResource();

            _scriptRepository.Setup(sr => sr.GetScriptWithTagsAsync(1))
                .Returns(Task.FromResult(default(Script)));

            var updateScriptCommand = new UpdateScriptCommand.Handler(
              _dateTime.Object, _scriptRepository.Object, _unitOfWork.Object);

            Assert.ThrowsAsync<NotFoundException>(() => updateScriptCommand.Handle(
                new UpdateScriptCommand { Id = 1, Name = "name", Tags = new List<TagResource>() },
                CancellationToken.None));            
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

            var deleteScriptCommand = new DeleteScriptCommand.Handler(
                _scriptRepository.Object, _unitOfWork.Object);

            var result = deleteScriptCommand.Handle(
                new DeleteScriptCommand { Id = 1 },
                CancellationToken.None).Result;
            
            _scriptRepository.Verify(sr => sr.GetAsync(1));
            _scriptRepository.Verify(sr => sr.Remove(script));
            _unitOfWork.Verify(uow => uow.CompleteAsync(CancellationToken.None));
        }

        [Test]
        public void DeleteScriptTest_NoneScript_Success()
        {
            _scriptRepository.Setup(sr => sr.GetAsync(1))
                .Returns(Task.FromResult(default(Script)));
            
            var deleteScriptCommand = new DeleteScriptCommand.Handler(
                _scriptRepository.Object, _unitOfWork.Object);

            Assert.ThrowsAsync<NotFoundException>(() => deleteScriptCommand.Handle(
                new DeleteScriptCommand { Id = 1 },
                CancellationToken.None));
        }
    }
}
