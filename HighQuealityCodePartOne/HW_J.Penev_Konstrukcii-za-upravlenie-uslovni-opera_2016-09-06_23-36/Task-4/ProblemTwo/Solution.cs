using System;

class Solution
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        uint combsCount = uint.Parse(Console.ReadLine());
        uint j = 0;
        uint[] arr = new uint[combsCount];
        uint result = 0;
        uint FinalCount = 0;

        for (uint i = 0; i < combsCount; i++)
        {
            uint comb = uint.Parse(Console.ReadLine());
            if ((number & comb) == 0)
            {
                arr[j] = comb;
                j++;
            }
        }

        for (uint i = 0; i < arr.Length; i++)
        {
            uint count = 0;
            uint teeth = arr[i];

            while (arr[i] > 0)
            {
                count = count + 1;
                arr[i] = arr[i] & (arr[i] - 1);
            }

            if (count > FinalCount)
            {
                result = teeth;
                FinalCount = count;
            }
        }

        Console.WriteLine(result);
    }
}