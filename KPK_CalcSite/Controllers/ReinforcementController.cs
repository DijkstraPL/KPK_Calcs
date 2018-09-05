using KPK_CalcSite.Models.ReinforcementAnchoring;
using KPK_CalcSite.ViewModels;
using ReinforcementAnchoring;
using ReinforcementAnchoring.Coefficients;
using ReinforcementAnchoring.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers
{
    public class ReinforcementController : Controller
    {
        // GET: Reinforcement
        public ActionResult ReinforcementAnchoring()
        {
            Reinforcement reinforcement = null;
            ReinforcementPosition reinforcementPosition = null;
            //ConcreteClass concreteClass = null;

            ICoefficient barFormCoefficient = new BarFormCoefficient(
                reinforcementPosition, reinforcement);
            ICoefficient coverCoefficient = new CoverCoefficient(
                reinforcementPosition, reinforcement);
            ICoefficient transverseReinforcementCoefficient = new TransverseReinforcementCoefficient(
                reinforcementPosition, reinforcement, TypeEnum.Beam, 0);
            ICoefficient weldedTransverseBarCoefficient = new WeldedTransverseBarCoefficient();
            ICoefficient transversePressureCoefficient = 
                new TransversePressureCoefficient(reinforcementPosition,0 );

            var coefficients = new List<ICoefficient>();

            coefficients.Add(barFormCoefficient);
            coefficients.Add(coverCoefficient);
            coefficients.Add(transverseReinforcementCoefficient);
            coefficients.Add(weldedTransverseBarCoefficient);
            coefficients.Add(transversePressureCoefficient);

            var anchorageLength = new AnchoringAnchorageLength();

            var reinforcementAnchoringViewModel = new ReinforcementAnchoringViewModel();

            return View("ReinforcementAnchoring", reinforcementAnchoringViewModel);
        }

        [HttpPost]
        public ActionResult CalculateReinforcementAnchoring(ReinforcementAnchoringViewModel reinforcementAnchoringViewModel)
        {
            var antyCoefficients = new List<Type>();

            if (!reinforcementAnchoringViewModel.CalculateBarFormCoefficient)
                antyCoefficients.Add(typeof(BarFormCoefficient));
            if (!reinforcementAnchoringViewModel.CalculateCoverCoefficient)
                antyCoefficients.Add(typeof(CoverCoefficient));
            if (!reinforcementAnchoringViewModel.CalculateTransverseReinforcementCoefficient)
                antyCoefficients.Add(typeof(TransverseReinforcementCoefficient));
            if (!reinforcementAnchoringViewModel.CalculateWeldedTransverseBarCoefficient)
                antyCoefficients.Add(typeof(WeldedTransverseBarCoefficient));
            if (!reinforcementAnchoringViewModel.CalculateTransversePressureCoefficient)
                antyCoefficients.Add(typeof(TransversePressureCoefficient));

            var reinforcement = new Reinforcement(
                reinforcementAnchoringViewModel.ReinforcementDiameter?? 0,
                reinforcementAnchoringViewModel.PressInReinforcement ?? 0,
                reinforcementAnchoringViewModel.IsPairOfBars);
            var reinforcementPosition = new ReinforcementPosition(
                reinforcementAnchoringViewModel.AreAnchoragesInTension,
                reinforcementAnchoringViewModel.AnchorageType,
                reinforcementAnchoringViewModel.SideCoverDistance ?? 0,
                reinforcementAnchoringViewModel.BottomCoverDistance ?? 0,
                reinforcementAnchoringViewModel.DistanceBetweenBars ?? 0,
                reinforcementAnchoringViewModel.TransverseBarPosition);
        
            ICoefficient barFormCoefficient = new BarFormCoefficient(
                reinforcementPosition, reinforcement);
            ICoefficient coverCoefficient = new CoverCoefficient(
                reinforcementPosition, reinforcement);
            ICoefficient transverseReinforcementCoefficient = new TransverseReinforcementCoefficient(
                reinforcementPosition, reinforcement, reinforcementAnchoringViewModel.Type, 
                reinforcementAnchoringViewModel.TransverseReinforcementArea ?? 0);
            ICoefficient weldedTransverseBarCoefficient = new WeldedTransverseBarCoefficient();
            ICoefficient transversePressureCoefficient = new TransversePressureCoefficient(
                reinforcementPosition, reinforcementAnchoringViewModel.TransversePressure ?? 0);

            var coefficients = new List<ICoefficient>();

            coefficients.Add(barFormCoefficient);
            coefficients.Add(coverCoefficient);
            coefficients.Add(transverseReinforcementCoefficient);
            coefficients.Add(weldedTransverseBarCoefficient);
            coefficients.Add(transversePressureCoefficient);

          var filteredCoefficients =
            coefficients.Where(c => !antyCoefficients.Contains(c.GetType())).ToList();
            
            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                reinforcementAnchoringViewModel.ConcreteClassName,
                reinforcementAnchoringViewModel.Type,
                reinforcementAnchoringViewModel.BondCondition,
                filteredCoefficients, reinforcementAnchoringViewModel.TransversePressure ?? 0);

            anchorageLength.CalculateAnchorageLengths();

            reinforcementAnchoringViewModel.AnchoringAnchorageLength = new AnchoringAnchorageLength()
            {
                AnchorageLength = anchorageLength            
            };

            reinforcementAnchoringViewModel.ShowResults = true;
            
            return View("ReinforcementAnchoring", reinforcementAnchoringViewModel);
        }
    }
}