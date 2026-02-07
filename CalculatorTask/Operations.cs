using System;

namespace CalculatorTask
{
    public class Addition : Operation
    {
        public override double Execute(double a, double b) => a + b;
        public override string Name => "Add";
    }

    public class Subtraction : Operation
    {
        public override double Execute(double a, double b) => a - b;
        public override string Name => "Subtract";
    }

    public class Multiplication : Operation
    {
        public override double Execute(double a, double b) => a * b;
        public override string Name => "Multiply";
    }

    public class Division : Operation
    {
        public override double Execute(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
        public override string Name => "Divide";
    }
}
