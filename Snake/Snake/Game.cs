using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Game
    {
        public static bool isActive;
        public static int eatfood = 0;
        public static int newlevel = 1;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            snake.body.Add(new Point { x = 15, y = 14 });
            food.body.Add(new Point { x = 14, y = 15 });

            food.color = ConsoleColor.Blue;
            wall.color = ConsoleColor.Green;
            snake.color = ConsoleColor.Yellow;

            Console.SetWindowSize(48, 19);
        }

        public static void LoadlLevel(int level)
        {
            FileStream fs = new FileStream(string.Format(@"C:\Users\qwerty\Desktop\Prog\LevelWall{0}.txt", level), FileMode.Open, FileAccess.Read);// файлы с сохроненными уровнями
            StreamReader sr = new StreamReader(fs);

            string line;
            int row = -1;
            int col = -1;

            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }
            // для того чтобы поставить # стену на все границы и чтобы змейка проигрывала при уходе за границы
            for (int i = 0; i < 47; i++)
                wall.body.Add(new Point { x = i, y = 0 });
            for (int i = 0; i < 47; i++)
                wall.body.Add(new Point { x = i, y = 19 });
            for (int i = 0; i < 20; i++)
                wall.body.Add(new Point { x = 0, y = i });
            for (int i = 0; i < 20; i++)
                wall.body.Add(new Point { x = 47, y = i });

            sr.Close();
            fs.Close();
        }

        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}