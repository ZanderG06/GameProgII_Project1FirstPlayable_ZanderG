using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Player
    {
        public Health _health; //I think this is what you mean by Composition
        public Map _map;
        public int _posX;
        public int _posY;
        public int _damage;
        public int _lastEncounteredEnemy;

        public Player(int hp, int posX, int posY, int damage, Map gameMap, int lastEncounteredEnemy)
        {
            _health = new Health(hp);
            _posX = posX;
            _posY = posY;
            _damage = damage;
            _map = gameMap;
            _lastEncounteredEnemy = lastEncounteredEnemy;
        }

        public void Move(ConsoleKey input, List<Enemy> enemy, Player player, List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax)
        {
            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (_posY <= 0) break;
                    if (_map.mapInGame[_posY-1][_posX] == '|' || _map.mapInGame[_posY - 1][_posX] == '-' || _map.mapInGame[_posY - 1][_posX] == '~') break;
                    bool checkItemUp = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1);
                    if (checkItemUp) break;
                    for(int i = 0; i < enemy.Count; i++)
                    {
                        if(enemy[i]._posY == _posY - 1 && enemy[i]._posX == _posX)
                        {
                            enemy[i]._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = i;
                            return; //return instead of break as break only stops the for loop
                        }
                    }
                    if(_map.mapInGame[_posY - 1][_posX] == '+') _health.Heal(1);
                    _posY--;
                    break;
                
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (_posY >= _map.mapLength-1) break;
                    if (_map.mapInGame[_posY + 1][_posX] == '|' || _map.mapInGame[_posY + 1][_posX] == '-' || _map.mapInGame[_posY + 1][_posX] == '~') break;
                    bool checkItemDown = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1);
                    if (checkItemDown) break;
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        if (enemy[i]._posY == _posY + 1 && enemy[i]._posX == _posX)
                        {
                            enemy[i]._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = i;
                            return;
                        }
                    }
                    if (_map.mapInGame[_posY + 1][_posX] == '+') _health.Heal(1);
                    _posY++;
                    break;
                
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (_posX <= 0) break;
                    if (_map.mapInGame[_posY][_posX-1] == '|' || _map.mapInGame[_posY][_posX-1] == '-' || _map.mapInGame[_posY][_posX-1] == '~') break;
                    bool checkItemLeft = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY);
                    if (checkItemLeft) break;
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        if (enemy[i]._posY == _posY && enemy[i]._posX == _posX-1)
                        {
                            enemy[i]._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = i;
                            return;
                        }
                    }
                    if (_map.mapInGame[_posY][_posX-1] == '+') _health.Heal(1);
                    _posX--;
                    break;
                
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (_posX >= _map.mapHeight-1) break;
                    if (_map.mapInGame[_posY][_posX + 1] == '|' || _map.mapInGame[_posY][_posX + 1] == '-' || _map.mapInGame[_posY][_posX + 1] == '~') break;
                    bool checkItemRight = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY);
                    if (checkItemRight) break;
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        if (enemy[i]._posY == _posY && enemy[i]._posX == _posX + 1)
                        {
                            enemy[i]._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = i;
                            return;
                        }
                    }
                    if (_map.mapInGame[_posY][_posX + 1] == '+') _health.Heal(1);
                    _posX++;
                    break;
            }
        }

        public bool CheckForItem(List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, int Xpos, int Ypos)
        {
            if (gold.Contains((Ypos, Xpos)))
            {
                gold.Remove((Ypos, Xpos));
                _damage++;
                return true;
            }
            if (healthUp.Contains((Ypos, Xpos)))
            {
                healthUp.Remove((Ypos, Xpos));
                _health.Heal(3);
                return true;
            }
            if (healthMax.Contains((Ypos, Xpos)))
            {
                healthMax.Remove((Ypos, Xpos));
                _health.IncreaseMaxHealth();
                return true;
            }
            return false;
        }
    }
}