using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{
    [Serializable]
    public class Drawer
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public Drawer()
        {
            color = ConsoleColor.Blue;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Create, FileAccess.Write); // сериализация
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            if (t == typeof(Wall)) Game.wall = bf.Deserialize(fs) as Wall;
            if (t == typeof(Snake)) Game.snake = bf.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.food = bf.Deserialize(fs) as Food;
            fs.Close();
        }
    }
}