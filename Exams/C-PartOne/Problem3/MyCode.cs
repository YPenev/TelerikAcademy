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
        int d = int.Parse(Console.ReadLine());
        long digits = 0;
        int page =  1;
        int temp;
        int diggitOfPage = 0;

        while (digits != d)
        {
            temp = page;

            while (temp!=0)
            {
                diggitOfPage++;
                temp /= 10;
            }
            digits = digits + diggitOfPage;
            diggitOfPage = 0;
            page++;
        }


        Console.WriteLine(page-1);
    }
} 
