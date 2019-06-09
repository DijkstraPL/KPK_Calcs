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
    public class MaterialsControllerTests
    {
        [Test]
        public void GetAllMaterialsTest_Success()
        {
            var meterials = new List<Material> { new Material(), new Material() };

            var materialRepository = new Mock<IMaterialRepository>();
            materialRepository.Setup(mr => mr.GetAllMaterialsForSubcategoryAsync(1))
                .Returns(Task.FromResult(meterials));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Material>, List<MaterialResource>>(It.IsAny<List<Material>>()))
                .Returns(new List<MaterialResource> { new MaterialResource(), new MaterialResource() });

            var materialsController = new MaterialsController(materialRepository.Object, mapper.Object);

            var materialsResult = materialsController.GetAllMaterials(1).Result;

            materialRepository.Verify(mr => mr.GetAllMaterialsForSubcategoryAsync(1));
            mapper.Verify(m => m.Map<List<Material>, List<MaterialResource>>(meterials));
            CollectionAssert.IsNotEmpty(materialsResult);
        }
    }
}