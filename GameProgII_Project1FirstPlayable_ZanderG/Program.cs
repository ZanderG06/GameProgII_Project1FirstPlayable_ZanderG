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

            Player player = new Player(hp: 10, posX: 0, posY: 0, damage: 1, gameMap: map, lastEncounteredEnemy: 0);
            Enemy enemy1 = new Enemy(hp: 6, posX: 17, posY: 11, damage: 1, gameMap: map);
            Enemy enemy2 = new Enemy(hp: 6, posX: 17, posY: 0, damage: 1, gameMap: map);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(enemy1);
            enemies.Add(enemy2);

            bool isPlaying = true;
            map.CreateGold();
            map.PrintMap();
            DrawPlayers(player, enemies);

            while(isPlaying)
            {
                map.PrintHUD("Player's Turn", player, enemies);
                ConsoleKey playerInput = Console.ReadKey(true).Key;
                player.MovePlayer(playerInput, enemies, player);
                
                for(int i = 0; i < enemies.Count; i++)
                {
                    map.PrintHUD("Player's Turn", player, enemies);
                    enemies[i].MoveEnemy(player, enemies, i);
                    map.PrintMap();
                    DrawPlayers(player, enemies);
                }

                isPlaying = CheckIfGameOver(player, enemies);

                if(!isPlaying)
                {
                    Console.Clear();
                    if (player.health == 0)
                    {
                        Console.WriteLine("Game Over! You lose.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You win!");
                    }
                    Console.ReadKey(true);
                }
            }
        }

        static void DrawPlayers(Player player, List<Enemy> enemy)
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

            //Enemy, +1 accounts for the border
            for(int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i].health > 0)
                {
                    Console.SetCursorPosition(enemy[i]._posX + 1, enemy[i]._posY + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine('#');
                }
                else
                {
                    enemy[i]._posX = 18;
                    enemy[i]._posY = 12;
                }
            }

            Console.ResetColor();
        }

        static bool CheckIfGameOver(Player player, List<Enemy> enemy)
        {
            if (player.health <= 0) return false;

            //I think this is the best way to do it
            int deadEnemies = 0;
            for(int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i].health <= 0)
                {
                    deadEnemies++;
                }
            }

            if (deadEnemies == enemy.Count) return false;

            return true;
        }
    }
}