using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamWork
{
  public class SystemSetup
    {
      public static int playGroundWidth = 30;
      private int speed = 150;
     
      public  static void Initialisation()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Title = "Falling Rocks";
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth = 50;
            Info.scores = 0;
        }
      public static void Sleep()
      {
          Thread.Sleep(150);
      }
    }
}
