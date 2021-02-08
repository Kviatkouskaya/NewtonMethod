using System;

namespace NewtonMethod
{
    class RootCalculation
    {
        private readonly double number;
        private readonly double rootDegree;
        private double mathPow;
        private double Precision { get; }
        public RootCalculation()
        {
            Console.WriteLine("Enter number:");
            number = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree of the number:");
            rootDegree = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter specified precision:");
            Precision = double.Parse(Console.ReadLine());
        }
        public double CalculateRoot()
        {
            double root = number / rootDegree;
            double rn = number;
            while (Mabs(root - rn) >= Precision)
            {
                rn = number;
                for (int i = 1; i < rootDegree; i++)
                {
                    rn /= root;
                }
                root = (rn + root) / 2;
            }
            return root;

            static double Mabs(double x)
            {
                return (x < 0) ? -x : x;
            }
        }
        public bool CompareToMathPow(double resultRoot)
        {
            mathPow = Math.Pow(number, 1.0 / rootDegree);
            return resultRoot - mathPow < 0;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Finding n-th root of the number");
            RootCalculation calculation = new RootCalculation();
            double root = calculation.CalculateRoot();
            Console.WriteLine($"Root is: {root}");
            Console.WriteLine(calculation.CompareToMathPow(root));
        }
    }
}
