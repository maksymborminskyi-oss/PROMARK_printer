using System;

namespace UI_HRX
{
    public enum DateOffsetUnit
    {
        Sec,
        Min,
        Hour,
        Day,
        Month,
        Year
    }

    public class PrinterVariable
    {
        public string Name { get; }
        public string Value { get; }
        public DateOffsetUnit? Unit { get; }

        public PrinterVariable(string name, string value, DateOffsetUnit? unit = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва змінної не може бути порожньою.", nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Значення змінної не може бути null.");

            Name = name.Trim();
            Value = value;
            Unit = unit;
        }
    }
}
