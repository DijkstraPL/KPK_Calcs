using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads
{
    public class ContinousBendingMomentLoad : ContinousLoad
    {
        public static IContinousLoad Create(ISpan span, double value)
        {
            return new ContinousBendingMomentLoad(
                new LoadData(0, value),
                new LoadData(span.Length, value));
        }

        private ContinousBendingMomentLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition)
            : base(startPosition, endPosition)
        {
            //ShearResult = new ShearResult(this);
            //BendingMomentResult = new BendingMomentResult(this);

            //RotationResult = new RotationResult(this);
            //VerticalDeflectionResult = new VerticalDeflectionResult(this);
        }

        //public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        //{
        //    double closerLoad = leftNode ? -this.StartPosition.Value : -this.EndPosition.Value;
        //    double furtherLoad = leftNode ? -this.EndPosition.Value : -this.StartPosition.Value;
        //    double distanceFromCalculatedNode = leftNode ? this.StartPosition.Position : span.Length - this.EndPosition.Position;
        //    double loadLength = this.EndPosition.Position - this.StartPosition.Position;
        //    double distanceToOtherNode = leftNode ? span.Length - this.EndPosition.Position : this.StartPosition.Position;

        //    return 1.0 / 20 * furtherLoad * loadLength *
        //        (3 * Math.Pow(loadLength, 3) +
        //        5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
        //        10 * Math.Pow(distanceToOtherNode, 3) +
        //        30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
        //        30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
        //        15 * Math.Pow(loadLength, 2) * distanceToOtherNode +
        //        20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
        //        Math.Pow(span.Length, 3) +
        //        1.0 / 20 * closerLoad * loadLength *
        //        (7 * Math.Pow(loadLength, 3) +
        //        15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
        //        10 * Math.Pow(distanceToOtherNode, 3) +
        //         30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
        //         30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
        //         25 * Math.Pow(loadLength, 2) * distanceToOtherNode +
        //         40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
        //         Math.Pow(span.Length, 3);
        //}

        //public override double CalculateSpanLoadVectorBendingMomentMember(ISpan span, bool leftNode)
        //{
        //    double sign = leftNode ? 1.0 : -1.0;
        //    double closerLoad = leftNode ? -this.StartPosition.Value : -this.EndPosition.Value;
        //    double furtherLoad = leftNode ? -this.EndPosition.Value : -this.StartPosition.Value;
        //    double distanceFromCalculatedNode = leftNode ? this.StartPosition.Position : span.Length - this.EndPosition.Position;
        //    double loadLength = this.EndPosition.Position - this.StartPosition.Position;
        //    double distanceToOtherNode = leftNode ? span.Length - this.EndPosition.Position : this.StartPosition.Position;

        //    return sign / 60 * closerLoad * loadLength *
        //           (3 * Math.Pow(loadLength, 3) +
        //           15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
        //           10 * Math.Pow(distanceToOtherNode, 2) * loadLength +
        //           30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
        //           10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
        //           40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
        //           Math.Pow(span.Length, 2) +
        //           sign / 60 * furtherLoad * loadLength *
        //           (2 * Math.Pow(loadLength, 3) +
        //           5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
        //           20 * Math.Pow(distanceToOtherNode, 2) * loadLength +
        //           30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
        //           10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
        //           20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
        //           Math.Pow(span.Length, 2);
        //}
    }
}
