using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    class Info
    {
        public static long scores;
        public static int livesCount = 3;

        public static void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(SystemSetup.playGroundWidth + 5, 5);
            Console.Out.WriteLine("Lives: {0}", Info.livesCount);
            Console.SetCursorPosition(SystemSetup.playGroundWidth + 5, 7);
            Console.Out.WriteLine("Scores: {0}", Info.scores);
        }
    }
}
