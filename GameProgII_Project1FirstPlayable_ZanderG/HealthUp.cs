using System;
using System.Collections.Generic;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class HealthUp
    {
        Random random = new Random();

        public List<(int, int)> listOfHealthUp = new List<(int, int)>();
        public int amountOfHealthUp = 2;

        public void Create(int x, int y)
        {
            listOfHealthUp.Add((x, y));
        }
    }
}
