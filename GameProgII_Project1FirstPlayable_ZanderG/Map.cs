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
        static string[] mapInGame = File.ReadAllLines(mapLayout);

        //I don't really think I have to do this, but it's easier on my brain to read
        static int mapLength = mapInGame.Length;
        static int mapHeight = mapInGame[0].Length;

        //Will probably have to call this something else. What do I call it :c
        public void BeginMapProcess()
        {
            for(int i = 0; i < amountOfGold; i++)
            {
                int randomX = random.Next(18);
                int randomY = random.Next(12);

                gold.Add((randomX, randomY));
                //Will have to check for inaccessable gold
            }

            PrintMap();
        }

        static void PrintMap()
        {
            Console.SetCursorPosition(0,0);

            //The +2 is just for the corners
            for (int i = 0; i < mapHeight + 2; i++) Console.Write('░');
            Console.Write("\n");

            for(int i = 0; i < mapLength; i++)
            {
                Console.Write('░');
                for(int j = 0; j < mapHeight; j++)
                {
                    if(mapInGame[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(mapInGame[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if(mapInGame[i][j] == '@')
                    {
                        //Will probably change (ew ew ew ugly)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(mapInGame[i][j]);
                    Console.ResetColor();
                }
                Console.Write('░');
                Console.Write("\n");
            }
            for(int i = 0; i < mapHeight + 2; i++) Console.Write('░');

            PrintHUD();
        }

        static void PrintHUD()
        {
            Console.SetCursorPosition(0, mapLength+3);
            Console.Write("HUD:");
        }
    }
}
