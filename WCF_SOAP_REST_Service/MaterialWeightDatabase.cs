using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WCF_SOAP_REST_Service
{
    public class MaterialWeightDatabase : DbContext
    {
        private static Dictionary<int, MaterialWeight> materialWeightData =
            new Dictionary<int, MaterialWeight>();

        static MaterialWeightDatabase()
        {
            int i = 0;
            var context = new MaterialsWeightsEntities();

            foreach (var material in context.Materials)
            {
                materialWeightData.Add(i++, material);
            }
        }

        public IEnumerable<MaterialWeight> GetMaterialWeightList()
        {
            return materialWeightData.Values;
        }


        private int NewMaterialWeightNumber()
        {
            int maxKey = 0;
            if (materialWeightData.Count > 0)
            {
                maxKey = materialWeightData.Keys.Max();
            }
            return maxKey + 1;
        }

        public MaterialWeight AddMaterialWeight(MaterialWeight materialWeight)
        {
            if (materialWeightData.ContainsKey(materialWeight.MatWeightNo))
                throw new ArgumentException("Duplicate key found",
                    nameof(materialWeight.MatWeightNo));
            if (materialWeight.MatWeightNo == 0)
                materialWeight.MatWeightNo = NewMaterialWeightNumber();
            materialWeightData[materialWeight.MatWeightNo] = materialWeight;
            return materialWeight;
        }

        public MaterialWeight FindMaterialWeight(int matWeightNo)
        {
            MaterialWeight existing = materialWeightData[matWeightNo];
            if (existing == null)
                throw new ArgumentException("No such key found", nameof(matWeightNo));
            return existing;
        }

        public MaterialWeight UpdateMaterialWeight(int matWeightNo, MaterialWeight materialWeight)
        {
            MaterialWeight existing = FindMaterialWeight(matWeightNo);
            existing.MatWeightNo = materialWeight.MatWeightNo;
            existing.MaterialName = materialWeight.MaterialName;
            return existing;
        }

        public MaterialWeight RemoveMaterialWeight(int matWeightNo)
        {
            MaterialWeight existing = FindMaterialWeight(matWeightNo);
            materialWeightData.Remove(matWeightNo);
            return existing;
        }
    }

}