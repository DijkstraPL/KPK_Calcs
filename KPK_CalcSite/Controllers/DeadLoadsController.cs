using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPK_CalcSite.Models.DeadLoads;
using KPK_CalcSite.ViewModels;

namespace KPK_CalcSite.Controllers
{
    public class DeadLoadsController : Controller
    {
        List<DeadLoads.Material> materials = new List<DeadLoads.Material>();
        DeadLoadsViewModel deadLoadsViewModel = new DeadLoadsViewModel();

        public ActionResult DeadLoadCalculator()
        {
            ViewBag.Title = "Dead load";
            ViewBag.Message = "Calculate all dead loads";

            return View(deadLoadsViewModel);
        }
        
        [HttpPost]
        public ActionResult AddMaterial(DeadLoads.Material material)
        {
            materials.Add(material);
            return Json(materials, JsonRequestBehavior.AllowGet);
        }
        
        DeadLoads.MaterialsWeightEntities context = new DeadLoads.MaterialsWeightEntities();


        public JsonResult GetSubcategories(string categoryId, string categoryName)
        {
            long id;
            if (!Int64.TryParse(categoryId, out id))
                return Json("", JsonRequestBehavior.AllowGet);

            string categorySymbol = deadLoadsViewModel.CategoryList.Categories.
                FirstOrDefault(n => n.ID == id)?.Symbol ?? "";

            List<DeadLoads.Subcategory> subcategories = new List<DeadLoads.Subcategory>();
            subcategories = context.Subcategories.Where(s => s.CategorySymbol == categorySymbol).ToList();
            deadLoadsViewModel.SubcategoryList.Subcategories = subcategories;
            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMaterial(string materialId)
        {
            long id;
            if (!Int64.TryParse(materialId, out id))
                return null;
            
           DeadLoads.Material material = new DeadLoads.Material();
            material = context.Materials.SingleOrDefault(s => s.ID == id);
            return Json(material, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateMaterial(DeadLoads.Material mat)
        {
            context.Materials.Add(mat);
            context.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetMaterials(string subcategoryId, string subcategoryName)
        {
            long id;
            if (!Int64.TryParse(subcategoryId, out id))
                return null;

            string subcategorySymbol = deadLoadsViewModel.SubcategoryList.Subcategories.
                FirstOrDefault(n => n.ID == id)?.Symbol ?? "";

            List<DeadLoads.Material> materials = new List<DeadLoads.Material>();
            materials = context.Materials.Where(s => s.SubCategorySymbol == subcategorySymbol).ToList();
            return Json(materials, JsonRequestBehavior.AllowGet);
        }

        public class StudentContext : System.Data.Entity.DbContext
        {
            public System.Data.Entity.DbSet<Student> Students { get; set; }
        }

        public class Student
        {
            [System.ComponentModel.DataAnnotations.Key]
            public int studentID { get; set; }
            [System.ComponentModel.DataAnnotations.Required]
            public string studentName { get; set; }
            [System.ComponentModel.DataAnnotations.Required]
            public string studentAddress { get; set; }
        }
    }
}