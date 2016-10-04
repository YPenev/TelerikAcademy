using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOptimization
{
    static class SimpleMathComparator
    {
        private const int numberOftests = 1000;

        public static string AddComparator(string type)
        {
            int number = 0;

            switch (type)
            {
                case "int":
                    Convert.ChangeType(number, typeof(int));
                    break;

                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "long":
                    Convert.ChangeType(number, typeof(long));
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
                number = number + number;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string SubtarctComparator(string type)
        {
            int number = 0;

            switch (type)
            {
                case "int":
                    Convert.ChangeType(number, typeof(int));
                    break;

                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "long":
                    Convert.ChangeType(number, typeof(long));
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
                number = number - number;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string IncrementComparator(string type)
        {
            int number = 0;

            switch (type)
            {
                case "int":
                    Convert.ChangeType(number, typeof(int));
                    break;

                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "long":
                    Convert.ChangeType(number, typeof(long));
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
                number++;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string MultiplyComparator(string type)
        {
            int number = 0;

            switch (type)
            {
                case "int":
                    Convert.ChangeType(number, typeof(int));
                    break;

                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "long":
                    Convert.ChangeType(number, typeof(long));
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
                number = number * number;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }

        public static string DivideComparator(string type)
        {
            int number = 0;

            switch (type)
            {
                case "int":
                    Convert.ChangeType(number, typeof(int));
                    break;

                case "float":
                    Convert.ChangeType(number, typeof(float));
                    break;

                case "long":
                    Convert.ChangeType(number, typeof(long));
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
                number = number / number;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.ToString();
        }
    }
}
