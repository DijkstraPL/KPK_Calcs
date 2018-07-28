using DeadLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPK_CalcSite.Models.DeadLoads
{
    public class SubcategoryList
    {
        public IList<Subcategory> Subcategories { get; set; }

        public SubcategoryList()
        {
            Subcategories = new List<Subcategory>();
            MaterialsWeightEntities materialsWeightEntities = new MaterialsWeightEntities();
            foreach (var subcategory in materialsWeightEntities.Subcategories)
            {
                Subcategories.Add(subcategory);
            }
        }
    }
}