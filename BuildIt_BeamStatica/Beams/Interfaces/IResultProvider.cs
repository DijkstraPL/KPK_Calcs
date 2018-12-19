using Build_IT_BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Beams.Interfaces
{
    public interface IResultProvider
    {
        IGetResult NormalForceResult { get; }
        IGetResult ShearResult { get; }
        IGetResult BendingMomentResult { get; }
        IGetResult HorizontalDeflectionResult { get; }
        IGetResult VerticalDeflectionResult { get; }
        IGetResult RotationResult { get; }
    }
}
