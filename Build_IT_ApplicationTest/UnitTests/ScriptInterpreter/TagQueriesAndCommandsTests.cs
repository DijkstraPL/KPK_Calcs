using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Tags.Commands.CreateTag;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_Application.ScriptInterpreter.Tags.Queries.GetAllTags;
using Build_IT_Application.ScriptInterpreter.Tags.Queries.GetAllTagsForScript;
using Build_IT_Data.Entities.Scripts;
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
        }

        [Test]
        public void GetTagsTest_Success()
        {
            IEnumerable<Tag> tags = new List<Tag> { new Tag(), new Tag() };
            _tagRepository.Setup(tr => tr.GetAllAsync(CancellationToken.None))
                .Returns(Task.FromResult(tags));

            _mapper.Setup(m => m.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(It.IsAny<IEnumerable<Tag>>()))
                .Returns(new List<TagResource> { new TagResource(), new TagResource() });

            var getAllTagsQuery = new GetAllTagsQuery.Handler(
             _tagRepository.Object, _mapper.Object);

            var result = getAllTagsQuery.Handle(
                new GetAllTagsQuery(),
                CancellationToken.None).Result;

            _tagRepository.Verify(tr => tr.GetAllAsync(CancellationToken.None));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetTagsTest_NoneTags_Success()
        {
            IEnumerable<Tag> tags = new List<Tag>();
            _tagRepository.Setup(tr => tr.GetAllAsync(CancellationToken.None))
                .Returns(Task.FromResult(tags));

            _mapper.Setup(m => m.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(It.IsAny<IEnumerable<Tag>>()))
                .Returns(new List<TagResource>());

            var getAllTagsQuery = new GetAllTagsQuery.Handler(
             _tagRepository.Object, _mapper.Object);

            var result = getAllTagsQuery.Handle(
                new GetAllTagsQuery(),
                CancellationToken.None).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTagsForScriptTest_Success()
        {
            IEnumerable<Tag> tags = new List<Tag> { new Tag(), new Tag() };
            _tagRepository.Setup(tr => tr.GetTagsForScriptAsync(1))
                .Returns(Task.FromResult(tags));

            _mapper.Setup(m => m.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(It.IsAny<IEnumerable<Tag>>()))
                .Returns(new List<TagResource> { new TagResource(), new TagResource() });

            var getAllTagsForScriptQuery = new GetAllTagsForScriptQuery.Handler(
             _tagRepository.Object, _mapper.Object);

            var result = getAllTagsForScriptQuery.Handle(
                new GetAllTagsForScriptQuery { ScriptId = 1 },
                CancellationToken.None).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTagsForScriptTest_NoneTags_Success()
        {
            IEnumerable<Tag> tags = new List<Tag>();
            _tagRepository.Setup(tr => tr.GetTagsForScriptAsync(1))
                .Returns(Task.FromResult(tags));

            _mapper.Setup(m => m.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(It.IsAny<IEnumerable<Tag>>()))
                .Returns(new List<TagResource>());

            var getAllTagsForScriptQuery = new GetAllTagsForScriptQuery.Handler(
             _tagRepository.Object, _mapper.Object);

            var result = getAllTagsForScriptQuery.Handle(
                new GetAllTagsForScriptQuery { ScriptId = 1 },
                CancellationToken.None).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void CreateTagTest_Success()
        {
            var tagResource = new TagResource();
            var tag = new Tag();

            _tagRepository.Setup(tr => tr.AddAsync(tag))
                .Returns(Task.FromResult(default(object)));
            _unitOfWork.Setup(uow => uow.CompleteAsync())
                .Returns(Task.FromResult(1));

            var createTagCommand = new CreateTagCommand.Handler(
             _tagRepository.Object, _unitOfWork.Object);

            var result = createTagCommand.Handle(
                new CreateTagCommand(),
                CancellationToken.None).Result;

            _tagRepository.Verify(tr => tr.AddAsync(It.IsAny<Tag>()));
            _unitOfWork.Verify(tr => tr.CompleteAsync(CancellationToken.None));
            Assert.That(result, Is.Not.Null);
        }

        //[Test]
        //public void CreateTagTest_InvalidModelState_Success()
        //{
        //    var tagResource = new TagResource();

        //    var tagController = new TagController(_mapper.Object, _tagRepository.Object, _unitOfWork.Object);
        //    tagController.ModelState.AddModelError("error", "model not valid");

        //    var result = tagController.CreateTag(tagResource).Result;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));
        //}
    }
}
