using System;
using System.Numerics;

class Solution
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();
        string thirdLine = Console.ReadLine();
        BigInteger firstResult = 0;
        BigInteger secondResult = 0;

        try
        {
            for (int i = 0; i < firstLine.Length; i++)
            {
                firstResult = (firstResult * 26) + (char.ToLower(firstLine[i]) - 'a');
            }
        }
        catch (Exception)
        {

            throw new Exception("Can not convert first result !");
        }

        try
        {
            for (int i = 0; i < thirdLine.Length; i++)
            {
                secondResult = (secondResult * 7) + (thirdLine[i] - '0');
            }
        }
        catch (Exception)
        {

            throw new Exception("Can not convert second result !");
        }

        BigInteger thirdResult = 0;

        if (secondLine == "+")
        {
            thirdResult = firstResult + secondResult;
        }
        else if (secondLine == "-")
        {
            thirdResult = firstResult - secondResult;
        }
        else
        {
            throw new ArgumentException("Invalid sign !");
        }

        string finalResult = string.Empty;

        while (thirdResult > 0)
        {
            finalResult = (thirdResult % 9) + finalResult;
            thirdResult /= 9;
        }

        Console.WriteLine(finalResult);
    }

}