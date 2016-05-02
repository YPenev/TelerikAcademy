using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        double B = double.Parse(Console.ReadLine());
        double F = double.Parse(Console.ReadLine());
        double avgF = F / B;
        

        if (B % 2 == 0)
        {
            avgF *= 123123123123;
        }
        else
        {
            avgF /= 317;
        }

        Console.WriteLine("{0:0.0000}",avgF);
    }
} 
