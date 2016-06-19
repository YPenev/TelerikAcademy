using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    public class DangerRock
    {
        static char[] r = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
        static Random rand = new Random();
        private char body;
        public int x, y;
        public ConsoleColor colour;

        public int Body
        {
            get
            {
                return this.body;
            }
        }
        private ConsoleColor GetRandomConsoleColor()
        {
            int r = rand.Next(16);
            switch (r)
            {
                case 0: return ConsoleColor.White;
                case 1: return ConsoleColor.Blue;
                case 2: return ConsoleColor.Cyan;
                case 3: return ConsoleColor.DarkBlue;
                case 4: return ConsoleColor.DarkCyan;
                case 5: return ConsoleColor.DarkGray;
                case 6: return ConsoleColor.White;
                case 7: return ConsoleColor.DarkGreen;
                case 8: return ConsoleColor.DarkMagenta;
                case 9: return ConsoleColor.DarkRed;
                case 10: return ConsoleColor.DarkYellow;
                case 11: return ConsoleColor.Gray;
                case 12: return ConsoleColor.Green;
                case 13: return ConsoleColor.Magenta;
                case 14: return ConsoleColor.Red;
                case 15: return ConsoleColor.Yellow;
                default: return ConsoleColor.Black;
            }
        }
        public DangerRock()
        {
            body = r[rand.Next(r.Length)];
            x = rand.Next(SystemSetup.playGroundWidth);
            y = 0;
            colour = GetRandomConsoleColor();
        }
        
        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colour;
            Console.Write(body);
        }

        public bool MoveDown()
        {
            if (y < Console.WindowHeight - 1)
            {
                y++;
                return true;
            }
            return false;
        }

    }
}
