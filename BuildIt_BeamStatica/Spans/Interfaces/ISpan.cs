using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ISpan : ILengthProvider, INodesProvider, ILoadProvider, ISpanCalculations
    {
        short Number { get; set; }
        ISection Section { get; }
        IMaterial Material { get; }
        IStiffnessMatrix StiffnessMatrix { get; }

        Vector<double> Forces { get; }
        Vector<double> LoadVector { get; }
    }
}
