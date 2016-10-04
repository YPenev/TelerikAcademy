using System;

class Solution
{
    static void Main()
    {
        int diggitNumber = int.Parse(Console.ReadLine());
        long diggitCount = 0;
        int pageCount = 1;
        int currentDiggitOnPage;
        int totalDiggitOfPage = 0;

        while (diggitCount != diggitNumber)
        {
            currentDiggitOnPage = pageCount;

            while (currentDiggitOnPage != 0)
            {
                totalDiggitOfPage++;
                currentDiggitOnPage /= 10;
            }

            diggitCount = diggitCount + totalDiggitOfPage;
            totalDiggitOfPage = 0;
            pageCount++;
        }

        Console.WriteLine(pageCount - 1);
    }
}
