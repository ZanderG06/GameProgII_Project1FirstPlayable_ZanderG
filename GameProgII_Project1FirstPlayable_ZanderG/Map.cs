using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Map
    {
        //Making a list of 5 gold on the map, I want the locations to be random
        List<(int,int)> gold = new List<(int,int)>();
        int amountOfGold = 5;
        Random random = new Random();
        
        //Gets path of map file then makes array
        static string mapLayout = "mapFile.txt";
        string[] mapInGame = File.ReadAllLines(mapLayout);

        //Will probably have to call this something else to call it in main, unless I'm stupid
        public Map()
        {
            for(int i = 0; i < amountOfGold; i++)
            {
                int randomX = random.Next(18);
                int randomY = random.Next(12);

                gold.Add((randomX, randomY));
                //Will have to check for inaccessable gold
            }
        }
    }
}
