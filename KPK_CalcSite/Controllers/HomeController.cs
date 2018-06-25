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

        public ActionResult SnowLoadCalculator()
        {
            ViewBag.Title = "Snow load";
            ViewBag.Message = "Calculate all snow load types";

            return View();
        }

        public ActionResult SnowLoadDefinitions()
        {
            ViewBag.Title = "Snow load definitions";
            ViewBag.MessageDefinitions = "List of definitions for snow load calculators.";

            var definitions = new Dictionary<string, string>();
            definitions.Add("Characteristic value of snow load on the ground",
                "snow load on the ground based on an annual probability of exceedence of 0,02, excluding exceptional snow loads");
            definitions.Add("Altitude of the site",
                "height above mean sea level of the site where the structure is to be located, or is already located for an existing structure");
            definitions.Add("Exceptional snow load on the ground",
                "load of the snow layer on the ground resulting from a snow fall which has an exceptionally infrequent likelihood of occurring");
            definitions.Add("Characteristic value of snow load on the roof",
                "product of the characteristic snow load on the ground and appropriate coefficients");
            definitions.Add("Undrifted snow load on the roof",
                "load arrangement which describes the uniformly distributed snow load on the roof, affected only by the shape of the roof, before any redistribution of snow due to other climatic actions");
            definitions.Add("Drifted snow load on the roof",
                "load arrangement which describes the snow load distribution resulting from snow having been moved from one location to another location on a roof, e.g. by the action of the wind");
            definitions.Add("Roof snow load shape coefficient",
                "ratio of the snow load on the roof to the undrifted snow load on the ground, without the influence of exposure and thermal effects");
            definitions.Add("Thermal coefficient",
                "coefficient defining the reduction of snow load on roofs as a function of the heat flux through the roof, causing snow melting");
            definitions.Add("Exposure coefficient",
                "coefficient defining the reduction or increase of load on a roof of an unheated building, as a fraction of the characteristic snow load on the ground");
            definitions.Add("Load due to exceptional snow drift",
                "load arrangement which describes the load of the snow layer on the roof resulting from a snow deposition pattern which has an exceptionally infrequent likelihood of occurring");

            ViewBag.Definitions = definitions;

            ViewBag.MessageSymbols = "List of notations used in snow load calculations.";

            var symbols = new Dictionary<string, string>();
            symbols.Add("C_e", "exposure coefficient");
            symbols.Add("C_t", "thermal coefficient");
            symbols.Add("C_esl", "coefficient for exceptional snow loads");
            symbols.Add("A", "site altitude above sea level [m]");
            symbols.Add("S_e", "snow load per metre length due to overhang [kN/m]");
            symbols.Add("F_s", "force per metre length exerted by a sliding mass of snow [kN/m]");
            symbols.Add("b", "width of construction work [m]");
            symbols.Add("d", "depth of the snow layer [m]");
            symbols.Add("h", "height of construction work [m]");
            symbols.Add("k", "coefficient to take account of the irregular shape of snow");
            symbols.Add("l_s", "length of snow drift or snow loaded area [m]");
            symbols.Add("s", "snow load on the roof [kN/m2]");
            symbols.Add("s_k", "characteristic value of snow on the ground at the relevant site [kN/m2]");
            symbols.Add("s_Ad", "design value of exceptional snow load on the ground [kN/m2]");
            symbols.Add("α", "pitch of roof, measured from horizontal [o]");
            symbols.Add("β", "angle between the horizontal and the tangent to the curve for a cylindrical roof [o]");
            symbols.Add("γ", "weight density of snow [kN/m3]");
            symbols.Add("μ", "snow load shape coefficient");
            symbols.Add("ψ_0", "factor for combination value of a variable action");
            symbols.Add("ψ_1", "factor for frequent value of a variable action");
            symbols.Add("ψ_2", "factor for quasi-permanent value of a variable action");

            ViewBag.Symbols = symbols;

            return View();
        }
    }
}