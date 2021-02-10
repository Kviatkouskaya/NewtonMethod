using System;

namespace NewtonMethod
{
    class RootCalculation
    {
        private readonly double number;
        private readonly int rootDegree;
        private double Precision { get; }
        public RootCalculation(double number, int rootDegree, double precis)
        {
            this.number = number;
            this.rootDegree = rootDegree;
            Precision = precis;
        }
        public double CalculateRoot()
        {
            double root = number / rootDegree;
            double rn = number;
            while (Math.Abs(root - rn) >= Precision)
            {
                rn = number;
                for (int i = 1; i < rootDegree; i++)
                {
                    rn /= root;
                }
                root = (rn + root) / 2;
            }
            return root;
        }
        public bool CompareToStandart(double resultRoot)
        {
            double mathPow = Math.Pow(number, 1 / rootDegree);
            return resultRoot - mathPow == 0;
        }
        public override bool Equals(object obj)
        {
            RootCalculation values = (RootCalculation)obj;
            return (values.number == number &&
                    values.rootDegree == rootDegree &&
                    values.Precision == Precision);
        }
        public override int GetHashCode()
        {
            return (int)number + rootDegree;
        }
    }
    class Program
    {
        private static RootCalculation InputValuesForCalculation()
        {
            Console.WriteLine("Finding n-th root of the number");
            Console.WriteLine("Enter number:");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree of the number:");
            int rootDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter specified precision:");
            double precision = double.Parse(Console.ReadLine());
            return new RootCalculation(number, rootDegree, precision);
        }
        private static void PrintOutput(RootCalculation forRoot)
        {
                double resultRoot = forRoot.CalculateRoot();
                Console.WriteLine($"Root is: {resultRoot}");
                Console.WriteLine(forRoot.CompareToStandart(resultRoot));
        }
        static void Main()
        {
            RootCalculation calculation = InputValuesForCalculation();
            PrintOutput(calculation);
        }
    }
}
