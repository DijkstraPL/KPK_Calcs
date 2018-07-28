using KPK_CalcSite.Models.DeadLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPK_CalcSite.ViewModels
{
    public class DeadLoadsViewModel
    {
        public MaterialList MaterialList { get; set; }
        public SubcategoryList SubcategoryList { get; set; }
        public CategoryList CategoryList { get; set; }

        public DeadLoadsViewModel()
        {
            CategoryList = new CategoryList();
            SubcategoryList = new SubcategoryList();
            MaterialList = new MaterialList();
        }

        public DeadLoads.Subcategory SelectedSubcategory { get; set; }
        public DeadLoads.Category SelectedCategory { get; set; }
    }
}