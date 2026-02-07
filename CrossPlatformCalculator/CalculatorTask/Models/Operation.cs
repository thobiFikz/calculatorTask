namespace CalculatorTask.Models
{
    public abstract class Operation
    {
        public abstract double Execute(double a, double b);
        public abstract string Symbol { get; }
    }

    public class Addition : Operation
    {
        public override double Execute(double a, double b) => a + b;
        public override string Symbol => "+";
    }

    public class Subtraction : Operation
    {
        public override double Execute(double a, double b) => a - b;
        public override string Symbol => "-";
    }

    public class Multiplication : Operation
    {
        public override double Execute(double a, double b) => a * b;
        public override string Symbol => "×";
    }

    public class Division : Operation
    {
        public override double Execute(double a, double b)
        {
            if (b == 0) throw new System.DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
        public override string Symbol => "÷";
    }
}
