using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOptimization
{
    class AdvancedMathComparator
    {
        private const int numberOftests = 100;

        public static string SqareRootComparator(string type)
        {
            double number = 0;

            switch (type)
            {
                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "double":
                    Convert.ChangeType(number, typeof(double));
                    break;

                case "decimal":
                    Convert.ChangeType(number, typeof(decimal));
                    break;

                default:
                    throw new ArgumentException("Invalid type !");
            }

            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

            number = rnd.Next(1, 1000);
            stopwatch.Start();

            for (int i = 0; i < numberOftests; i++)
            {
                number = Math.Sqrt(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string NaturalLogarithmComparator(string type)
        {
            double number = 0;

            switch (type)
            {
                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "double":
                    Convert.ChangeType(number, typeof(double));
                    break;

                case "decimal":
                    Convert.ChangeType(number, typeof(decimal));
                    break;

                default:
                    throw new ArgumentException("Invalid type !");
            }

            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

            number = rnd.Next(1, 1000);
            stopwatch.Start();

            for (int i = 0; i < numberOftests; i++)
            {
                number = Math.Log10(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string SinusComparator(string type)
        {
            double number = 0;

            switch (type)
            {
                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "double":
                    Convert.ChangeType(number, typeof(double));
                    break;

                case "decimal":
                    Convert.ChangeType(number, typeof(decimal));
                    break;

                default:
                    throw new ArgumentException("Invalid type !");
            }

            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

            number = rnd.Next(1, 1000);
            stopwatch.Start();

            for (int i = 0; i < numberOftests; i++)
            {
                number = Math.Sin(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }
    }
}
