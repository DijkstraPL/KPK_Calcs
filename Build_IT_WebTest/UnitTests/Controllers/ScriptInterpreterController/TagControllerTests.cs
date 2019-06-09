using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_WebTest.UnitTests.Controllers.ScriptInterpreterController
{
    [TestFixture]
    public class TagControllerTests
    {
        private Mock<ITagRepository> _tagRepository;
        private Mock<IScriptInterpreterUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _tagRepository = new Mock<ITagRepository>();
            _unitOfWork = new Mock<IScriptInterpreterUnitOfWork>();
            _mapper = new Mock<IMapper>();

            _mapper.Setup(m => m.Map<List<Tag>, List<TagResource>>(It.IsAny<List<Tag>>()))
                .Returns(new List<TagResource> { new TagResource(), new TagResource() });
        }

        [Test]
        public void GetTagsTest_Success()
        {
            IEnumerable<Tag> tags = new List<Tag> { new Tag(), new Tag() };
            _tagRepository.Setup(tr => tr.GetAllAsync())
                .Returns(Task.FromResult(tags));

            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);

            var result = tagController.GetTags().Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That(((result as OkObjectResult).Value as List<TagResource>).Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTagsTest_NoneTags_Success()
        {
            IEnumerable<Tag> tags = new List<Tag>();
            _tagRepository.Setup(tr => tr.GetAllAsync())
                .Returns(Task.FromResult(tags));

            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);

            var result = tagController.GetTags().Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void GetTagsForScriptTest_Success()
        {
            IEnumerable<Tag> tags = new List<Tag> { new Tag(), new Tag() };
            _tagRepository.Setup(tr => tr.GetTagsForScript(1))
                .Returns(Task.FromResult(tags));

            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);

            var result = tagController.GetTags(1).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
            Assert.That(((result as OkObjectResult).Value as List<TagResource>).Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTagsForScriptTest_NoneTags_Success()
        {
            IEnumerable<Tag> tags = new List<Tag>();
            _tagRepository.Setup(tr => tr.GetTagsForScript(1))
                .Returns(Task.FromResult(tags));

            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);

            var result = tagController.GetTags(1).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(NotFoundResult)));
        }

        [Test]
        public void CreateTagTest_Success()
        {
            var tagResource = new TagResource();
            var tag = new Tag();
            _mapper.Setup(m => m.Map<TagResource, Tag>(tagResource))
                .Returns(tag);

            _tagRepository.Setup(tr => tr.AddAsync(tag));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);

            var result = tagController.CreateTag(tagResource).Result;

            _tagRepository.Verify(tr => tr.AddAsync(tag));
            _unitOfWork.Verify(tr => tr.CompleteAsync());
            _mapper.Verify(m => m.Map<TagResource, Tag>(tagResource));
            _mapper.Verify(m => m.Map<Tag, TagResource>(tag));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(OkObjectResult)));
        }

        [Test]
        public void CreateTagTest_InvalidModelState_Success()
        {
            var tagResource = new TagResource();
         
            var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);
            tagController.ModelState.AddModelError("error", "model not valid");

            var result = tagController.CreateTag(tagResource).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        }
    }
}
