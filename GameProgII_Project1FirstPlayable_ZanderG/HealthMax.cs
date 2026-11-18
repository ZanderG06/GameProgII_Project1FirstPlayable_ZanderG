using System.Collections.Generic;

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
