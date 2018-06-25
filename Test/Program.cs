using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindLoads;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WindLoad windLoad = new WindLoad(WindLoad.WindLoadEnum.FIRST_WIND_ZONE, 250, WindLoad.TerrainCategoryEnum.TERRAIN_CATEGORY_2, 10, 30, 40);

            Console.WriteLine(windLoad.PeakVelocityPressure);

            BuildingWithFlatRoof buildingWithFlatRoof = new BuildingWithFlatRoof(Building.InternalPressureCoefficientEnum.POINT_TWO, 30, 40, 10, BuildingWithFlatRoof.RoofTypeEnum.SHARP_EAVES, 1);

            buildingWithFlatRoof.CalculateWindLoads(Building.WindDirectionEnum.RIGHT, BuildingWithFlatRoof.FieldIValuesEnum.MINUS_POINT_TWO);

            foreach (var area in buildingWithFlatRoof.AreasOfWindZonesForWalls)
            {
                Console.WriteLine(area);
            }

            foreach (var area in buildingWithFlatRoof.AreasOfWindZonesForRoof)
            {
                Console.WriteLine(area);
            }

            foreach (var value in buildingWithFlatRoof.ExternalPressureCoefficientsForWalls)
            {
                Console.WriteLine(value);
            }

            foreach (var value in buildingWithFlatRoof.ExternalPressureCoefficientsForRoof)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
