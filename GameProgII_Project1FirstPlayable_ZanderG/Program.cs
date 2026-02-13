using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            //Adding player and enemy here, think that's the correct way. Movement will be handled within Player and Enemy class
            Player player = new Player(hp: 10, posX: 0, posY: 0, damage: 1, gameMap: map);
            Enemy enemy = new Enemy(hp: 6, posX: map.mapHeight, posY: map.mapLength, damage: 1); //Puts enemy1 in corner
            Enemy enemy2 = new Enemy(hp: 6, posX: 0, posY: map.mapLength, damage: 1);

            bool isPlaying = true;
            map.CreateGold();
            map.PrintMap();
            DrawPlayers(player, enemy, enemy2);
            map.PrintHUD();

            while(isPlaying)
            {
                ConsoleKey playerInput = Console.ReadKey(true).Key;

                player.MovePlayer(playerInput);
                map.PrintMap();
                DrawPlayers(player, enemy, enemy2);
            }
        }

        static void DrawPlayers(Player player, Enemy enemy, Enemy enemy2)
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
