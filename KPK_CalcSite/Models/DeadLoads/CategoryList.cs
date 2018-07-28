using DeadLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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