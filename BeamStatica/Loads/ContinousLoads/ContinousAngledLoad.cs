using BeamStatica.Loads.ContinousLoads.NormalLoadResults;
using BeamStatica.Loads.ContinousLoads.ShearLoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads
{
    public class ContinousAngledLoad : ContinousLoad
    {
        public double Angle { get; }

        private IContinousLoad _horizontalContinousLoad;
        private IContinousLoad _verticalContinousLoad;

        public static IContinousLoad Create(double startPosition, double startValue, 
            double endPosition, double endValue, double angle)
        {
            return new ContinousAngledLoad(
                new LoadData(startPosition, startValue),
                new LoadData(endPosition, endValue),
                angle);
        }

        public static IContinousLoad Create(
            ILoadWithPosition startLoadWithPosition,
            ILoadWithPosition endLoadWithPosition,
            double angle)
        {
            return new ContinousAngledLoad(startLoadWithPosition, endLoadWithPosition, angle);
        }

        private ContinousAngledLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition, double angle)
            : base(startPosition, endPosition)
        {
            Angle = angle;
            SetContinousLoads();

            NormalForceResult = new NormalForceResult(_horizontalContinousLoad);
            ShearResult = new ShearResult(_verticalContinousLoad);
            BendingMomentResult = new BendingMomentResult(_verticalContinousLoad);

            RotationResult = new RotationResult(_verticalContinousLoad);
            HorizontalDeflectionResult = new HorizontalDeflectionResult(_horizontalContinousLoad);
            VerticalDeflectionResult = new VerticalDeflectionResult(_verticalContinousLoad);
        }

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode) 
            => _horizontalContinousLoad.CalculateSpanLoadVectorNormalForceMember(span, leftNode);

        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode) 
            => _verticalContinousLoad.CalculateSpanLoadVectorShearMember(span, leftNode);

        public override double CalculateSpanLoadVectorBendingMomentMember(ISpan span, bool leftNode)
            => _verticalContinousLoad.CalculateSpanLoadVectorBendingMomentMember(span, leftNode);

        private void SetContinousLoads()
        {
            double angleInRadians = Angle * Math.PI / 180;

            _horizontalContinousLoad = ContinousNormalLoad.Create(
                this.StartPosition.Position,
                this.StartPosition.Value * Math.Sin(angleInRadians),
                this.EndPosition.Position,
                this.EndPosition.Value * Math.Sin(angleInRadians));
            _verticalContinousLoad = ContinousShearLoad.Create(
                this.StartPosition.Position,
                this.StartPosition.Value * Math.Cos(angleInRadians),
                this.EndPosition.Position,
                this.EndPosition.Value * Math.Cos(angleInRadians));
        }
    }
}
