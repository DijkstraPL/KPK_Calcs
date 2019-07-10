using AutoMapper;
using Build_IT_Application.DeadLoads.Subcategories.Queries;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_WebTests.UnitTests.Controllers.DeadLoadsController
{
    [TestFixture]
    public class SubcategoriesControllerTests
    {
        [Test]
        public void GetAllSubcategoriesTest_Success()
        {
            var subcategories = new List<Subcategory> { new Subcategory(), new Subcategory() };

            var subcategoryRepository = new Mock<ISubcategoryRepository>();
            subcategoryRepository.Setup(mr => mr.GetAllSubcategoriesForCategoryAsync(1, CancellationToken.None))
                .Returns(Task.FromResult(subcategories));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Subcategory>, List<SubcategoryResource>>(It.IsAny<List<Subcategory>>()))
                .Returns(new List<SubcategoryResource> { new SubcategoryResource(), new SubcategoryResource() });

            var subcategoriesController = new SubcategoriesController();

            var subcategoriesResult = subcategoriesController.GetAllSubcategories(1).Result;

            subcategoryRepository.Verify(sr => sr.GetAllSubcategoriesForCategoryAsync(1, CancellationToken.None));
            mapper.Verify(m => m.Map<List<Subcategory>, List<SubcategoryResource>>(subcategories));
            CollectionAssert.IsNotEmpty(subcategoriesResult.Value);
        }
    }
}