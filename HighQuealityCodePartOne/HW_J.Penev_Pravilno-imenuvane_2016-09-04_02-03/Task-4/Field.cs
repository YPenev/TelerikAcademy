namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public static class Field
    {
        public static void PrintField(char[,] field)
        {
            int totalRows = field.GetLength(0);
            int totalColumns = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < totalRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < totalColumns; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public static char[,] CreateField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        public static char[,] PlaceTheBombs()
        {
            int totalRows = 5;
            int totalColumns = 10;

            char[,] field = new char[totalRows, totalColumns];

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> listOfRandomNumbers = new List<int>();
            while (listOfRandomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!listOfRandomNumbers.Contains(randomNumber))
                {
                    listOfRandomNumbers.Add(randomNumber);
                }
            }

            foreach (int randomNumber in listOfRandomNumbers)
            {
                int randomColumn = randomNumber / totalColumns;
                int randomRow = randomNumber % totalColumns;

                if (randomRow == 0 && randomNumber != 0)
                {
                    randomColumn--;
                    randomRow = totalColumns;
                }
                else
                {
                    randomRow++;
                }

                field[randomColumn, randomRow - 1] = '*';
            }

            return field;
        }

        public static void FillCellsWithNumberOfNearlyBombs(char[,] field)
        {
            int totalRows = field.GetLength(0);
            int totalColumns = field.GetLength(1);

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char numberOfNearlyBombs = ReturnTheNumberOfNearlyBombs(field, i, j);
                        field[i, j] = numberOfNearlyBombs;
                    }
                }
            }
        }

        public static char ReturnTheNumberOfNearlyBombs(char[,] field, int currentRow, int currentCollumn)
        {
            int numberOfNearlyBombs = 0;
            int fieldRows = field.GetLength(0);
            int fieldColumns = field.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (field[currentRow - 1, currentCollumn] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if (currentRow + 1 < fieldRows)
            {
                if (field[currentRow + 1, currentCollumn] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if (currentCollumn - 1 >= 0)
            {
                if (field[currentRow, currentCollumn - 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if (currentCollumn + 1 < fieldColumns)
            {
                if (field[currentRow, currentCollumn + 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCollumn - 1 >= 0))
            {
                if (field[currentRow - 1, currentCollumn - 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCollumn + 1 < fieldColumns))
            {
                if (field[currentRow - 1, currentCollumn + 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentCollumn - 1 >= 0))
            {
                if (field[currentRow + 1, currentCollumn - 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentCollumn + 1 < fieldColumns))
            {
                if (field[currentRow + 1, currentCollumn + 1] == '*')
                {
                    numberOfNearlyBombs++;
                }
            }

            return char.Parse(numberOfNearlyBombs.ToString());
        }
    }
}
