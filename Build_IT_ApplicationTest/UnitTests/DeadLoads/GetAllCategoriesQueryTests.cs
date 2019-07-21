using AutoMapper;
using Build_IT_Application.DeadLoads.Categories.Queries;
using Build_IT_Application.DeadLoads.Categories.Queries.GetAllCategories;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_ApplicationTest.UnitTests.DeadLoads
{
    [TestFixture]
    public class GetAllCategoriesQueryTests
    {
        [Test]
        public void GetAllCategoriesTest_Success()
        {
            IEnumerable<Category> categories = new List<Category> { new Category(), new Category() };
            var cancellationToken = CancellationToken.None;

            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(mr => mr.GetAllAsync(cancellationToken))
                .Returns(Task.FromResult(categories));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(It.IsAny<IEnumerable<Category>>()))
                .Returns(new List<CategoryResource> { new CategoryResource(), new CategoryResource() });

            var getAllCategoriesQuery =new  GetAllCategoriesQuery.Handler(categoryRepository.Object, mapper.Object);

            var categoriesResult = getAllCategoriesQuery.Handle(new GetAllCategoriesQuery(), cancellationToken).Result;

            categoryRepository.Verify(cr => cr.GetAllAsync(cancellationToken));
            mapper.Verify(m => m.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(It.IsAny<IEnumerable<Category>>()));
            CollectionAssert.IsNotEmpty(categoriesResult);
            Assert.That(categoriesResult.Count(), Is.EqualTo(2));
        }
    }
}