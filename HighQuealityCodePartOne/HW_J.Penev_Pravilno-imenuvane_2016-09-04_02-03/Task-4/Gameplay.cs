namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Minesweeper.Field;
    using static Minesweeper.MinesweeperGame;

    public static class Gameplay
    {
        private const int MaxScore = 35;
        private static string command = string.Empty;
        private static char[,] field = CreateField();
        private static char[,] bombsPossition = PlaceTheBombs();
        private static int currentScore = 0;
        private static bool isDeath = false;
        private static List<Result> highScores = new List<Result>(6);
        private static int selectedRow = 0;
        private static int selectedColumn = 0;
        private static bool isBeginningOfTheGame = true;
        private static bool isMaxPointsAchieved = false;

        public static void Start()
        {
            do
            {
                if (isBeginningOfTheGame)
                {
                    Console.WriteLine("Let's play Minesweeper. Try your luck and find a field without bomb." +
                    " The 'top' command show hightscores, 'restart' starts a new game, 'exit' stops the game");
                    PrintField(field);
                    isBeginningOfTheGame = false;
                }

                Console.Write("Please insert row and column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out selectedRow) &&
                    int.TryParse(command[2].ToString(), out selectedColumn) &&
                        selectedRow <= field.GetLength(0) && selectedColumn <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighScores(highScores);
                        break;
                    case "restart":
                        field = CreateField();
                        bombsPossition = PlaceTheBombs();
                        PrintField(field);
                        isDeath = false;
                        isBeginningOfTheGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombsPossition[selectedRow, selectedColumn] != '*')
                        {
                            if (bombsPossition[selectedRow, selectedColumn] == '-')
                            {
                                NextTurn(field, bombsPossition, selectedRow, selectedColumn);
                                currentScore++;
                            }

                            if (MaxScore == currentScore)
                            {
                                isMaxPointsAchieved = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isDeath = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError ! Invalid command !\n");
                        break;
                }

                if (isDeath)
                {
                    PrintField(bombsPossition);
                    Console.Write("\nSorry you die with {0} points \nEnter your nickname: ", currentScore);
                    string niknejm = Console.ReadLine();
                    Result t = new Result(niknejm, currentScore);
                    if (highScores.Count < 5)
                    {
                        highScores.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Points < t.Points)
                            {
                                highScores.Insert(i, t);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((Result r1, Result r2) => r2.Name.CompareTo(r1.Name));
                    highScores.Sort((Result r1, Result r2) => r2.Points.CompareTo(r1.Points));
                    ShowHighScores(highScores);

                    field = CreateField();
                    bombsPossition = PlaceTheBombs();
                    currentScore = 0;
                    isDeath = false;
                    isBeginningOfTheGame = true;
                }

                if (isMaxPointsAchieved)
                {
                    Console.WriteLine("\nPerfect, you oppened 35 cells and WIN the game");
                    PrintField(bombsPossition);
                    Console.WriteLine("Please insert your name: ");
                    string imeee = Console.ReadLine();
                    Result to4kii = new Result(imeee, currentScore);
                    highScores.Add(to4kii);
                    ShowHighScores(highScores);
                    field = CreateField();
                    bombsPossition = PlaceTheBombs();
                    currentScore = 0;
                    isMaxPointsAchieved = false;
                    isBeginningOfTheGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Good bye :)");
            Console.Read();
        }

        private static void ShowHighScores(List<Result> scores)
        {
            if (scores.Count > 0)
            {
                Console.WriteLine("\nPoints :");

                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ranglist is empty !\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombsPossition, int selectedRow, int selectedColumn)
        {
            char numberOfNearlyBombs = ReturnTheNumberOfNearlyBombs(bombsPossition, selectedRow, selectedColumn);
            bombsPossition[selectedRow, selectedColumn] = numberOfNearlyBombs;
            field[selectedRow, selectedColumn] = numberOfNearlyBombs;
        }
    }
}
