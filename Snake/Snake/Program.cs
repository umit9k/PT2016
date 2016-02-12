using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            Game.Init();
            Game.LoadlLevel(Game.newlevel);
            Console.SetWindowSize(48, 20); // размер игры

            while (Game.isActive)
            {
                Game.Draw();
                Console.WriteLine(" ");
                Console.WriteLine("Your score is {0}",Game.eatfood);// счетчик еды
                Console.WriteLine("Your level is {0}", Game.newlevel);// счетчик уровня
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.isActive = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }

            Console.ReadKey();


        }
    }
}
