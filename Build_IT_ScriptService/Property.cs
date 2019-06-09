using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptService
{
    public abstract class Property
    {
        #region Properties
        
        public string Name { get; }
        public Type Type { get; }
        public bool HasValue { get; protected set; }

        #endregion // Properties

        #region Constructors
        
        public Property(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        #endregion // Constructors

        #region Internal_Methods
        
        internal abstract void SetValue(object value);

        #endregion // Internal_Methods
    }

    public class Property<T> : Property
    {
        #region Properties
        
        private T _value;
        public T Value
        {
            get => _value;
            private set
            {
                _value = value;
                HasValue = true;
            }
        }

        #endregion // Properties

        #region Fields
        
        private readonly Func<string, T> _toType;

        #endregion // Fields

        #region Constructors
        
        public Property(string name, Func<string, T> toType)
            : base(name, typeof(T))
        {
            _toType = toType;
        }
        
        #endregion // Constructors

        #region Internal_Methods
        
        internal override void SetValue(object value)
        {
            Value = _toType(value.ToString());
        }

        internal void SetValue(T value)
        {
            Value = value;
        }

        #endregion // Internal_Methods
    }
}
