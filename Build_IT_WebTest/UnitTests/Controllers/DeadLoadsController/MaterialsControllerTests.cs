using AutoMapper;
using Build_IT_Application.DeadLoads.Materials.Queries;
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
    public class MaterialsControllerTests
    {
        [Test]
        public void GetAllMaterialsTest_Success()
        {
            var meterials = new List<Material> { new Material(), new Material() };

            var materialRepository = new Mock<IMaterialRepository>();
            materialRepository.Setup(mr => mr.GetAllMaterialsForSubcategoryAsync(1, CancellationToken.None))
                .Returns(Task.FromResult(meterials));

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<Material>, List<MaterialResource>>(It.IsAny<List<Material>>()))
                .Returns(new List<MaterialResource> { new MaterialResource(), new MaterialResource() });

            var materialsController = new MaterialsController();

            var materialsResult = materialsController.GetAllMaterials(1).Result;

            materialRepository.Verify(mr => mr.GetAllMaterialsForSubcategoryAsync(1, CancellationToken.None));
            mapper.Verify(m => m.Map<List<Material>, List<MaterialResource>>(meterials));
            CollectionAssert.IsNotEmpty(materialsResult.Value);
        }
    }
}