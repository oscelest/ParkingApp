using System;
using System.Diagnostics;
using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class EqualityCondition<T> {
        public Tag Tag { get; }
        public EqualityOperator Operator { get; }
        public T Value { get; }

        public EqualityCondition(Tag tag, EqualityOperator op, T value) {
            Tag = tag;
            Operator = op;
            Value = value;
        }

        public EqualityCondition(string tag, string op, string value) {
            Tag = Tag.Parse(tag);
            Operator = EqualityOperator.Parse(op);
            if (typeof(T) == typeof(int)) Value = (T) (object) int.Parse(value);
            else if (typeof(T) == typeof(bool)) Value = (T) (object) (value == "True");
            else Value = (T) (object) value;
        }

        public override string ToString() {
            return $"    {Tag} {Operator} {Value}";
        }
    }
}