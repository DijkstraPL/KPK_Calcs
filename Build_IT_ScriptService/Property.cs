using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptService
{
    public abstract class Property
    {
        public Type Type { get; }

        public Property(Type type)
        {
            Type = type;
        }

        internal abstract void SetValue(object value);
    }

    public class Property<T> : Property
    {
        public T Value { get; private set; }
        public int OrderNumber { get; }
        public string Name { get; }

        private readonly Func<string, T> _toType;

        public Property(int orderNumber, string name,
            Func<string, T> toType) : base(typeof(T))
        {
            OrderNumber = orderNumber;
            Name = name;
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
