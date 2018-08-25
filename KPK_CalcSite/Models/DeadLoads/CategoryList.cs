using DeadLoads;
using System.Collections.Generic;

namespace KPK_CalcSite.Models.DeadLoads
{
    public class CategoryList
    {
        public IList<Category> Categories { get; set; }

        public CategoryList()
        {
            Categories = new List<Category>();
            MaterialsWeightEntities materialsWeightEntities = new MaterialsWeightEntities();
            foreach (var category in materialsWeightEntities.Categories)
            {
                Categories.Add(category);
            }
        }
    }
}