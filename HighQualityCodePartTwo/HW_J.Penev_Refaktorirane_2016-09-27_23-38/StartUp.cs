using System;

namespace MatrixBuilder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int matrixSize = 3;
            int[,] matrix = new int[matrixSize, matrixSize];

            ArrayOperations.MakeSpiralMatrix(matrix);
            Console.WriteLine(ArrayOperations.Print(matrix)); 
        }
    }
}
