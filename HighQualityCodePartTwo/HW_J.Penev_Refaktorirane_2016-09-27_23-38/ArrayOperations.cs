using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixBuilder
{
    public static class ArrayOperations
    {
        public static void MakeSpiralMatrix(int[,] matrix)
        {
            int nextNumber = 1;
            int nextPositionToMoveX = 1; 
            int nextPositionToMoveY = 1; 
            int currentX = 0;
            int currentY = 0;

            FillArray(matrix, currentX, currentY, nextNumber, nextPositionToMoveX, nextPositionToMoveY, matrix.GetLength(0));
        }

        static bool IsThereFreeCellsCheck(int[,] array, int x, int y)
        {
            int[] xPossibleMoves = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] yPossibleMoves = { 1, 0, -1, -1, -1, 0, 1, 1 };

            // Проверява за кои стойности излиза от масива и ги маха
            for (int i = 0; i < 8; i++)
            {
                // Ако излиза от масива от ляво или отдясно
                if (x + xPossibleMoves[i] >= array.GetLength(0) || x + xPossibleMoves[i] < 0)
                {
                    xPossibleMoves[i] = 0;
                }
                // Ако излиза от масива от отгоре или отдолу
                if (y + yPossibleMoves[i] >= array.GetLength(0) || y + yPossibleMoves[i] < 0)
                {
                    yPossibleMoves[i] = 0;
                }
            }

            // Проверява дали има свободно място, т.е. елемент със тойнот 0
            for (int i = 0; i < 8; i++)
            {
                if (array[x + xPossibleMoves[i], y + yPossibleMoves[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void ChangeNextPossitionToMove(ref int dx, ref int dy)
        {
            int[] xPossibleMoves = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] yPossibleMoves = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int i = 0; i < 8; i++)
            {
                if (xPossibleMoves[i] == dx && yPossibleMoves[i] == dy)
                {
                    cd = i;
                    break;
                }
            }

            dx = xPossibleMoves[(cd + 1) % 8];
            dy = yPossibleMoves[(cd + 1) % 8];
        }

        static void FindZeroCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i; y = j;
                        return;
                    }
                }
            }
        }

        private static void FillArray(int[,] matrix, int currentX, int currentY, int nextNumber, int nextPositionToMoveX, int nextPositionToMoveY, int n)
        {
            while (true)
            { 
                matrix[currentX, currentY] = nextNumber;

                if (!IsThereFreeCellsCheck(matrix, currentX, currentY))
                {
                    break;
                }
                if (currentX + nextPositionToMoveX >= n || currentX + nextPositionToMoveX < 0 || currentY + nextPositionToMoveY >= n || currentY + nextPositionToMoveY < 0 || matrix[currentX + nextPositionToMoveX, currentY + nextPositionToMoveY] != 0)
                {
                    while ((currentX + nextPositionToMoveX >= n || currentX + nextPositionToMoveX < 0 || currentY + nextPositionToMoveY >= n || currentY + nextPositionToMoveY < 0 || matrix[currentX + nextPositionToMoveX, currentY + nextPositionToMoveY] != 0))
                    {
                        ChangeNextPossitionToMove(ref nextPositionToMoveX, ref nextPositionToMoveY);
                    }
                }

                currentX += nextPositionToMoveX;
                currentY += nextPositionToMoveY;
                nextNumber++;
            }
        }

        public static string Print(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(string.Format("{0,3}", matrix[i, j]));
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
