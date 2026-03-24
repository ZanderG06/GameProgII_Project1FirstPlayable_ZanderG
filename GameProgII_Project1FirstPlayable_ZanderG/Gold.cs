using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Gold
    {
        public List<(int, int)> listOfGold = new List<(int, int)>();
        public int amountOfGold = 25;

        public void Create(int x, int y)
        {
            listOfGold.Add((x, y));
        }
    }
}
