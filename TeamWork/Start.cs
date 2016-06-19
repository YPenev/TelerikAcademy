﻿using System;
using System.Collections.Generic;
using System.Threading;
 
namespace  TeamWork
{
    class Game
    {
        static Random rand = new Random();
        static List<Rock> rocks;
       
  
       
        static void Main()
        {
            rocks = new List<Rock>();
            SystemSetup.Initialisation();
            Player player = Player.GetInstance();
            List<Rock> removeObsoletes;
            bool hit = false;
            ConsoleKeyInfo pressedKey;
            while (true)
            {
                // adding new rocks
                for (int i = 0, count = rand.Next(SystemSetup.playGroundWidth / (Info.scores > 200 ? 9 : 12)); i < count; i++)
                {
                    rocks.Add(new Rock());
                }
                // moving our dwarf
                while (Console.KeyAvailable)
                {
                    pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow || pressedKey.Key == ConsoleKey.A) // <--
                    {
                        player.MoveLeft();
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.D) // -->
                    {
                        player.MoveRight();
                    }
                    if (pressedKey.Key == ConsoleKey.Escape) // Esc
                    {
                        Environment.Exit(0); // leave game
                    }
                }
                removeObsoletes = new List<Rock>(); // rocks, which are to leave the screen
                hit = false;
                foreach (Rock rock in rocks)
                {
                    if (!rock.MoveDown())
                    {
                        removeObsoletes.Add(rock);
                    }
                    if (player.Overlap(rock)) // if hit
                    {
                        Info.livesCount--;
                        hit = true;
                        Console.Beep();
                        if (Info.livesCount == 0) // game over
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Out.WriteLine("GAME OVER !!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(0);
                        }
                    }
                }
                Console.Clear();
                foreach (Rock old in removeObsoletes) // removing rocks, which are to leave the screen
                {
                    rocks.Remove(old);
                    Info.scores++;
                }
                if (hit)
                {
                    rocks.Clear();
                    Info.scores -= 10;
                }
                // printing
                foreach (Rock rock in rocks)
                {
                    rock.Print();
                }

                player.Print(hit);
                Info.DisplayInfo();
                SystemSetup.Sleep();
            }
        }
    }
}