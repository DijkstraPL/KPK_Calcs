using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators.Interfaces
{
    public interface ICalculator
    {
        #region Properties

        string Description { get; }
        IResult Result { get; }

        #endregion // Properties

        #region Public_Methods

        void Map(IList<object> args);
        IResult Calculate();

        #endregion // Public_Methods
    }
}
