using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Collectables
    {
        public Random random = new Random();

        //Gold
        public List<(int, int)> gold = new List<(int, int)>();
        public int amountOfGold = 5;

        //Health Up
        public List<(int, int)> healthUp = new List<(int, int)>();
        public int amountOfHealthUp = 3;

        //Time Freeze
        public List<(int, int)> healthMax = new List<(int, int)>();
        public int amountOfHealthMax = 1;

        public void CreateGold(Map gameMap)
        {
            for (int i = 0; i < amountOfGold; i++)
            {
                //The -1s are just so the gold doesn't spawn near the walls, I want all the gold to be near the middle
                int randomX = random.Next(1, gameMap.mapLength - 1);
                int randomY = random.Next(1, gameMap.mapHeight - 1);

                //Makes sure gold is actually accessible in game
                if (gameMap.mapInGame[randomX][randomY] != '*')
                {
                    i--;
                    continue;
                }
                //This loop prevents gold from spawning on top of eachother
                for (int j = 0; j < i; j++)
                {
                    if (gold.Equals((randomX, randomY)))
                    {
                        i--;
                        break;
                    }
                }
                gold.Add((randomX, randomY));
            }
        }

        public void CreateHealthUp(Map gameMap)
        {
            for (int i = 0; i < amountOfHealthUp; i++)
            {
                int randomX = random.Next(1, gameMap.mapLength - 1);
                int randomY = random.Next(1, gameMap.mapHeight - 1);

                if (gameMap.mapInGame[randomX][randomY] != '*')
                {
                    i--;
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    if (healthUp.Equals((randomX, randomY)) || gold.Equals((randomX, randomY)))
                    {
                        i--;
                        break;
                    }
                }
                healthUp.Add((randomX, randomY));
            }
        }

        public void CreateHealthMax(Map gameMap)
        {
            for (int i = 0; i < amountOfHealthMax; i++)
            {
                int randomX = random.Next(1, gameMap.mapLength - 1);
                int randomY = random.Next(1, gameMap.mapHeight - 1);

                if (gameMap.mapInGame[randomX][randomY] != '*')
                {
                    i--;
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    if (healthMax.Equals((randomX, randomY)) || healthUp.Equals((randomX, randomY)) || gold.Equals((randomX, randomY)))
                    {
                        i--;
                        break;
                    }
                }
                healthMax.Add((randomX, randomY));
            }
        }
    }
}
