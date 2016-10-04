using System;

class Solution
{
    static int size = int.Parse(Console.ReadLine());
    static string text = Console.ReadLine();
    static char ch = text[0];
    static int downBody = (size - 1) / 2;
    static int body = size / 3;
    static int wings = downBody;
    static int width = (3 * size);
    static int hight = body + downBody + wings;
    static int[,] picture = new int[(hight), (width)];
    static int currentLine;
    static int currentRow = size - wings - 1;

    static void Main()
    {
        DrawWings(size);

        picture[currentLine, (size + (size / 2) - 1)] = 1;
        picture[currentLine, (size + (size / 2) + 1)] = 1;

        DrawBody();
        DrawDownBody();

        // Print result on console
        for (int i = 0; i < hight; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (picture[i, j] == 1)
                {
                    Console.Write("{0}", ch);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }

    private static void DrawDownBody()
    {
        int startPossition = size + 1;
        int lenght = size - 2;

        for (int j = currentLine; j < currentLine + downBody; j++)
        {
            for (int i = startPossition; i < startPossition + lenght; i++)
            {
                picture[j, i] = 1;

            }

            startPossition++;
            lenght = lenght - 2;
        }
    }

    private static void DrawBody()
    {
        for (int j = currentLine + 1; j < currentLine + 1 + body; j++)
        {
            for (int i = currentRow; i < currentRow + (2 * size) + 1; i++)
            {
                picture[j, i] = 1;
            }
        }

        currentLine = currentLine + 1 + body;
    }

    private static void DrawWings(int givenLenght)
    {
        int startPossition = 0;
        int lenght = givenLenght;

        for (int j = 0; j < wings; j++)
        {
            for (int i = startPossition; i < startPossition + lenght; i++)
            {
                picture[j, i] = 1;

            }

            startPossition++;
            lenght--;
        }

        startPossition = (2 * givenLenght);
        lenght = givenLenght;

        for (int j = 0; j < wings; j++)
        {
            for (int i = startPossition; i < startPossition + lenght; i++)
            {
                picture[j, i] = 1;

            }
            lenght--;
            currentLine = j;
        }
    }
}
