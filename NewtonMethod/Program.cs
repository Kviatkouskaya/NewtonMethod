using System;

namespace NewtonMethod
{
    class ValuesForRoot
    {
        public readonly double number;
        public readonly double rootDegree;
        public double Precision { get; }
        public ValuesForRoot(double number, double rootDegree, double precision) 
        {
            this.number = number;
            this.rootDegree = rootDegree;
            Precision = precision;
        }
        public double CalculateRoot()
        {

            double root = number /rootDegree;
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
            return resultRoot - mathPow < 0;
        }
    }
    class Program
    {
        private static ValuesForRoot InputValuesForCalculation()
        {
            Console.WriteLine("Finding n-th root of the number");
            Console.WriteLine("Enter number:");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree of the number:");
            double rootDegree = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter specified precision:");
            double precision = double.Parse(Console.ReadLine());
            return new ValuesForRoot(number, rootDegree, precision);
        }
        /*
        private static void PrintOutput(ValuesForRoot forRoot, double resultRoot)
        {

        }
        */
        static void Main()
        {
            ValuesForRoot calculation = InputValuesForCalculation();
            double resultRoot = calculation.CalculateRoot();
        }
    }
}
