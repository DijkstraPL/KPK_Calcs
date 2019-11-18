using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Data;
using Build_IT_BeamStatica.Factories;
using Build_IT_BeamStatica.Loads.Enums;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Results.OnSpan;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Data.Materials;
using Build_IT_Data.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_BeamStatica
{
    public class BeamCalculator
    {
        #region Properties

        public BeamData BeamData { get; set; }

        #endregion // Properties

        #region Constructors

        public BeamCalculator(BeamData beamData = null)
        {
            BeamData = beamData;
        }

        #endregion // Constructors

        #region Public_Methods

        public BeamCalculationResult Calculate()
        {
            var spans = new List<ISpan>();
            var nodes = new List<INode>();

            foreach (var spanData in BeamData.SpanDatas)
            {
                Material material = SetMaterial(spanData);
                Section section = SetSection(spanData);

                INode leftNode = SetLeftNode(nodes, spanData);
                INode rightNode = SetRightNode(nodes, spanData);

                var span = SpanFactory.Create(
                    leftNode, spanData.Length, rightNode, material, section);
                spans.Add(span);

                SetContinousLoads(spanData, span);
                SetPointLoads(spanData, leftNode, rightNode, span);
            }

            var beam = BeamFactory.Create(spans, nodes);
            beam.CalculationEngine.Calculate();

            var resultsContainer = new ResultsContainer(beam);
            return new BeamCalculationResult(resultsContainer);
        }

        #endregion // Public_Methods

        #region Private_Methods

        private Material SetMaterial(SpanData spanData)
            => new Material(
           spanData.MaterialData.YoungModulus,
           spanData.MaterialData.Density,
           spanData.MaterialData.ThermalExpansionCoefficient);

        private Section SetSection(SpanData spanData)
            => new Section(spanData.SectionPropertiesData.Points);

        private INode SetLeftNode(List<INode> nodes, SpanData spanData)
        {
            INode leftNode;
            if (nodes.Count == 0)
            {
                leftNode = NodeFactory.Create(spanData.LeftNode);
                nodes.Add(leftNode);
            }
            else
                leftNode = nodes.Last();
            return leftNode;
        }

        private INode SetRightNode(List<INode> nodes, SpanData spanData)
        {
            INode rightNode = NodeFactory.Create(spanData.RightNode);
            nodes.Add(rightNode);
            return rightNode;
        }

        private void SetContinousLoads(SpanData spanData, ISpan span)
        {
            foreach (var continousLoad in spanData.ContinuousLoads)
            {
                span.ContinousLoads.Add(
                    LoadFactory.CreateContinousLoad(
                        continousLoad.ContinuousLoadType,
                        span,
                        continousLoad.StartPosition,
                        continousLoad.StartValue,
                        continousLoad.EndPosition,
                        continousLoad.EndValue,
                        continousLoad.Angle));
            }
        }

        private void SetPointLoads(SpanData spanData, INode leftNode, INode rightNode, ISpan span)
        {
            foreach (var pointLoad in spanData.PointLoads)
            {
                var load = LoadFactory.CreatePointLoad(
                        pointLoad.PointLoadType,
                        pointLoad.Position,
                        pointLoad.Value,
                        pointLoad.Angle);

                if (pointLoad.PointLoadType == PointLoadType.HorizontalDisplacement ||
                    pointLoad.PointLoadType == PointLoadType.VerticalDisplacement ||
                    pointLoad.PointLoadType == PointLoadType.RotationDisplacement)
                {
                    if (pointLoad.Position < span.Length / 2)
                        leftNode.ConcentratedForces.Add(load);
                    else
                        rightNode.ConcentratedForces.Add(load);
                }
                else
                    span.PointLoads.Add(load);
            }
        }

        #endregion // Private_Methods
    }
}
