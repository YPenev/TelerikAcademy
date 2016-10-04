using System;
using System.Numerics;
using System.Text;
using TaskTwo;

class Program
{
    private static Resourses playerResourses = new Resourses();
    private static int currentPosition = 0;
    private static string path;

    static void Main()
    {
        StartGame();
        PrintResult();
    }

    private static void StartGame()
    {
        path = Console.ReadLine();
        string[] comandsSplit = Console.ReadLine().Split(' ');
        long n = comandsSplit.Length;
        BigInteger[] comands = new BigInteger[n];
        char currentChar;

        for (int i = 0; i < n; i++)
        {
            comands[i] = int.Parse(comandsSplit[i]);
        }

        for (int i = 0; i <= n; i++)
        {

            currentChar = path[currentPosition];
            if (currentChar == '@')
            {
                OnAStep();
            }
            else if (currentChar == '*')
            {
                OnStarStep();
            }
            else if (currentChar == 'x')
            {
                OnXtep();
            }

            if (i < n)
            {
                MovePlayer(comands);
            }

        }
    }

    private static void MovePlayer(BigInteger[] comands)
    {
        if (comands[i] < 0)
        {
            currentPosition = (int)((currentPosition + comands[i]) % path.Length);
            if (currentPosition < 0)
            {
                currentPosition += path.Length;
            }
        }
        else
        {
            currentPosition = (int)((currentPosition + comands[i]) % path.Length);
        }
    }

    private static void OnStarStep()
    {
        playerResourses.Food++;
        StringBuilder sb = new StringBuilder(path);
        sb[currentPosition] = ' ';
        path = sb.ToString();
    }

    private static void OnAStep()
    {
        playerResourses.Souls++;
        StringBuilder sb = new StringBuilder(path);
        sb[currentPosition] = ' ';
        path = sb.ToString();
    }

    private static void OnXtep()
    {
        playerResourses.Deadlocks++;
        if (currentPosition % 2 == 0)
        {
            playerResourses.Souls--;
            if (playerResourses.Souls < 0)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", i);
                return;

            }

            StringBuilder sb = new StringBuilder(path);
            sb[currentPosition] = '@';
            path = sb.ToString();
        }
        else
        {
            playerResourses.Food--;
            if (playerResourses.Food < 0)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", i);
                return;
            }

            StringBuilder sb = new StringBuilder(path);
            sb[currentPosition] = '*';
            path = sb.ToString();

        }
    }

    private static void PrintResult()
    {
        Console.WriteLine("Coder souls collected: {0}", playerResourses.Souls);
        Console.WriteLine("Food collected: {0}", playerResourses.Food);
        Console.WriteLine("Deadlocks: {0}", playerResourses.Deadlocks);
    }
}