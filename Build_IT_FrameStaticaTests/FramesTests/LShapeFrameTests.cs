using Build_IT_FrameStatica.Nodes.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Build_IT_FrameStatica.Spans;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Nodes;

namespace Build_IT_FrameStaticaTests.FramesTests
{
    [TestFixture]
    public class LShapeFrameTests
    {
        //private Frame _frame;

        //[SetUp]
        //public void SetUpBeam()
        //{
        //    var material = new Material(youngModulus: 200);
        //    var section = new Section(area: 600, momentOfInteria: 6000);

        //    var node1 = new PinNode(0,0);
        //    var node2 = new FreeNode(6,0);
        //    var node3 = new FixedNode(6,-6);

        //    var nodes = new Node[] { node1, node2, node3 };

        //    var span1 = new Span(
        //        leftNode: node1,
        //        rightNode: node2,
        //        material: material,
        //        section: section
        //        );

        //    var span2 = new Span(
        //        leftNode: node2,
        //        rightNode: node3,
        //        material: material,
        //        section: section
        //        );
            
        //    var spans = new Span[] { span1, span2 };

        //    node2.ConcentratedForces.Add(new HorizontalLoad(value: 50));
            
        //    _frame = new Frame(spans, nodes);

        //    _frame.CalculationEngine.Calculate();
        //}
    }
}
