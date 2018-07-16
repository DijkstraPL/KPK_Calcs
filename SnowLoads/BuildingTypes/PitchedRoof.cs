using SnowLoads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.BuildingTypes
{
    /// <summary>
    /// class for pitched roof.
    /// </summary>
    public class PitchedRoof : ICalculatable
    {
        #region Properties

        /// <summary>
        /// Left roof.
        /// </summary>
        public IMonopitchRoof LeftRoof { get; set; }

        /// <summary>
        /// Right roof.
        /// </summary>
        public IMonopitchRoof RightRoof { get; set; }
        
        /// <summary>
        /// Snow load on left roof for all cases.
        /// </summary>
        public Dictionary<int, double> LeftRoofCasesSnowLoad { get; private set; }

        /// <summary>
        /// Snow load on right roof for all cases.
        /// </summary>
        public Dictionary<int, double> RightRoofCasesSnowLoad { get; private set; }

        /// <summary>
        /// Instance of building.
        /// </summary>
        public IBuilding Building { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="building">Instance of buildinng.</param>
        public PitchedRoof(IBuilding building, double leftRoofSlope, double rightRoofSlope,
            bool leftRoofSnowFences = false, bool rightRoofSnowFences = false)
        {
            LeftRoofCasesSnowLoad = new Dictionary<int, double>();
            RightRoofCasesSnowLoad = new Dictionary<int, double>();

            Building = building;

            LeftRoof = new MonopitchRoof(Building, leftRoofSlope, leftRoofSnowFences);
            RightRoof = new MonopitchRoof(Building, rightRoofSlope, rightRoofSnowFences);
        }

        public PitchedRoof(IBuilding building, IMonopitchRoof leftRoof, IMonopitchRoof rightRoof)
        {
            LeftRoofCasesSnowLoad = new Dictionary<int, double>();
            RightRoofCasesSnowLoad = new Dictionary<int, double>();

            Building = building;

            LeftRoof = leftRoof;
            RightRoof = rightRoof;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Calculate Snow Load On Roof 
        /// </summary>
        public void CalculateSnowLoad()
        {
            LeftRoof.CalculateSnowLoad();
            RightRoof.CalculateSnowLoad();
            SetCasesSnowLoad();
        }

        /// <summary>
        /// Set all cases of snow load for both roofs.
        /// </summary>
        public void SetCasesSnowLoad()
        {
            LeftRoofCasesSnowLoad.Clear();
            RightRoofCasesSnowLoad.Clear();

            LeftRoofCasesSnowLoad.Add(1, LeftRoof.SnowLoadOnRoofValue);
            LeftRoofCasesSnowLoad.Add(2, 0.5 * LeftRoof.SnowLoadOnRoofValue);
            LeftRoofCasesSnowLoad.Add(3, LeftRoof.SnowLoadOnRoofValue);

            RightRoofCasesSnowLoad.Add(1, RightRoof.SnowLoadOnRoofValue);
            RightRoofCasesSnowLoad.Add(2, RightRoof.SnowLoadOnRoofValue);
            RightRoofCasesSnowLoad.Add(3, 0.5 * RightRoof.SnowLoadOnRoofValue);
        }

        #endregion // Methods

    }
}
