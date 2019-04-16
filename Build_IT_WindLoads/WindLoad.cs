using Build_IT_CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_WindLoads
{
    public class WindLoad
    {
        private IDictionary<double, double> _referenceHeights { get; } = new Dictionary<double, double>();

        private readonly IBuildingSite _buildingSite;
        private readonly IBuilding _building;
        private readonly bool _buildingRotated;
        private readonly double _heightStrip;
        private double _windwardWallWidth;

        [Abbreviation("k_l")]
        [Unit("")]
        private readonly double _turbulenceFactor = 1;

        [Abbreviation("ρ")]
        [Unit("kg/m3")]
        private double _airDensity;

        public WindLoad(IBuildingSite buildingSite, IBuilding building, 
            bool buildingRotated, double heightStrip = 1)
        {
            _buildingSite = buildingSite;
            _building = building;
            _buildingRotated = buildingRotated;
            _heightStrip = heightStrip;

            SetAirDensity();
            SetWindwardWall();
            SetReferenceHeights();
        }

        private void SetAirDensity()
        {
            if (_buildingSite.WindZone == WindZone.III ||
                _buildingSite.WindZone == WindZone.I_III)
                _airDensity = 1.25 *
                        (20000 - _buildingSite.HeightAboveSeaLevel) /
                        (20000 + _buildingSite.HeightAboveSeaLevel);
            else
                _airDensity = 1.25;
        }

        public double GetReferenceHeightAt(double height)
        {
            if (height < 0 || height > _building.Height)
                throw new IndexOutOfRangeException("Requested height is outside the building solid.");

            return _referenceHeights.First(rh => height <= rh.Key).Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.3]</remarks>
        public double GetMeanWindVelocityAt(double height)
        {
            var terrain = _buildingSite.Terrain;
            return terrain.GetRoughnessFactorAt(height) *
                           terrain.TerrainOrography.GetOrographicFactorAt(height) *
                           _buildingSite.BasicWindVelocity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Eq.4.7]</remarks>
        public double GetTurbulenceIntensityAt(double height)
        {
            var terrain = _buildingSite.Terrain;
            if (height < terrain.MinimumHeight)
                height = terrain.MinimumHeight;

            return _turbulenceFactor / 
                (terrain.TerrainOrography.GetOrographicFactorAt(height) * 
                Math.Log(height / terrain.RoughnessLength));
        }

        public double GetPeakVelocityPressureAt(double height)
        {
            return (1 + 7 * GetTurbulenceIntensityAt(height)) * 0.5 * _airDensity *
                Math.Pow(GetMeanWindVelocityAt(height), 2) / 1000; // Change to kN/m2
        }

        private void SetWindwardWall()
        {
            if (_buildingRotated)
                _windwardWallWidth = _building.Length;
            else
                _windwardWallWidth = _building.Width;
        }

        private void SetReferenceHeights()
        {
            if (_building.Height <= _windwardWallWidth)
                _referenceHeights.Add(_building.Height, _building.Height);
            else if (_building.Height <= 2 * _windwardWallWidth)
            {
                _referenceHeights.Add(_windwardWallWidth, _windwardWallWidth);
                _referenceHeights.Add(_building.Height, _building.Height);
            }
            else
            {
                _referenceHeights.Add(_windwardWallWidth, _windwardWallWidth);
                int index = 1;
                while (_windwardWallWidth + index * _heightStrip < _building.Height - _windwardWallWidth)
                {
                    var referenceHeightAtStrip = _windwardWallWidth + index * _heightStrip;
                    _referenceHeights.Add(referenceHeightAtStrip, referenceHeightAtStrip);
                    index++;
                }
                if(!_referenceHeights.ContainsKey(_building.Height - _windwardWallWidth))
                    _referenceHeights.Add(_building.Height - _windwardWallWidth, _building.Height - _windwardWallWidth);
                _referenceHeights.Add(_building.Height, _building.Height);
            }
        }
    }
}
