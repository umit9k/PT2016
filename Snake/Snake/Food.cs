using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Food : Drawer
    {

        public Food()
        {
            sign = '$';
        }
    }
}