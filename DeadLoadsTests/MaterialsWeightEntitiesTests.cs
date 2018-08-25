using NUnit.Framework;

namespace DeadLoads.Tests
{
    [TestFixture()]
    public class MaterialsWeightEntitiesTests
    {
        [Test()]
        public void MaterialsWeightEntitiesTest_CheckConnection_Success()
        {
            var materialsWeightEntities = new MaterialsWeightEntities();
            Assert.IsNotNull(materialsWeightEntities.Database.Connection, "There should be connection to the database");
            Assert.IsNotNull(materialsWeightEntities.Categories, "There should be categories in the database");
            Assert.IsNotNull(materialsWeightEntities.Subcategories, "There should be subcategories in the database");
            Assert.IsNotNull(materialsWeightEntities.Materials, "There should be materials in the database");
        }

        //[Test()]
        //public void MaterialsWeightEntitiesTest_AddNewCategory_Success()
        //{
        //    var materialsWeightEntities = new MaterialsWeightEntities();
        //    var category = new Category() {ID= 13, Symbol = "Y", GroupName = "TEST" };
        //    try 
        //    {
        //        materialsWeightEntities.Categories.Add(category);
        //        materialsWeightEntities.SaveChanges();
        //        Assert.IsTrue(materialsWeightEntities.Categories.Contains(category), "There should be newly added category in the database");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        materialsWeightEntities.Categories.Remove(category);
        //        materialsWeightEntities.SaveChanges();
        //    }
        //}
    }
}