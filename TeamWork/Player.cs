using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    public class Player // singletone
    {
        static int playGroundWidth = 30;
        private static Player instance = null;
        private string body;
        private int x; // position of '('
        private Player()
        {
            body = "(0)";
            x = playGroundWidth / 2 - 1;
            Print();
        }
        public static Player GetInstance()
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
        public void MoveLeft()
        {
            if (x > 0)
            {
                x--;
            }
        }
        public void MoveRight()
        {
            if (x < playGroundWidth - 2)
            {
                x++;
            }
        }
        public void Print(bool hit = false)
        {
            Console.SetCursorPosition(x, Console.WindowHeight - 1);
            Console.ForegroundColor = hit ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(hit ? "XXX" : body);
        }
        public bool Overlap(Rock r)
        {
            if (Console.WindowHeight - 1 == r.y)
            {
                if (x == r.x || x + 1 == r.x || x + 2 == r.x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
