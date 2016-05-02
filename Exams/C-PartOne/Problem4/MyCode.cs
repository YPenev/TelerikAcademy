using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static int l = int.Parse(Console.ReadLine());
    static string text = Console.ReadLine();
    static char ch = text[0];
    static int opashka = (l - 1) / 2;
    static int tqlo = l/3;
    static int krila = opashka;
    static int shirochina = (3 * l);
    static int visochina = tqlo + opashka + krila;
    static int[,] arr = new int[(visochina), (shirochina)];
    static int currentLine;
    static int currentRow = l - krila - 1;

    static void Main()
    {


        Printkrila(l);
        arr[currentLine, (l + (l / 2) - 1)] = 1;
        arr[currentLine, (l + (l / 2) + 1)] = 1;



        PrintTqlo();
        PrintOpashka();


        for (int i = 0; i < visochina; i++)
        {
            for (int j = 0; j < shirochina; j++)
            {
                if (arr[i, j] == 1)
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

    private static void PrintOpashka()
    {
        int start = l + 1;
        int lenght = l - 2;
        for (int j = currentLine; j < currentLine + opashka; j++)
        {
            for (int i = start; i < start + lenght; i++)
            {
                arr[j, i] = 1;

            }
            start++;
            lenght = lenght - 2;
        }
    }

    private static void PrintTqlo()
    {
        for (int j = currentLine + 1; j < currentLine + 1 + tqlo; j++)
        {
            for (int i = currentRow; i < currentRow + (2 * l) + 1; i++)
            {
                arr[j, i] = 1;
            }
        }
        currentLine = currentLine + 1 + tqlo;
    }



    private static void Printkrila(int l)
    {
        int start = 0;
        int lenght = l;
        for (int j = 0; j < krila; j++)
        {
            for (int i = start; i < start + lenght; i++)
            {
                arr[j, i] = 1;

            }
            start++;
            lenght--;
        }
        start = (2 * l);
        lenght = l;
        for (int j = 0; j < krila; j++)
        {
            for (int i = start; i < start + lenght; i++)
            {
                arr[j, i] = 1;

            }
            lenght--;
            currentLine = j;
        }

    }
}
