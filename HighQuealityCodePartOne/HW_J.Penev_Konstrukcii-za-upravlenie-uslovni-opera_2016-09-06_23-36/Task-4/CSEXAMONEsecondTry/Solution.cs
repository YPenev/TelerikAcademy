using System;

class Solution
{
    static void Main()
    {
        double birds = double.Parse(Console.ReadLine());
        double feathers = double.Parse(Console.ReadLine());
        double averageFeathers = feathers / birds;

        if (birds % 2 == 0)
        {
            averageFeathers *= 123123123123;
        }
        else
        {
            averageFeathers /= 317;
        }

        Console.WriteLine("{0:0.0000}", averageFeathers);
    }
}
