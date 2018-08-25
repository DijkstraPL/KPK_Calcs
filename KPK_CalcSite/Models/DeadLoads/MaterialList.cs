using DeadLoads;
using System.Collections.Generic;

namespace KPK_CalcSite.Models.DeadLoads
{
    public class MaterialList 
    {
        public IList<Material> Materials { get; set; }
        
        public MaterialList()
        {
            Materials = new List<Material>();
            MaterialsWeightEntities materialsWeightEntities = new MaterialsWeightEntities();
            foreach (var material in materialsWeightEntities.Materials)
            {
                Materials.Add(material);
            }
        }
    }
}