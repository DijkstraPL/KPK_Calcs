using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Services
{
    [TestFixture]
    public class TranslationServiceTests
    {
        [Test]
        public void SetScriptTranslationTest_Success()
        {
            var translationRepository = new Mock<ITranslationRepository>();
            translationRepository.Setup(sr => sr.GetScriptTranslation(1, Language.Polish))
                .Returns(Task.FromResult(new ScriptTranslation()
                {
                    Name= "new name",
                    Description = null,
                    Notes = "note"
                }));

            var translationService = new TranslationService(translationRepository.Object);

            var scriptResource = new ScriptResource()
            {
                Id = 1,
                Name = "a",
                Description = "b",
                Notes = "c"
            };

            Task.FromResult(translationService.SetScriptTranslation("pl", scriptResource));

            Assert.That(scriptResource.Name, Is.EqualTo("new name"));
            Assert.That(scriptResource.Description, Is.EqualTo("b"));
            Assert.That(scriptResource.Notes, Is.EqualTo("note"));
        }
    }
}
