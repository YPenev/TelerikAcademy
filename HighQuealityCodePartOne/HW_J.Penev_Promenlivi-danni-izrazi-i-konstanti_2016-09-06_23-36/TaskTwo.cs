/// <summary>
/// Print statistics for minimal, maximal and average value
/// of the given collection
/// </summary>
/// <param colection of items="givvenItems"></param>
/// <param number of items in colection="numberOfItems"></param>
public void PrintStatistics(double[] givvenItems, int numberOfItems)
{
    // Find maximal element and store it to value max
    double max = double.MinValue;

    for (int i = 0; i < numberOfItems; i++)
    {
        if (givvenItems[i] > max)
        {
            max = givvenItems[i];
        }
    }

    PrintMax(max);

    // Find minimal element and store it to value min
    double min = double.MaxValue;
    for (int i = 0; i < numberOfItems; i++)
    {
        if (givvenItems[i] < min)
        {
            max = givvenItems[i];
        }
    }

    PrintMin(min);

    // Calculate the average value of the collection
    double sum = 0;
    for (int i = 0; i < numberOfItems; i++)
    {
        sum += givvenItems[i];
    }

    double avg = sum / numberOfItems;

    PrintAvg(avg);
}