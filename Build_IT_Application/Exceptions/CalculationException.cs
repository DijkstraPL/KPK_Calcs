using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Exceptions
{
    public class CalculationException : Exception
    {
        #region Properties

        public long ScriptId { get; }

        #endregion // Properties

        #region Constructors

        public CalculationException(long scriptId, string message = null)
            : base(message)
        {
            ScriptId = scriptId;
        }

        public CalculationException(long scriptId, string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion // Constructors
    }
}
