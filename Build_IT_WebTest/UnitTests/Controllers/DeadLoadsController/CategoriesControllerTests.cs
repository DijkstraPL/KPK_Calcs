using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            categoryRepository.Setup(mr => mr.GetAllAsync())
                .Returns(Task.FromResult(categories));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Category>, List<CategoryResource>>(It.IsAny<List<Category>>()))
                .Returns(new List<CategoryResource> { new CategoryResource(), new CategoryResource() });

            var categoriesController = new CategoriesController(categoryRepository.Object, mapper.Object);

            var  categoriesResult = categoriesController.GetAllCategories().Result;

            categoryRepository.Verify(cr => cr.GetAllAsync());
            mapper.Verify(m => m.Map<List<Category>, List<CategoryResource>>(It.IsAny<List<Category>>()));
            CollectionAssert.IsNotEmpty(categoriesResult);
            Assert.That(categoriesResult.Count(), Is.EqualTo(2));
        }
    }
}