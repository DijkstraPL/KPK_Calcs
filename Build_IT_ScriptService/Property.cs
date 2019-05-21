using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptService
{
    public abstract class Property
    {
        public string Name { get; }
        public Type Type { get; }
        public bool HasValue { get; protected set; }

        public Property( string name, Type type)
        {
            Name = name;
            Type = type;
        }

        internal abstract void SetValue(object value);
    }

    public class Property<T> : Property
    {
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
        
        private readonly Func<string, T> _toType;

        public Property(string name, Func<string, T> toType) 
            : base(name, typeof(T))
        {
            _toType = toType;
        }

        internal override void SetValue(object value)
        {
            Value = _toType(value.ToString());
        }

        internal void SetValue(T value)
        {
            Value = value;
        }
    }
}
