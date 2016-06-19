namespace OOPHomeworkTwo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class PathStorage
    {
        public static void WriteInFile(Path path)
        {
            StreamWriter writer = new StreamWriter("PathList.txt");
            using (writer)
            {
                for (int i = 0; i < path.PathLenght(); i++)
                {
                    writer.WriteLine(path.GetValueAtIndex(i));
                }
            }
        }

        public static void ReadFromFile()
        {
            // Create a StreamReader connected to a file
            StreamReader reader = new StreamReader("PathList.txt");

            int pointNumber = 0;

            // Read first line from the text file
            string line = reader.ReadLine();

            // Read the other lines from the text file
            while (line != null)
            {
                pointNumber++;
                Console.WriteLine("Point {0}: {1}", pointNumber, line);
                line = reader.ReadLine();
            }

            // Close the reader resource after you've finished using it
            reader.Close();
        }
    }
}
