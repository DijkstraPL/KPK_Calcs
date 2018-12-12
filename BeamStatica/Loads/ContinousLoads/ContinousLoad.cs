using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads
{
    public abstract class ContinousLoad : IContinousLoad
    {
        public ILoadWithPosition StartPosition { get; }
        public ILoadWithPosition EndPosition { get; }
        public double Length => EndPosition.Position - StartPosition.Position;

        protected ContinousLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition)
        {
            StartPosition = startPosition ?? throw new ArgumentNullException(nameof(startPosition));
            EndPosition = endPosition ?? throw new ArgumentNullException(nameof(endPosition));
        }

        public virtual double CalculateNormalForce(double distanceFromLoadStartPosition) => 0;
        public virtual double CalculateShear(double distanceFromLoadStartPosition) => 0;
        public virtual double CalculateBendingMoment(double distanceFromLoadStartPosition) => 0;
        
        public virtual double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode) => 0;
        public virtual double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode) => 0;
        public virtual double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode) => 0;
    }
}
