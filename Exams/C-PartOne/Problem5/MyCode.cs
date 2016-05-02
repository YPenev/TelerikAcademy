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
        uint N = uint.Parse(Console.ReadLine());
        uint l = uint.Parse(Console.ReadLine());
        uint j = 0;
        uint[] arr = new uint[l];
        uint result = 0;
        uint FinalCount = 0;
        
        for (uint i = 0; i < l; i++)
        {
            uint c = uint.Parse(Console.ReadLine());
            if ((N & c) == 0)
            {
                arr[j] = c;
                j++;
            }
        }
        for (uint i = 0; i < arr.Length; i++)
        {
            uint count = 0;
            uint temp = arr[i];
            while (arr[i] > 0)
            {
                count = count + 1;
                arr[i] = arr[i] & (arr[i] - 1);
            }

            if (count > FinalCount)
            {
                result = temp;
                FinalCount = count;
            }
        }
        Console.WriteLine(result);
    }
} 
