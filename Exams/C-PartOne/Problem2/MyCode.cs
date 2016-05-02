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
        int c = int.Parse(Console.ReadLine());
        int[] buses = new int[c];
        int groups = 1;

        for (int i = 0; i < c; i++)
        {
            buses[i] = int.Parse(Console.ReadLine());
        }



        for (int i = 0; i < c - 1; i++)
        {

            if (buses[i] < buses[i + 1])
            {
                while (buses[i] < buses[i + 1])
                {
                    buses[i + 1] = buses[i];
                    i++;
                    if (i == c-1)
                    {
                        Console.WriteLine(groups);
                        return;
                    }
                }
                groups++;
            }
            else 
            {
                groups++;
            }
        }
        Console.WriteLine(groups);
    }
}
