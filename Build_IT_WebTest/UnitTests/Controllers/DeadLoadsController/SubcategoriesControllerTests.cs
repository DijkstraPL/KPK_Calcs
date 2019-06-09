using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
            subcategoryRepository.Setup(mr => mr.GetAllSubcategoriesForCategoryAsync(1))
                .Returns(Task.FromResult(subcategories));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Subcategory>, List<SubcategoryResource>>(It.IsAny<List<Subcategory>>()))
                .Returns(new List<SubcategoryResource> { new SubcategoryResource(), new SubcategoryResource() });

            var subcategoriesController = new SubcategoriesController(subcategoryRepository.Object, mapper.Object);

            var subcategoriesResult = subcategoriesController.GetAllSubcategories(1).Result;

            subcategoryRepository.Verify(sr => sr.GetAllSubcategoriesForCategoryAsync(1));
            mapper.Verify(m => m.Map<List<Subcategory>, List<SubcategoryResource>>(subcategories));
            CollectionAssert.IsNotEmpty(subcategoriesResult);
        }
    }
}