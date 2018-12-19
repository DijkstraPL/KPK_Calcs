using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.ShearLoadResults
{
    public class BendingMomentResult : ForceResultBase
    {
        public BendingMomentResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(double distanceFromLoadStartPosition)
        {
            if (distanceFromLoadStartPosition >= ContinousLoad.Length)
                return CalculateBendingMomentOutsideLoadLength(distanceFromLoadStartPosition);
            else
                return CalculateBendingMomentInsideLoadLength(distanceFromLoadStartPosition);
        }

        private double CalculateBendingMomentOutsideLoadLength(double distanceFromLoadStartPosition)
        {
            double bendingMoment = 0;

            bendingMoment += ContinousLoad.StartPosition.Value *
                ContinousLoad.Length / 2 *
                (distanceFromLoadStartPosition - ContinousLoad.Length * 1 / 3);
            bendingMoment += ContinousLoad.EndPosition.Value *
                ContinousLoad.Length / 2 *
               (distanceFromLoadStartPosition - ContinousLoad.Length * 2 / 3);
            return bendingMoment;
        }

        private double CalculateBendingMomentInsideLoadLength(double distanceFromLoadStartPosition)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(distanceFromLoadStartPosition);
            double bendingMoment = 0;

            bendingMoment += ContinousLoad.StartPosition.Value *
               distanceFromLoadStartPosition / 2 *
               distanceFromLoadStartPosition * 2 / 3;
            bendingMoment += forceAtX *
                distanceFromLoadStartPosition / 2 *
                distanceFromLoadStartPosition * 1 / 3;

            return bendingMoment;
        }
    }
}
