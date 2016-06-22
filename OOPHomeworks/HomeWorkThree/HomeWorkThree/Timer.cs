using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkThree
{
    class Timer
    {
        public delegate void Alarm(int t);

        public static void SayBeep(int t)
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to stop...");
            while (!Console.KeyAvailable)
            {
                System.Threading.Thread.Sleep(t * 60);
                Console.WriteLine("Beep");

            }
        }
    }
}
