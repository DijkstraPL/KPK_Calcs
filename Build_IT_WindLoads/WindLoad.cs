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

        public WindLoad(IBuildingSite buildingSite, IBuilding building, 
            bool buildingRotated, double heightStrip = 1)
        {
            _buildingSite = buildingSite;
            _building = building;
            _buildingRotated = buildingRotated;
            _heightStrip = heightStrip;

            SetWindwardWall();
            SetReferenceHeights();
        }

        public double GetReferenceHeightAt(double height)
        {
            if (height < 0 || height > _building.Height)
                throw new IndexOutOfRangeException("Requested height is outside the building solid.");

            return _referenceHeights.First(rh => height <= rh.Key).Value;
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
