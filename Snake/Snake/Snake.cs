using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Snake : Drawer
    {
        public int MyProperty { get; set; }
        public Snake()
        {
            sign = 'o'; // как будет выглядеть змейка
        }

        public void Move(int dx, int dy) // движение змейки
        {

            for (int i = body.Count - 1; i > 0; --i)// конец змейки должен следовать за ней
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            // движение головы
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if (Game.snake.body[0].x == Game.food.body[0].x &&
               Game.snake.body[0].y == Game.food.body[0].y)
            {
                Game.eatfood++;
                Game.snake.body.Add(new Point
                {
                    x = Game.food.body[0].x,
                    y = Game.food.body[0].y
                });
                // еда может находиться рандомно в любом месте 
                Game.food.body[0].x = new Random().Next(1, 47);
                Game.food.body[0].y = new Random().Next(1, 19);
                
                }

                for (int i = 0; i < Game.wall.body.Count; ++i)// при встрече змейки со стенкой он проигрывает
                {
                    if (Game.snake.body[0].x == Game.wall.body[i].x &&
           Game.snake.body[0].y == Game.wall.body[i].y)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(20, 10);
                        Console.WriteLine("Game over!");
                        Game.isActive = false;
                    }
                }
                if (Game.snake.body.Count > 5) // если змея съесть больше 5 еды он преходит на след. уровенб
                {
                    Console.Clear();
                    Console.WriteLine("New level"); // говорит то что вы прошли на новый уровень
                    Console.ReadKey();
                    Game.Init();
                    Game.LoadlLevel(Game.newlevel++);// на уровень выше
                }


            }
        }
    }

