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
            bool isPlaying = true;

            while (isPlaying)
            {
                Map map = new Map();
                Hud hud = new Hud();
                CollectablesSpawner collectables = new CollectablesSpawner();

                int numberOfStandardEnemies = 25;

                Player player = new Player(hp: 10, posX: 0, posY: 0, damage: 1, gameMap: map, lastEncounteredEnemy: 0);
                Enemy enemyR1 = new RandomEnemy(hp: 6, posX: 17, posY: 0, damage: 3, gameMap: map, icon: 'R');
                Enemy quickEnemy = new QuickEnemy(hp: 6, posX: 0, posY: 17, damage: 1, gameMap: map, icon: '2'); //Boss Enemy
                Enemy enemyR2 = new RandomEnemy(hp: 6, posX: 10, posY: 6, damage: 3, gameMap: map, icon: 'R');

                List<Enemy> enemies = new List<Enemy> { quickEnemy, enemyR1, enemyR2 };

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++) enemies.Add(new Enemy(hp: 1, posX: i+31, posY: j+12, damage: 1, gameMap: map, icon: '#'));
                }

                map.mapColors.Add('*', ConsoleColor.Green);
                map.mapColors.Add('~', ConsoleColor.Blue);
                map.mapColors.Add('+', ConsoleColor.Magenta);
                map.mapColors.Add('=', ConsoleColor.DarkRed);

                bool currentGameLoop = true;

                collectables.GetCollectableLocations(map);

                map.PrintMap(collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax);
                DrawPlayers(player, enemies);

                hud.ChangeEventLog("Game has started", map);
                while (currentGameLoop)
                {
                    hud.PrintHUD("Player's Turn", player, enemies, map);

                    ConsoleKey playerInput = Console.ReadKey(true).Key;
                    player.Move(playerInput, enemies, collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax, hud);
                    DrawPlayers(player, enemies);

                    for (int i = 0; i < enemies.Count; i++)
                    {
                        hud.PrintHUD($"Enemy{i + 1}'s Turn", player, enemies, map);
                        enemies[i].Move(player, enemies, i, collectables.gold.listOfGold, collectables.healthUp.listOfHealthUp, collectables.healthMax.listOfHealthMax, hud);
                    }
                    DrawPlayers(player, enemies);

                    currentGameLoop = CheckIfGameOver(player, enemies);
                    if (playerInput == ConsoleKey.Escape) currentGameLoop = false; //Debug to get to end

                    if (!currentGameLoop)
                    {
                        Console.Clear();
                        if (player._health.health == 0)
                        {
                            Console.WriteLine("You lose.");
                        }
                        else
                        {
                            Console.WriteLine("You win!");
                        }
                        bool validInput = false;

                        while (!validInput)
                        {
                            Console.WriteLine("Play Again? (Y/N)");
                            ConsoleKey playAgainInput = Console.ReadKey(true).Key;
                            if (playAgainInput == ConsoleKey.Y)
                            {
                                isPlaying = true;
                                validInput = true;
                            }
                            else if (playAgainInput == ConsoleKey.N)
                            {
                                isPlaying = false;
                                validInput = true;
                            }
                        }   
                    }
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
            for (int i = 0; i < enemy.Count; i++)
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
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i]._health.health <= 0) deadEnemies++;
            }

            if (deadEnemies == enemy.Count) return false;

            return true;
        }
    }
}