using KPK_CalcSite.Models.SnowLoads;

namespace KPK_CalcSite.ViewModels
{
    public class SnowLoadsViewModel
    {
        public BuildingData BuildingData { get; set; }
        public SnowLoadMonopitchRoof SnowLoadMonopitchRoof { get; set; }
        public SnowLoadPitchedRoof SnowLoadPitchedRoof { get; set; }
        public SnowLoadMultispanRoof SnowLoadMultispanRoof { get; set; }
        public SnowLoadCylindricalRoof SnowLoadCylindricalRoof { get; set; }
        public SnowLoadRoofAbuttingToTallerConstruction SnowLoadRoofAbuttingToTallerConstruction { get; set; }
        public SnowLoadDriftingAtProjectionsObstructions SnowLoadDriftingAtProjectionsObstructions { get; set; }
        public SnowLoadSnowOverhanging SnowLoadSnowOverhanging { get; set; }
        public SnowLoadSnowguards SnowLoadSnowguards { get; set; }
        public ExceptionalSnowLoadMultispanRoof ExceptionalSnowLoadMultispanRoof { get; set; }
        public ExceptionalSnowLoadRoofAbuttingToTallerConstruction ExceptionalSnowLoadRoofAbuttingToTallerConstruction { get; set; }
        public ExceptionalSnowLoadObstructionOnFlatRoof ExceptionalSnowLoadObstructionOnFlatRoof { get; set; }
        public ExceptionalSnowLoadOverDoorOrLoadingBay ExceptionalSnowLoadOverDoorOrLoadingBay { get; set; }
        public ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof ExceptionalSnowLoadObstructionOnPitchedOrCurvedRoof { get; set; }
        public ExceptionalSnowLoadSnowBehindParapet ExceptionalSnowLoadSnowBehindParapet { get; set; }
        public ExceptionalSnowLoadSnowBehindParapetAtEaves ExceptionalSnowLoadSnowBehindParapetAtEaves { get; set; }
        public ExceptionalSnowLoadSnowInValleyBehindParapet ExceptionalSnowLoadSnowInValleyBehindParapet { get; set; }
    }
}