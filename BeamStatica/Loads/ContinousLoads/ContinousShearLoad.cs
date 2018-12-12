using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;

namespace BeamStatica.Loads.ContinousLoads
{
    public class ContinousShearLoad : ContinousLoad
    {        
        public ContinousShearLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition) 
            : base(startPosition, endPosition)
        {
        }
        
        public override double CalculateShear(double distanceFromLoadStartPosition)
        {
            if (distanceFromLoadStartPosition >= this.Length)
               return CalculateShearForceOutsideLoadLength();
            else
                return CalculateShearForceInsideLoadLength(distanceFromLoadStartPosition);
        }

        public override double CalculateBendingMoment(double distanceFromLoadStartPosition)
        {
            if (distanceFromLoadStartPosition >= this.Length)
                return CalculateBendingMomentOutsideLoadLength(distanceFromLoadStartPosition);
            else
                return CalculateBendingMomentInsideLoadLength(distanceFromLoadStartPosition);
        }

        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        {
            double closerLoad = leftNode ? -this.StartPosition.Value : -this.EndPosition.Value;
            double furtherLoad = leftNode ? -this.EndPosition.Value : -this.StartPosition.Value;
            double distanceFromCalculatedNode = leftNode ? this.StartPosition.Position : Length - this.EndPosition.Position;
            double loadLength = this.EndPosition.Position - this.StartPosition.Position;
            double distanceToOtherNode = leftNode ? Length - this.EndPosition.Position : this.StartPosition.Position;

            return 1.0 / 20 * furtherLoad * loadLength *
                (3 * Math.Pow(loadLength, 3) +
                5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                10 * Math.Pow(distanceToOtherNode, 3) +
                30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                15 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                Math.Pow(Length, 3) +
                1.0 / 20 * closerLoad * loadLength *
                (7 * Math.Pow(loadLength, 3) +
                15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                10 * Math.Pow(distanceToOtherNode, 3) +
                 30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                 30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                 25 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                 40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                 Math.Pow(Length, 3);
        }

        public override double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            double closerLoad = leftNode ? -this.StartPosition.Value : -this.EndPosition.Value;
            double furtherLoad = leftNode ? -this.EndPosition.Value : -this.StartPosition.Value;
            double distanceFromCalculatedNode = leftNode ? this.StartPosition.Position : Length - this.EndPosition.Position;
            double loadLength = this.EndPosition.Position - this.StartPosition.Position;
            double distanceToOtherNode = leftNode ? Length - this.EndPosition.Position : this.StartPosition.Position;

            return sign / 60 * closerLoad * loadLength *
                   (3 * Math.Pow(loadLength, 3) +
                   15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                   30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                   40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                   Math.Pow(Length, 2) +
                   sign / 60 * furtherLoad * loadLength *
                   (2 * Math.Pow(loadLength, 3) +
                   5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                   20 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                   30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                   20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                   Math.Pow(Length, 2);
        }

        private double CalculateShearForceOutsideLoadLength() 
            => ((this.StartPosition.Value + this.EndPosition.Value) * this.Length) / 2;

        private double CalculateShearForceInsideLoadLength(double distanceFromLoadStartPosition)
        {
            double lineAngle = (this.EndPosition.Value - this.StartPosition.Value) / this.Length;

            return (this.StartPosition.Value + (lineAngle * distanceFromLoadStartPosition
                 + this.StartPosition.Value)) * distanceFromLoadStartPosition / 2;
        }

        private double CalculateBendingMomentOutsideLoadLength(double distanceFromLoadStartPosition)
        {
            double bendingMoment = 0;

            bendingMoment += this.StartPosition.Value *
                this.Length / 2 *
                (distanceFromLoadStartPosition - this.Length * 1 / 3);
            bendingMoment += this.EndPosition.Value *
                this.Length / 2 *
               (distanceFromLoadStartPosition - this.Length * 2 / 3);
            return bendingMoment;
        }

        private double CalculateBendingMomentInsideLoadLength(double distanceFromLoadStartPosition)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(distanceFromLoadStartPosition);
            double bendingMoment = 0;

            bendingMoment += this.StartPosition.Value *
               distanceFromLoadStartPosition / 2 *
               distanceFromLoadStartPosition * 2 / 3;
            bendingMoment += forceAtX *
                distanceFromLoadStartPosition / 2 *
                distanceFromLoadStartPosition * 1 / 3;

            return bendingMoment;

        }

        private double GetForceAtTheCalculatedPoint(double distanceFromLoadStartPosition)
            => (this.EndPosition.Value - this.StartPosition.Value) /
               this.Length *
               distanceFromLoadStartPosition +
               this.StartPosition.Value;
    }
}
