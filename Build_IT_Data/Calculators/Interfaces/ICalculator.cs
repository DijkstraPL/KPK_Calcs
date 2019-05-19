using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators.Interfaces
{
    public interface ICalculator
    {
        IDictionary<string, object> Properties { get; }

        void Map(object[] args);
        object Calculate();
    }
}
