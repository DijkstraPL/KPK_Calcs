using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStatica.Results.OnSpan
{
    internal abstract class Result : IGetResult
    {
        protected const double tick = 100;

        public ICollection<IResultValue> Values { get; private set; }
        protected IList<ISpan> Spans { get; }
        protected IBeam Beam { get; }

        protected Result(IBeam beam)
        {
            Beam = beam ?? throw new ArgumentNullException(nameof(beam));
            Spans = beam.Spans;
        }

        public void SetValues()
        {
            Values = new List<IResultValue>();

            for (int i = 0; i < Spans.Sum(s => s.Length) * tick; i++)
                Values.Add(CalculateAtPosition(i / tick));
        }

        public IResultValue GetMaxValue(double startPosition = 0, double? endPosition = null)
        {
            CheckValuesIfNeeded();
            var filteredValues = SetFilteredValues(startPosition, endPosition);

            var maxValue = filteredValues.Max(v => v.Value);

            return filteredValues.FirstOrDefault(r => r.Value == maxValue);
        }

        public IResultValue GetMinValue(double startPosition = 0, double? endPosition = null)
        {
            CheckValuesIfNeeded();
            var filteredValues = SetFilteredValues(startPosition, endPosition);

            var minValue = filteredValues.Min(v => v.Value);

            return filteredValues.FirstOrDefault(r => r.Value == minValue);
        }

        private IEnumerable<IResultValue> SetFilteredValues(double startPosition, double? endPosition)
        {
            if (startPosition == 0 && endPosition == null)
                return Values;
            return Values.Where(r => r.Position >= startPosition && r.Position <= endPosition);
        }

        private void CheckValuesIfNeeded()
        {
            if (Values == null)
                SetValues();
        }

        public IResultValue GetValue(double distanceFromLeftSide)
            => CalculateAtPosition(distanceFromLeftSide);

        protected abstract IResultValue CalculateAtPosition(double distanceFromLeftSide);
    }
}
