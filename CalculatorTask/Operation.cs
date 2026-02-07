using System;

namespace CalculatorTask
{
    public abstract class Operation
    {
        public abstract double Execute(double a, double b);
        public abstract string Name { get; }
    }
}
