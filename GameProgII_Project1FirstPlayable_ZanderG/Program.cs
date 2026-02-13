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
            Enemy enemy1 = new Enemy(hp: 6, posX: 17, posY: 11, damage: 1, gameMap: map);
            Enemy enemy2 = new Enemy(hp: 6, posX: 0, posY: 11, damage: 1, gameMap: map);

            bool isPlaying = true;
            map.CreateGold();
            map.PrintMap();
            DrawPlayers(player, enemy1, enemy2);

            while(isPlaying)
            {
                map.PrintHUD("Player", player.health, player._damage, enemy1.health, enemy1._damage, enemy2.health, enemy2._damage);
                ConsoleKey playerInput = Console.ReadKey(true).Key;

                player.MovePlayer(playerInput, (enemy1._posY, enemy1._posX), (enemy2._posY, enemy2._posX), enemy1, enemy2);
                map.PrintHUD("Enemy 1", player.health, player._damage, enemy1.health, enemy1._damage, enemy2.health, enemy2._damage);
                map.PrintMap();
                DrawPlayers(player, enemy1, enemy2);

                enemy1.MoveEnemy(player._posX, player._posY);
                map.PrintHUD("Enemy 2", player.health, player._damage, enemy1.health, enemy1._damage, enemy2.health, enemy2._damage);
                map.PrintMap();
                DrawPlayers(player, enemy1, enemy2);

                enemy2.MoveEnemy(player._posX, player._posY);

                map.PrintMap();
                DrawPlayers(player, enemy1, enemy2);
            }
        }

        static void DrawPlayers(Player player, Enemy enemy1, Enemy enemy2)
        {
            //Player, if statement makes sure player/enemies are alive before drawing
            if (player.health > 0)
            {
                Console.SetCursorPosition(player._posX + 1, player._posY + 1);
                Console.Write('&');
            }
            else
            {
                player._posX = 18;
                player._posY = 12;
            }

            //First enemy
            if (enemy1.health > 0)
            {
                Console.SetCursorPosition(enemy1._posX + 1, enemy1._posY + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('#');
            }
            else
            {
                enemy1._posX = 18;
                enemy1._posY = 12;
            }

            //Second enemy
            if (enemy2.health > 0)
            {
                Console.SetCursorPosition(enemy2._posX + 1, enemy2._posY + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('#');
            }
            else
            {
                enemy2._posX = 18;
                enemy2._posY = 12;
            }

            Console.ResetColor();
        }
    }
}