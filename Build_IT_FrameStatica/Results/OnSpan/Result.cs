using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal abstract class Result : IGetResult
    {
        #region Properties

        public ICollection<IResultValue> Values { get; private set; }
        protected IList<ISpan> Spans { get; }
        protected IFrame Frame { get; }

        #endregion // Properties

        #region Fields

        protected const double tick = 100;

        #endregion // Fields

        #region Constructors

        protected Result(IFrame frame)
        {
            Frame = frame ?? throw new ArgumentNullException(nameof(frame));
            Spans = frame.Spans;
        }

        #endregion // Constructors

        #region Public_Methods

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

        public IResultValue GetValue(double distanceFromLeftSide)
            => CalculateAtPosition(distanceFromLeftSide);

        #endregion // Public_Methods

        #region Protected_Methods

        protected abstract IResultValue CalculateAtPosition(double distanceFromLeftSide);

        #endregion // Protected_Methods

        #region Private_Methods

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

        #endregion // Private_Methods
    }
}
