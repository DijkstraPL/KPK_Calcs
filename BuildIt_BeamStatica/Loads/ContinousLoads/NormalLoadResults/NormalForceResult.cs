using Build_IT_BeamStatica.Loads.ContinousLoads.Interfaces;
using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.NormalLoadResults
{
    public class NormalForceResult : ForceResultBase
    {
        public NormalForceResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(double distanceFromLoadStartPosition)
        {
            if (distanceFromLoadStartPosition >= ContinousLoad.Length)
                return CalculateNormalForceOutsideLoadLength();
            else
                return CalculateNormalForceInsideLoadLength(distanceFromLoadStartPosition);
        }

        private double CalculateNormalForceOutsideLoadLength()
            => ((ContinousLoad.StartPosition.Value + ContinousLoad.EndPosition.Value) * ContinousLoad.Length) / 2;

        private double CalculateNormalForceInsideLoadLength(double distanceFromLoadStartPosition)
        {
            double lineAngle = (ContinousLoad.EndPosition.Value - ContinousLoad.StartPosition.Value)
                / ContinousLoad.Length;

            return (ContinousLoad.StartPosition.Value + (lineAngle * distanceFromLoadStartPosition
                 + ContinousLoad.StartPosition.Value)) * distanceFromLoadStartPosition / 2;
        }
    }
}
