using KPK_CalcSite.Models.SnowLoads;
using KPK_CalcSite.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KPK_CalcSite.Controllers
{
    public class SnowLoadsController : Controller
    {
        public ActionResult Calculator()
        {
            ViewBag.Title = "Snow load";
            ViewBag.Message = "Calculate all snow load types";

            var snowLoadMonopitchRoof = new SnowLoadMonopitchRoof();

            var snowLoadMonopitchRoofViewModel = new SnowLoadsViewModel();
            snowLoadMonopitchRoofViewModel.SnowLoadMonopitchRoof = snowLoadMonopitchRoof;

            return View(snowLoadMonopitchRoofViewModel);
        }

        public ActionResult MonopitchRoof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateMonopitchRoof(SnowLoadMonopitchRoof snowLoadMonopitchRoof, BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            snowLoadMonopitchRoof.BuildingData = buildingData;

            snowLoadMonopitchRoof.MonopitchRoof =
                new SnowLoads.BuildingTypes.MonopitchRoof(
                    buildingData.Building,
                    snowLoadMonopitchRoof.MonopitchRoof.Slope,
                    snowLoadMonopitchRoof.MonopitchRoof.SnowFences);

            snowLoadMonopitchRoof.MonopitchRoof.CalculateSnowLoad();

            return View("MonopitchRoofResult", snowLoadMonopitchRoof);
        }

        public ActionResult PitchedRoof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculatePitchedRoof(SnowLoadPitchedRoof snowLoadPitchedRoof, BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            snowLoadPitchedRoof.BuildingData = buildingData;

            snowLoadPitchedRoof.PitchedRoof =
                new SnowLoads.BuildingTypes.PitchedRoof(
                    buildingData.Building,
                    snowLoadPitchedRoof.PitchedRoof.LeftRoof.Slope,
                    snowLoadPitchedRoof.PitchedRoof.RightRoof.Slope,
                    snowLoadPitchedRoof.PitchedRoof.LeftRoof.SnowFences,
                    snowLoadPitchedRoof.PitchedRoof.RightRoof.SnowFences);

            snowLoadPitchedRoof.PitchedRoof.CalculateSnowLoad();

            return View("PitchedRoofResult", snowLoadPitchedRoof);
        }

        public ActionResult MultispanRoof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateMultispanRoof(SnowLoadMultispanRoof snowLoadMultispanRoof, BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            snowLoadMultispanRoof.BuildingData = buildingData;

            snowLoadMultispanRoof.MultiSpanRoof =
                new SnowLoads.BuildingTypes.MultiSpanRoof(
                    buildingData.Building,
                    snowLoadMultispanRoof.MultiSpanRoof.LeftRoof.Slope,
                    snowLoadMultispanRoof.MultiSpanRoof.RightRoof.Slope,
                    snowLoadMultispanRoof.MultiSpanRoof.LeftRoof.SnowFences,
                    snowLoadMultispanRoof.MultiSpanRoof.RightRoof.SnowFences);

            snowLoadMultispanRoof.MultiSpanRoof.CalculateSnowLoad();

            return View("MultispanRoofResult", snowLoadMultispanRoof);
        }

        public ActionResult CylindricalRoof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateCylindricalRoof(SnowLoadCylindricalRoof snowLoadCylindricalRoof, BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            snowLoadCylindricalRoof.BuildingData = buildingData;

            snowLoadCylindricalRoof.CylindricalRoof =
                new SnowLoads.BuildingTypes.CylindricalRoof(
                    buildingData.Building,
                    snowLoadCylindricalRoof.CylindricalRoof.Width,
                    snowLoadCylindricalRoof.CylindricalRoof.Height);

            snowLoadCylindricalRoof.CylindricalRoof.CalculateDriftLength();
            snowLoadCylindricalRoof.CylindricalRoof.CalculateSnowLoad();

            return View("CylindricalRoofResult", snowLoadCylindricalRoof);
        }

        public ActionResult RoofAbuttingToTallerConstruction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateRoofAbuttingToTallerConstruction(
            SnowLoadRoofAbuttingToTallerConstruction snowLoadRoofAbuttingToTallerConstruction,
            BuildingData buildingData)
        {
            buildingData.SnowLoad.SnowDensity = snowLoadRoofAbuttingToTallerConstruction.BuildingData.SnowLoad.SnowDensity;

            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = snowLoadRoofAbuttingToTallerConstruction.RoofAbuttingToTallerConstruction;

            snowLoadRoofAbuttingToTallerConstruction.BuildingData = buildingData;

            roof =
                new SnowLoads.BuildingTypes.RoofAbuttingToTallerConstruction(
                    buildingData.Building,
                    roof.WidthOfUpperBuilding,
                    roof.WidthOfLowerBuilding,
                    roof.HeightDifference,
                    roof.UpperRoof.Slope,
                    roof.UpperRoof.SnowFences);

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            snowLoadRoofAbuttingToTallerConstruction.RoofAbuttingToTallerConstruction = roof;

            return View("RoofAbuttingToTallerConstructionResult", snowLoadRoofAbuttingToTallerConstruction);
        }

        public ActionResult DriftingAtProjectionsObstructions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateDriftingAtProjectionsObstructions(
           SnowLoadDriftingAtProjectionsObstructions snowLoadDriftingAtProjectionsObstructions,
           BuildingData buildingData)
        {
            buildingData.SnowLoad.SnowDensity = snowLoadDriftingAtProjectionsObstructions.BuildingData.SnowLoad.SnowDensity;

            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = snowLoadDriftingAtProjectionsObstructions.DriftingAtProjectionsObstructions;

            snowLoadDriftingAtProjectionsObstructions.BuildingData = buildingData;

            roof =
                new SnowLoads.BuildingTypes.DriftingAtProjectionsObstructions(
                    buildingData.Building,
                    roof.ObstructionHeight);

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            snowLoadDriftingAtProjectionsObstructions.DriftingAtProjectionsObstructions = roof;

            return View("DriftingAtProjectionsObstructionsResult", snowLoadDriftingAtProjectionsObstructions);
        }

        public ActionResult SnowOverhanging()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateSnowOverhanging(
        SnowLoadSnowOverhanging snowLoadSnowOverhanging,
        BuildingData buildingData)
        {
            buildingData.SnowLoad.SnowDensity = snowLoadSnowOverhanging.BuildingData.SnowLoad.SnowDensity;

            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = snowLoadSnowOverhanging.SnowOverhanging;

            snowLoadSnowOverhanging.BuildingData = buildingData;

            roof =
                new SnowLoads.BuildingTypes.SnowOverhanging(
                    buildingData.Building,
                    roof.SnowLayerDepth,
                    roof.SnowLoadOnRoofValue);

            roof.CalculateSnowLoad();

            snowLoadSnowOverhanging.SnowOverhanging = roof;

            return View("SnowOverhangingResult", snowLoadSnowOverhanging);
        }

        public ActionResult Snowguards()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateSnowguards(
            SnowLoadSnowguards snowLoadSnowguards,
            BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = snowLoadSnowguards.Snowguards;

            snowLoadSnowguards.BuildingData = buildingData;

            roof =
                new SnowLoads.BuildingTypes.Snowguards(
                    roof.Width,
                    roof.Slope,
                    roof.SnowLoadOnRoofValue);

            roof.CalculateSnowLoad();

            snowLoadSnowguards.Snowguards = roof;

            return View("SnowguardsResult", snowLoadSnowguards);
        }

        [Authorize]
        public ActionResult ExceptionalMultispanRoof()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalMultispanRoof(
        ExceptionalSnowLoadMultispanRoof exceptionalSnowLoadMultispanRoof,
        BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadMultispanRoof.ExceptionalMultispanRoof;

            exceptionalSnowLoadMultispanRoof.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalMultiSpanRoof(
                    buildingData.Building,
                    roof.LeftDriftLength,
                    roof.RightDriftLength,
                    roof.HeightInTheLowestPart);

            roof.CalculateSnowLoad();

            exceptionalSnowLoadMultispanRoof.ExceptionalMultispanRoof = roof;

            return View("ExceptionalMultispanRoofResult", exceptionalSnowLoadMultispanRoof);
        }

        [Authorize]
        public ActionResult ExceptionalRoofAbuttingToTallerConstruction()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalRoofAbuttingToTallerConstruction(
        ExceptionalSnowLoadRoofAbuttingToTallerConstruction exceptionalSnowLoadRoofAbuttingToTallerConstruction,
        BuildingData buildingData)
         {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadRoofAbuttingToTallerConstruction.ExceptionalRoofAbuttingToTallerConstruction;

            exceptionalSnowLoadRoofAbuttingToTallerConstruction.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalRoofAbuttingToTallerConstruction(
                    buildingData.Building,
                    roof.UpperBuildingWidth,
                    roof.LowerBuildingWidth,
                    roof.HeightDifference,
                    roof.Angle
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadRoofAbuttingToTallerConstruction.ExceptionalRoofAbuttingToTallerConstruction = roof;

            return View("ExceptionalRoofAbuttingToTallerConstructionResult", exceptionalSnowLoadRoofAbuttingToTallerConstruction);
        }

        [Authorize]
        public ActionResult ExceptionalObstructionOnFlatRoof()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalObstructionOnFlatRoof(
        ExceptionalSnowLoadObstructionOnFlatRoof exceptionalSnowLoadObstructionOnFlatRoof,
        BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadObstructionOnFlatRoof.ExceptionalObstructionOnFlatRoof;

            exceptionalSnowLoadObstructionOnFlatRoof.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalObstructionOnFlatRoof(
                    buildingData.Building,
                    roof.LeftWidth,
                    roof.RightWidth,
                    roof.LeftHeightDifference,
                    roof.RightHeightDifference
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadObstructionOnFlatRoof.ExceptionalObstructionOnFlatRoof = roof;

            return View("ExceptionalObstructionOnFlatRoofResult", exceptionalSnowLoadObstructionOnFlatRoof);
        }

        [Authorize]
        public ActionResult ExceptionalOverDoorOrLoadingBay()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalOverDoorOrLoadingBay(
        ExceptionalSnowLoadOverDoorOrLoadingBay exceptionalSnowLoadOverDoorOrLoadingBay,
        BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadOverDoorOrLoadingBay.ExceptionalOverDoorOrLoadingBay;

            exceptionalSnowLoadOverDoorOrLoadingBay.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalOverDoorOrLoadingBay(
                    buildingData.Building,
                    roof.WidthAboveDoor,
                    roof.BuildingWidth,
                    roof.HeightDifference
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadOverDoorOrLoadingBay.ExceptionalOverDoorOrLoadingBay = roof;

            return View("ExceptionalOverDoorOrLoadingBayResult", exceptionalSnowLoadOverDoorOrLoadingBay);
        }

        [Authorize]
        public ActionResult ExceptionalObstructionOnPitchedOrCurvedRoof()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalObstructionOnPitchedOrCurvedRoof(
        ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof exceptionalSnowLoadObstructionOnPitchedOrCurvedRoof,
        BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadObstructionOnPitchedOrCurvedRoof.ExceptionalObstructionOnPitchedOrCurvedRoof;

            exceptionalSnowLoadObstructionOnPitchedOrCurvedRoof.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalObstructionOnPitchedOrCurvedRoof(
                    buildingData.Building,
                    roof.LeftWidth,
                    roof.RightWidth,
                    roof.LeftHeightDifference,
                    roof.RightHeightDifference                                    
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadObstructionOnPitchedOrCurvedRoof.ExceptionalObstructionOnPitchedOrCurvedRoof = roof;

            return View("ExceptionalObstructionOnPitchedOrCurvedRoofResult", exceptionalSnowLoadObstructionOnPitchedOrCurvedRoof);
        }

        [Authorize]
        public ActionResult ExceptionalSnowBehindParapet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalSnowBehindParapet(
            ExceptionalSnowLoadSnowBehindParapet exceptionalSnowLoadSnowBehindParapet,
            BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadSnowBehindParapet.ExceptionalSnowBehindParapet;

            exceptionalSnowLoadSnowBehindParapet.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalSnowBehindParapet(
                    buildingData.Building,
                    roof.Width,
                    roof.HeightDifference
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadSnowBehindParapet.ExceptionalSnowBehindParapet = roof;

            return View("ExceptionalSnowBehindParapetResult", exceptionalSnowLoadSnowBehindParapet);
        }

        [Authorize]
        public ActionResult ExceptionalSnowBehindParapetAtEaves()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalSnowBehindParapetAtEaves(
            ExceptionalSnowLoadSnowBehindParapetAtEaves exceptionalSnowLoadSnowBehindParapetAtEaves,
            BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadSnowBehindParapetAtEaves.ExceptionalSnowBehindParapetAtEaves;

            exceptionalSnowLoadSnowBehindParapetAtEaves.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalSnowBehindParapetAtEaves(
                    buildingData.Building,
                    roof.RidgeDistance,
                    roof.BuildingWidth,
                    roof.HeightDifference
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadSnowBehindParapetAtEaves.ExceptionalSnowBehindParapetAtEaves = roof;

            return View("ExceptionalSnowBehindParapetAtEavesResult", exceptionalSnowLoadSnowBehindParapetAtEaves);
        }

        [Authorize]
        public ActionResult ExceptionalSnowInValleyBehindParapet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalculateExceptionalSnowInValleyBehindParapet(
            ExceptionalSnowLoadSnowInValleyBehindParapet exceptionalSnowLoadSnowInValleyBehindParapet,
            BuildingData buildingData)
        {
            buildingData.BuildingSite.CalculateExposureCoefficient();
            buildingData.SnowLoad.CalculateSnowLoad();
            buildingData.Building.CalculateThermalCoefficient();

            var roof = exceptionalSnowLoadSnowInValleyBehindParapet.ExceptionalSnowInValleyBehindParapet;

            exceptionalSnowLoadSnowInValleyBehindParapet.BuildingData = buildingData;

            roof =
                new SnowLoads.Exceptional.ExceptionalSnowInValleyBehindParapet(
                    buildingData.Building,
                    roof.Width,
                    roof.HeightDifference
                    );

            roof.CalculateDriftLength();
            roof.CalculateSnowLoad();

            exceptionalSnowLoadSnowInValleyBehindParapet.ExceptionalSnowInValleyBehindParapet = roof;

            return View("ExceptionalSnowInValleyBehindParapetResult", exceptionalSnowLoadSnowInValleyBehindParapet);
        }

        public ActionResult Definitions()
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