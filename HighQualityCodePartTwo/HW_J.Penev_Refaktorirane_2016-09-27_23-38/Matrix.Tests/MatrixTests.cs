using System;
using NUnit.Framework;
using MatrixBuilder;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void ArrayOperations_CreateArray_MustReturnProperlySizeArray(int arraySize)
        {
            int[,] matrix = new int[arraySize, arraySize];

            ArrayOperations.MakeSpiralMatrix(matrix);

            Assert.AreEqual(arraySize, matrix.GetLength(0));
            Assert.AreEqual(arraySize, matrix.GetLength(1));
        }

        [TestCase(3, "1 2 3 4 5 6 7 8 9")]
        [TestCase(4, "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16")]
        public void ArrayOperations_Print_MustReturnProperlySizeArray(int arraySize, string arrayElements)
        {
            int[,] matrix = new int[arraySize, arraySize];
            List<int> elements = arrayElements.Split(' ').Select(int.Parse).ToList();
            int currentElement = 0;

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    matrix[i, j] = elements[currentElement];
                    currentElement++;
                }
            }

            string output = ArrayOperations.Print(matrix);

            Assert.AreEqual(Regex.Replace(arrayElements, @"\s", ""), Regex.Replace(output, @"\s", ""));
        }
    }
}
