using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalcSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you have any questions about how calculators work or want to report an error, please feel free to contact me.";

            return View();
        }

        public ActionResult Calculators()
        {
            ViewBag.Message = "Your calculators.";

            return View();
        }

        public ActionResult DeadLoadCalculator()
        {
            ViewBag.Title = "Dead load";
            ViewBag.Message = "Calculate all dead loads";

            return View();
        }

       
    }
}