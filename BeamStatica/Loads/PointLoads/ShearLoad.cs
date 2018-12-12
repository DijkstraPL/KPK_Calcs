using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public class ShearLoad : SpanConcentratedLoad
    {
        /// <summary>
        /// Use in node loads.
        /// </summary>
        /// <param name="value">kN</param>
        public ShearLoad(double value) : base(value) 
        {
        }

        /// <summary>
        /// Use in span loads.
        /// </summary>
        /// <param name="value">kN</param>
        /// <param name="position">m</param>
        public ShearLoad(double value, double position) : base(value, position)
        {
        }
        
        public override double CalculateShear() 
            => this.Value;

        public override double CalculateBendingMoment(double distanceFromLoad) 
            => this.Value * distanceFromLoad;

        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : span.Length - this.Position;
            double distanceFromOtherNode = leftNode ? span.Length - this.Position : this.Position;
            return (-this.Value * Math.Pow(distanceFromOtherNode, 2) *
                (3 * distanceFromCloserNode + distanceFromOtherNode)) /
                Math.Pow(span.Length, 3);
        }

        public override double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            double distanceFromCloserNode = leftNode ? this.Position : span.Length - this.Position;
            double distanceFromOtherNode = leftNode ? span.Length - this.Position : this.Position;
            return sign * (-this.Value * distanceFromCloserNode * Math.Pow(distanceFromOtherNode, 2)) / Math.Pow(span.Length, 2);
        }
    }
}
