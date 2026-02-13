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
        //I'm putting gold in the Map class, hope that's right
        public List<(int, int)> gold = new List<(int, int)>();

        //Gets path of map file then makes array
        static string mapLayout = "mapFile.txt";
        public string[] mapInGame = File.ReadAllLines(mapLayout);

        //I don't really think I have to do this, but it's easier on my brain to read
        public int mapLength { get { return mapInGame.Length;} }
        
        public int mapHeight { get { return mapInGame[0].Length;} }

        public void CreateGold()
        {
            int amountOfGold = 5;
            Random random = new Random();

            for (int i = 0; i < amountOfGold; i++)
            {
                //The -1s are just so the gold doesn't spawn near the walls, I want all the gold to be near the middle
                int randomX = random.Next(1, mapLength-1);
                int randomY = random.Next(1, mapHeight-1);

                //Makes sure gold is actually accessible
                if(mapInGame[randomX][randomY] != '*')
                {
                    i--;
                    continue;
                }
                //This loop prevents gold from spawning on top of eachother
                for(int j = 0; j < i; j++)
                {
                    if(gold.Equals((randomX, randomY)))
                    {
                        i--;
                        break;
                    }
                }
                gold.Add((randomX, randomY));
            }
        }

        public void PrintMap()
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
                    if(mapInGame[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(mapInGame[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if(mapInGame[i][j] == '+')
                    {
                        //Will probably change (ew ew ew ugly)
                        Console.ForegroundColor = ConsoleColor.Magenta;
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

            foreach((int x, int y) in gold)
            {
                Console.SetCursorPosition(y + 1, x + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('$');
                Console.ResetColor();
            }
        }

        public void PrintHUD(string hudText, int playerHealth, int playerDamage, int enemy1Health, int enemy1Damage, int enemy2Health, int enemy2Damage)
        {
            //+3 is so there's spacing
            Console.SetCursorPosition(0, mapLength+3);
            Console.Write("HUD:");
            Console.WriteLine($"\n{hudText}                            ");
            Console.WriteLine($"\nPlayer Health: {playerHealth}        ");
            Console.WriteLine($"\nPlayer Damage: {playerDamage}        ");
            Console.WriteLine($"\nEnemy1 Health: {enemy1Health}        ");
            Console.WriteLine($"\nEnemy1 Damage: {enemy1Damage}        ");
            Console.WriteLine($"\nEnemy2 Health: {enemy2Health}        ");
            Console.WriteLine($"\nEnemy2 Damage: {enemy2Damage}        ");
        }
    }
}