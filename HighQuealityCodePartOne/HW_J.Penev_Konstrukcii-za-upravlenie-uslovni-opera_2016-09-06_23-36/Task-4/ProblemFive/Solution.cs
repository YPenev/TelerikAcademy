using System;

class Solution
{
    static void Main()
    {
        int numberOfBuses = int.Parse(Console.ReadLine());
        int[] buses = new int[numberOfBuses];

        for (int i = 0; i < numberOfBuses; i++)
        {
            buses[i] = int.Parse(Console.ReadLine());
        }

        int groups = 1;

        for (int i = 0; i < numberOfBuses - 1; i++)
        {

            if (buses[i] < buses[i + 1])
            {
                while (buses[i] < buses[i + 1])
                {
                    buses[i + 1] = buses[i];
                    i++;
                    if (i == numberOfBuses - 1)
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