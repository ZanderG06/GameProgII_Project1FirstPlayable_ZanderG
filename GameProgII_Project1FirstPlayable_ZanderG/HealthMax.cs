using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class HealthMax
    {
        public List<(int, int)> listOfHealthMax = new List<(int, int)>();
        public int amountOfHealthMax = 1; //Rare Item

        public void Create(int x, int y)
        {
            listOfHealthMax.Add((x, y));
        }
    }
}
