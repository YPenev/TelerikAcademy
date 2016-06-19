namespace OOPHomeworkTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Start
    {
        public static void Main()
        {
            //Crating 3 test points
            Point3D first = new Point3D(0, 1, 2);
            Point3D second = new Point3D(4, 5, 8);
            Point3D StartPoint = Point3D.Start;

            //Show distance
            Console.WriteLine("Distance between point \"first\" and point \"second\" is :");
            Console.WriteLine(Distance.Lenght(first, second));

            //Creating list of points
            Path PathTestOne = new Path();
            PathTestOne.Add(first);
            PathTestOne.Add(second);
            PathTestOne.Add(StartPoint);

            Path PathTestTwo = new Path();
            PathTestOne.Add(second);
            PathTestOne.Add(first);
            PathTestOne.Add(second);


            PathStorage.WriteInFile(PathTestOne);  //Write them in file
            PathStorage.ReadFromFile();         //Print them from file

            Console.WriteLine("--------------------");

            //Create generic class for two ints
            var GenListTest = new GenericList<int>(2);
            GenListTest.Add(5);
            GenListTest.Add(2);
            GenListTest.Add(8);
            Console.WriteLine(GenListTest.ToString());
            GenListTest.InsertAtIndex(10, 0);               //Inserting 10 at index 0
            Console.WriteLine(GenListTest.ToString());
            Console.WriteLine(GenListTest.TakeAtIndex(0)); //Printing element at position 0
            GenListTest.RemoveAtIndex(2);                  //Removing item at index 2
            Console.WriteLine(GenListTest.ToString());
            Console.WriteLine(GenListTest.Find(8));        //Find index of 8
            Console.WriteLine(GenListTest.Max<int>());     //Find maximal element
            Console.WriteLine(GenListTest.Min<int>());     //Find minimal element
            GenListTest.Clear();                           //Clear the array
            Console.WriteLine(GenListTest.ToString());
            Console.WriteLine("------------------------------");

            var testMatrixOne = new Matrix<double>(2, 2);  //Creating matrix for tests
            testMatrixOne[0, 0] = 1;
            testMatrixOne[0, 1] = 2;
            testMatrixOne[1, 0] = 3;
            testMatrixOne[1, 1] = 4;
            testMatrixOne.PrintMatrix();

            var testMatrixTwo = new Matrix<double>(2, 2); //Creating matrix for tests
            testMatrixTwo[0, 0] = 5;
            testMatrixTwo[0, 1] = 3;
            testMatrixTwo[1, 0] = 1;
            testMatrixTwo[1, 1] = 4;
            testMatrixTwo.PrintMatrix();

            var resultMatrix = new Matrix<double>(2, 2);
            resultMatrix = testMatrixTwo + testMatrixOne;  //Test +
            resultMatrix.PrintMatrix();


            resultMatrix = testMatrixOne -testMatrixTwo;  //Test -
            resultMatrix.PrintMatrix();

            resultMatrix = testMatrixOne * testMatrixTwo;  //Test *
            resultMatrix.PrintMatrix();

            Console.WriteLine(testMatrixOne.IsNonZero());  //Test IsNonZeroMethod

            AtributeTest.Test();                          //Testing atributes

        }
    }
}
