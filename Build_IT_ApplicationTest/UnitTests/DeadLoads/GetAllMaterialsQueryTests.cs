using AutoMapper;
using Build_IT_Application.DeadLoads.Materials.Queries;
using Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_ApplicationTest.UnitTests.DeadLoads
{
    [TestFixture]
    public class GetAllMaterialsQueryTests
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

            var getAllMaterialsQuery = new GetAllMaterialsQuery.Handler(materialRepository.Object, mapper.Object);

            var materialsResult = getAllMaterialsQuery.Handle(
                new GetAllMaterialsQuery { SubcategoryId = 1 },
                CancellationToken.None).Result;

            materialRepository.Verify(mr => mr.GetAllMaterialsForSubcategoryAsync(1, CancellationToken.None));
            mapper.Verify(m => m.Map<List<Material>, List<MaterialResource>>(meterials));
            CollectionAssert.IsNotEmpty(materialsResult);
        }
    }
}