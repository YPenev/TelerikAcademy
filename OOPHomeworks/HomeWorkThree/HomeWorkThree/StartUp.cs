using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkThree
{
    class StartUp
    {
        static void Main()
        {
            StringBuilderSubstring();   // Problem 1
            IEnumerablExtensionsTest(); // Problem 2
            StudentsArrayTest();        // Problems 3, 4 , 5
            IntArrayTest();             // Problem 6
            ExtraxtStudentTest();       //Problems 9 - 19
            LongestStringTest();        // Problem 17
            TimerTest();                // Problem 7


        }

        private static void LongestStringTest()
        {
            Console.WriteLine();
            Console.WriteLine("Longest string test:");
            string testString = "This is simple text";
            Console.WriteLine(testString.LongestString());
        }

        private static void IEnumerablExtensionsTest()
        {
            var list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(10);

            Console.WriteLine();
            Console.WriteLine("IEnumerabl Extensions Test with numbers: 5, 1, 10");
            Console.WriteLine("Sum: " + list.MySum());
            Console.WriteLine("Product: " + list.MyProduct());
            Console.WriteLine("Average: " + list.MyAverage());
            Console.WriteLine("Min: " + list.MyMin());
            Console.WriteLine("Max: " + list.MyMax());
            Console.WriteLine();
        }

        private static void StringBuilderSubstring()
        {
            Console.WriteLine("StringBuilder substring test: ");
            var sb = new StringBuilder("123456");
            sb = sb.Substring(1, 3);
            Console.WriteLine(sb);
        }

        private static void TimerTest()
        {
            Timer.Alarm d;
            d = Timer.SayBeep;
            d(7);
        }

        private static void ExtraxtStudentTest()
        {
            Console.WriteLine();

            var ListOfStudent = new List<Student>();
            ListOfStudent.Add(new Student("Tisho", "Goshow", 19, "492805062", "0208414", "admin@hotmail.com", 2));
            ListOfStudent.Add(new Student("Pesho", "Goshow", 19, "192085752", "088808414", "admin@abv.bg", 1));
            ListOfStudent.Add(new Student("Avram", "Goshow", 19, "290285752", "088808414", "admin@gmail.com", 2));
            ListOfStudent.Add(new Student("Kolio", "Goshow", 19, "920285062", "0258414", "admin@abv.bg", 3));
            ListOfStudent[0].AddMark(6);
            ListOfStudent[0].AddMark(2);
            ListOfStudent[1].AddMark(2);
            ListOfStudent[1].AddMark(2);
            ListOfStudent[2].AddMark(5);
            ListOfStudent[3].AddMark(2);
            ListOfStudent[3].AddMark(6);
            ListOfStudent[3].AddMark(3);


            Console.WriteLine("Student from second group:");
            var groupTwo =
               (from st in ListOfStudent
                where st.GroupNumber == 2
                orderby st.FirstName
                select st);

            foreach (var st in groupTwo)
            {
                Console.WriteLine(st.FirstName + "  " + st.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students with mail in abv:");
            var abvMail =
             (from st in ListOfStudent
              where st.Email.Contains("abv.bg")
              orderby st.FirstName
              select st);

            foreach (var st in abvMail)
            {
                Console.WriteLine(st.FirstName + "  " + st.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students with phones in Sofia:");
            var sofiaTel =
             (from st in ListOfStudent
              where st.Tel[0] == '0' && st.Tel[1] == '2'
              orderby st.FirstName
              select st);

            foreach (var st in sofiaTel)
            {
                Console.WriteLine(st.FirstName + "  " + st.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("All with mark 6:");
            var markSix =
             (from st in ListOfStudent
              where st.Marks.Contains(6)
              select st);                             

            foreach (var st in markSix)
            {
                Console.Write(st.FirstName + st.LastName + " Marks: ");
                for (int i = 0; i < st.Marks.Count; i++)
                {
                    Console.Write(st.Marks[i] + " ");
                };
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("All students with two marks:");
            var stWhithTwoMarks =
             (from st in ListOfStudent
              where st.Marks.Count == 2
              select st);

            foreach (var st in stWhithTwoMarks)
            {
                Console.WriteLine(st.FirstName + "  " + st.LastName);
            }


            Console.WriteLine();
            Console.WriteLine("All mark of the students that enrolled in 2006:");
            var mark2006 =
             (from st in ListOfStudent
              where st.FN[6] == '0' && st.FN[7] == '6'
              select st);

            foreach (var st in mark2006)
            {
                Console.Write(st.FirstName + "  -  ");
                for (int i = 0; i < st.Marks.Count; i++)
                {
                    Console.Write(st.Marks[i] + " ");
                };
                Console.WriteLine();
            }
        }

        private static void IntArrayTest()
        {
            Console.WriteLine();
            Console.WriteLine("IntArrayTest:");
            var intArray = new int[4];
            intArray[0] = 1;
            intArray[1] = 6;
            intArray[2] = 5;
            intArray[3] = 21;

            intArray = intArray.DevisibleLINQ();

            foreach (var num in intArray)
            {
                Console.WriteLine(num);
            }
        }

        private static void StudentsArrayTest()
        {
            Console.WriteLine();
            Console.WriteLine("Students age between 18 and 24 Test:");
            var studentsArray = new Student[4];
            studentsArray[3] = new Student("Avram", "Goshow", 19);
            studentsArray[1] = new Student("Avram", "Avramov", 18);
            studentsArray[0] = new Student("Pesho", "Goshow", 19);
            studentsArray[2] = new Student("Tisho", "Goshow", 25);

            var ageBetweenArray = studentsArray.AgeBetween();

            foreach (var student in ageBetweenArray)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students whose first name is before its last name alphabetically:");
            var firstBeforeLast = studentsArray.IsFirstNameBeforeLastName();
            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students ordered by name: (LINQ)");
            var ordered = studentsArray.OrderByLINQ();
            foreach (var student in ordered)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students ordered by name descending (LINQ):");
            var orderedD = studentsArray.ThenByLINQ();
            foreach (var student in orderedD)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students ordered by name: (Lambda)");
            var orderedL = studentsArray.OrderByLambda();
            foreach (var student in orderedL)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Students ordered by name descending (Lambda):");
            var orderedDL = studentsArray.ThenByLambda();
            foreach (var student in orderedDL)
            {
                Console.WriteLine(student.FirstName + "   " + student.LastName);
            }

            Console.WriteLine();
            studentsArray.OrderByGroupNumber(); // Student ordered by group number
        }
    }
}
