using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Hud hud = new Hud();
            CollectablesSpawner collectables = new CollectablesSpawner();

            char[] enemyIcons = { '#', 'R', '2' }; // # = Normal, R = Random, 2 = Moves Twice

            Player player = new Player(hp: 10, posX: 0, posY: 0, damage: 1, gameMap: map, lastEncounteredEnemy: 0);
            Enemy enemy1 = new Enemy(hp: 6, posX: 17, posY: 11, damage: 2, gameMap: map, icon: '#');
            Enemy enemy2 = new Enemy(hp: 6, posX: 17, posY: 0, damage: 3, gameMap: map, icon: 'R');
            Enemy enemy3 = new Enemy(hp: 6, posX: 0, posY: 11, damage: 1, gameMap: map, icon: '2'); //Boss Enemy
            Enemy enemy4 = new Enemy(hp: 6, posX: 17, posY: 6, damage: 2, gameMap: map, icon: '#');
            Enemy enemy5 = new Enemy(hp: 6, posX: 10, posY: 6, damage: 3, gameMap: map, icon: 'R'); //Wasn't 100% sure what you meant by multiple instances of each enemy, hope this is it

            List<Enemy> enemies = new List<Enemy> { enemy1, enemy2, enemy3, enemy4, enemy5 };

            map.mapColors.Add('*', ConsoleColor.Green);
            map.mapColors.Add('~', ConsoleColor.Blue);
            map.mapColors.Add('+', ConsoleColor.Magenta);
            map.mapColors.Add('=', ConsoleColor.DarkRed);

            bool isPlaying = true;

            collectables.GetCollectableLocations(map);

            map.PrintMap(collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax);
            DrawPlayers(player, enemies);

            hud.ChangeEventLog("Game has started", map);
            while (isPlaying)
            {
                hud.PrintHUD("Player's Turn", player, enemies, map);
                
                ConsoleKey playerInput = Console.ReadKey(true).Key;
                player.Move(playerInput, enemies, player, collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax, hud);
                
                for(int i = 0; i < enemies.Count; i++)
                {
                    hud.PrintHUD($"Enemy{i+1}'s Turn", player, enemies, map);
                    Thread.Sleep(250);
                    enemies[i].Move(player, enemies, i, collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax, hud);
                    map.PrintMap(collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax);
                    DrawPlayers(player, enemies);
                }

                isPlaying = CheckIfGameOver(player, enemies);

                if(!isPlaying)
                {
                    Console.Clear();
                    if (player._health.health == 0)
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
            if (player._health.health > 0)
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
                if (enemy[i]._health.health > 0)
                {
                    Console.SetCursorPosition(enemy[i]._posX + 1, enemy[i]._posY + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(enemy[i]._icon);
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
            if (player._health.health <= 0) return false;

            //I think this is the best way to do it
            int deadEnemies = 0;
            for(int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i]._health.health <= 0) deadEnemies++;
            }

            if (deadEnemies == enemy.Count) return false;

            return true;
        }
    }
}