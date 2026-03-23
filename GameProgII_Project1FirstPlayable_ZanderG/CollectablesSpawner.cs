using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class CollectablesSpawner
    {
        public Random random = new Random();
        public Gold gold = new Gold();
        public HealthUp healthUp = new HealthUp();
        public HealthMax healthMax = new HealthMax();

        public void GetCollectableLocations(Map gameMap)
        {
            int amountOfCollectables = gold.amountOfGold + healthUp.amountOfHealthUp + healthMax.amountOfHealthMax;
            List<(int, int)> collectableLocations = new List<(int, int)>();

            for (int i = 0; i < amountOfCollectables; i++)
            {
                //The -1s are just so the gold doesn't spawn near the walls, I want all the collectables to be near the middle
                int randomX = random.Next(1, gameMap.mapLength - 1);
                int randomY = random.Next(1, gameMap.mapHeight - 1);

                //Makes sure collectables are actually accessible in game
                if (gameMap.mapInGame[randomX][randomY] != '*')
                {
                    i--;
                    continue;
                }

                //This loop prevents collectables from spawning on top of eachother
                for (int j = 0; j < i; j++)
                {
                    if (collectableLocations.Equals((randomX, randomY)))
                    {
                        i--;
                        break;
                    }
                }
                collectableLocations.Add((randomX, randomY));

                //Range check to make sure proper collectables are created
                if (i <= gold.amountOfGold) gold.Create(randomX, randomY);
                if (i <= healthUp.amountOfHealthUp + gold.amountOfGold) healthUp.Create(randomX, randomY);
                if (i > healthUp.amountOfHealthUp + gold.amountOfGold) healthMax.Create(randomX, randomY);
            }
        }
    }
}
