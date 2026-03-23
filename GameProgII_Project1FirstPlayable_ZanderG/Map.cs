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
        //Gets path of map file then makes array
        static string mapLayout = "mapFile.txt";
        public string[] mapInGame = File.ReadAllLines(mapLayout);

        //I don't really think I have to do this, but it's easier on my brain to read
        public int mapLength { get { return mapInGame.Length;} }
        
        public int mapHeight { get { return mapInGame[0].Length;} }

        public int enemyMaxX { get { return mapLength - 1;} }

        public int enemyMaxY { get { return mapHeight - 3;} }

        public Dictionary<char, ConsoleColor> mapColors = new Dictionary<char, ConsoleColor>();

        public void PrintMap(List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax)
        {
            Console.SetCursorPosition(0,0);

            //The +2 is just for the corners, hope it doesn't count as magic number :D
            for (int i = 0; i < mapHeight + 2; i++) Console.Write('░');
            Console.Write("\n");

            for(int i = 0; i < mapLength; i++)
            {
                Console.Write('░');
                for(int j = 0; j < mapHeight; j++)
                {
                    char mapTile = mapInGame[i][j];

                    if(mapColors.ContainsKey(mapTile))
                    {
                        Console.ForegroundColor = mapColors[mapTile];
                    }

                    Console.Write(mapInGame[i][j]);
                    Console.ResetColor();
                }
                Console.Write('░');
                Console.Write("\n");
            }
            for(int i = 0; i < mapHeight + 2; i++) Console.Write('░');

            foreach((int x, int y) in gold)
            {
                Console.SetCursorPosition(y + 1, x + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('$');
                Console.ResetColor();
            }

            foreach((int x, int y) in healthUp)
            {
                Console.SetCursorPosition(y + 1, x + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('3');
                Console.ResetColor();
            }

            foreach((int x, int y) in healthMax)
            {
                Console.SetCursorPosition(y + 1, x + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('%');
                Console.ResetColor();
            }
        }
    }
}