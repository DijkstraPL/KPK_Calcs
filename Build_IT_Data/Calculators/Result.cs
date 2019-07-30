using Build_IT_Data.Calculators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators
{
    public class Result : IResult
    {
        #region Properties

        public object this[string name]
        {
            get => _properties[name];
            set
            {
                _properties[name] = value;
            }
        }

        public IDictionary<string, string> Descriptions { get; }

        #endregion // Properties

        #region Fields

        private IDictionary<string, object> _properties;

        #endregion // Fields

        #region Constructors

        public Result(IDictionary<string,string> properties)
        {
            _properties = new Dictionary<string, object>();
            foreach (var property in properties)
                _properties.Add(property.Key, default);

            Descriptions = properties;
        }

        #endregion // Constructors

        #region Public_Methods
        
        public IDictionary<string, object> GetProperties() => _properties;

        #endregion // Public_Methods
    }
}
