using System;

class Program
{
    private static int numberOfBusses = int.Parse(Console.ReadLine());
    private static int[] busesSpeeds = new int[numberOfBusses];
    private static int numberOfGroups = 1;

    static void Main()
    {
        for (int i = 0; i < numberOfBusses; i++)
        {
            // Insert bus speed
            busesSpeeds[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < numberOfBusses - 1; i++)
        {
            GroupBuses(i);
        }

        Console.WriteLine(numberOfGroups);
    }

    private static void GroupBuses(int currentBus)
    {
        // Check if bus is slower than the one behind
        if (busesSpeeds[currentBus] < busesSpeeds[currentBus + 1])
        {
            // The busses behing wich is  moving faster takes slower bus speed
            while (busesSpeeds[currentBus] < busesSpeeds[currentBus + 1] || currentBus < numberOfBusses - 1)
            {
                busesSpeeds[currentBus + 1] = busesSpeeds[currentBus];

                currentBus++;
            }
        }

        numberOfGroups++;
    }
}