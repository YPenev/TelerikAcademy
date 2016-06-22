using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkThree
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = index; i < index + length; i++)
            {
                result.Append(sb[i]);
            }

            return result;
        }

        public static T MySum<T>(this IEnumerable<T> collection)
        where T : struct, IConvertible
        {
            T sum = default(T);

            foreach (var number in collection)
            {
                sum += (dynamic)number;
            }

            return sum;
        }

        public static T MyProduct<T>(this IEnumerable<T> collection)
            where T : struct, IConvertible
        {
            T product = default(T) + (dynamic)1;

            foreach (var number in collection)
            {
                product *= (dynamic)number;
            }

            return product;
        }

        public static T MyAverage<T>(this IEnumerable<T> collection)
            where T : struct, IConvertible
        {
            T average = default(T);
            int length = 0;

            foreach (var number in collection)
            {
                average += (dynamic)number;
                length++;
            }

            return (dynamic)average / length;
        }

        public static T MyMax<T>(this IEnumerable<T> collection)
            where T : struct, IConvertible
        {
            T max = (dynamic)collection.ElementAt(0);

            foreach (var number in collection)
            {
                if ((dynamic)number > max)
                {
                    max = number;
                }
            }

            return max;
        }

        public static T MyMin<T>(this IEnumerable<T> collection)
            where T : struct, IConvertible
        {
            T min = (dynamic)collection.ElementAt(0);

            foreach (var number in collection)
            {
                if ((dynamic)number < min)
                {
                    min = number;
                }
            }

            return min;
        }


        public static Student[] OrderByLambda(this Student[] array)
        {
            Student[] ordered = array.OrderBy(st => st.FirstName).ThenBy(st => st.LastName).ToArray();
            return ordered;
        }

        public static Student[] ThenByLambda(this Student[] array)
        {
            Student[] ordered = array.OrderBy(st => st.FirstName).ThenBy(st => st.LastName).ToArray();
            Array.Reverse(ordered);
            return ordered;
        }

        public static Student[] OrderByLINQ(this Student[] array)
        {
            Student[] ordered =
                (from st in array
                 orderby st.FirstName
                 orderby st.LastName
                 select st).ToArray();
            return ordered;
        }

        public static Student[] ThenByLINQ(this Student[] array)
        {
            Student[] ordered =
                (from st in array
                 orderby st.FirstName
                 orderby st.LastName
                 select st).ToArray();
            Array.Reverse(ordered);
            return ordered;
        }

        public static Student[] IsFirstNameBeforeLastName(this Student[] array)
        {
            Student[] ordered =
                (from st in array
                 where (st.FirstName[0] < st.LastName[0])
                 select st).ToArray();
            Array.Reverse(ordered);
            return ordered;
        }

        public static Student[] AgeBetween(this Student[] array)
        {
            Student[] ordered =
                (from st in array
                 where (st.Age > 18 && st.Age < 24)
                 select st).ToArray();
            Array.Reverse(ordered);
            return ordered;
        }

        public static int[] DevisibleLambda(this int[] array)
        {
            List<int> newArray = array.ToList();
            var ordered = newArray.FindAll(number => (number % 3) == 0 || (number % 7) == 0);  // Is it Working ?

            return ordered.ToArray();
        }

        public static int[] DevisibleLINQ(this int[] array)                      // Is it Working ?
        {
            int[] ordered =
                (from num in array
                 where num % 7 == 0 || num % 3 == 0
                 select num).ToArray();
            return ordered;
        }

        public static string LongestString(this string theString)                      // Is it Working ?
        {
            var words = theString.Split(' ');
            string LongestString = words.OrderByDescending(s => s.Length).First();
            return LongestString;
        }

        public static void OrderByGroupNumber(this Student[] array)
        {
            Student[] ordered =
                (from st in array
                 orderby st.GroupNumber
                 select st).ToArray();

            Console.WriteLine();
            Console.WriteLine("Student ordered by group number:");
            foreach (var student in ordered)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }
        }

    }
}
