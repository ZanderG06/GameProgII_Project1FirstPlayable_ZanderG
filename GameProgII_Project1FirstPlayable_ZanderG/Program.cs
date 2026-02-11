using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Program
    {
        static Map map = new Map();
        static bool isPlaying = true;

        //Adding player and enemy here, think that's the correct way. Movement will be handled within Player and Enemy class
        static Player player = new Player(hp: 10, posX: 0, posY: 0);
        static Enemy enemy = new Enemy(hp: 6, posX: map.mapHeight, posY: map.mapLength); //Puts enemy1 in corner
        static Enemy enemy2 = new Enemy(hp: 6, posX: 0, posY: map.mapLength);

        static void Main(string[] args)
        {
            map.CreateGold();
            map.PrintMap();
            DrawPlayers();
            map.PrintHUD();

            while(isPlaying)
            {

                ConsoleKey playerInput = Console.ReadKey(true).Key;

                player.MovePlayer(playerInput);
                map.PrintMap();
                DrawPlayers();
            }
        }

        static void DrawPlayers()
        {
            //Player, if statement makes sure player/enemies are alive before drawing
            if (player.health > 0)
            {
                Console.SetCursorPosition(player._posX + 1, player._posY + 1);
                Console.Write('&');
            }

            //First enemy
            if (enemy.health > 0)
            {
                Console.SetCursorPosition(enemy._posX, enemy._posY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('#');
            }

            //Second enemy
            if (enemy2.health > 0)
            {
                Console.SetCursorPosition(enemy2._posX + 1, enemy2._posY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('#');
            }

            Console.ResetColor();
        }
    }
}
