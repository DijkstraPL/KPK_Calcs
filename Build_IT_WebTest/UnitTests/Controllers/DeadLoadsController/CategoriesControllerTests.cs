using AutoMapper;
using Build_IT_Application.DeadLoads.Categories.Queries;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_WebTests.UnitTests.Controllers.DeadLoadsController
{
    [TestFixture]
    public class CategoriesControllerTests
    {
        [Test]
        public void GetAllCategoriesTest_Success()
        {
            IEnumerable<Category> categories = new List<Category> { new Category(), new Category() };

            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(mr => mr.GetAllAsync(CancellationToken.None))
                .Returns(Task.FromResult(categories));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Category>, List<CategoryResource>>(It.IsAny<List<Category>>()))
                .Returns(new List<CategoryResource> { new CategoryResource(), new CategoryResource() });

            var categoriesController = new CategoriesController();

            var  categoriesResult = categoriesController.GetAllCategories().Result;

            categoryRepository.Verify(cr => cr.GetAllAsync(CancellationToken.None));
            mapper.Verify(m => m.Map<List<Category>, List<CategoryResource>>(It.IsAny<List<Category>>()));
            CollectionAssert.IsNotEmpty(categoriesResult.Value);
            Assert.That(categoriesResult.Value.Count(), Is.EqualTo(2));
        }
    }
}