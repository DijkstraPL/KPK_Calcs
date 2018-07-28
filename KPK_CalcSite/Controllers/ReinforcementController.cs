using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers
{
    public class ReinforcementController : Controller
    {
        // GET: Reinforcement
        public ActionResult Index()
        {
            return View("ReinforcementAnchoring");
        }
    }
}