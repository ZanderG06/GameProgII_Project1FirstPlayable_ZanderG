using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Enemy
    {
        public Health _health;
        public int _posX;
        public int _posY;
        public int _damage;
        public Map _map;

        public Enemy(int hp, int posX, int posY, int damage, Map gameMap)
        {
            _health = new Health(hp);
            _posX = posX;
            _posY = posY;
            _damage = damage;
            _map = gameMap;
        }

        //SO MANY IF STATEMENTS
        public void Move(Player player, List<Enemy> enemy, int enemyTurn, List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, char[] enemyIcons)
        {
            if(_health.health <= 0) return;

            int moveAttempts;

            if(enemyIcons[enemyTurn] == '2')
            {
                Random random = new Random();
                moveAttempts = random.Next(1, 3);
            }
            else moveAttempts = 1;

            if (enemyIcons[enemyTurn] == '#' || enemyIcons[enemyTurn] == '2')
            {
                for (int j = 0; j < moveAttempts; j++)
                {
                    int targetX = player._posX - _posX;
                    int targetY = player._posY - _posY;

                    if (targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '+')
                    {
                        bool checkItemLeft = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY); //Enemies picking up items is on purpose
                        if (checkItemLeft) continue;
                        if (player._posX == _posX - 1 && player._posY == _posY)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            continue;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn) //Makes it so that the enemy doesn't check for itself when trying to move
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX - 1 && enemy[i]._posY == _posY)
                            {
                                break;
                            }
                        }
                        _posX--;
                    }
                    else if (targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '*' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '+')
                    {
                        bool checkItemRight = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY);
                        if (checkItemRight) continue;
                        if (player._posX == _posX + 1 && player._posY == _posY)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            continue;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX + 1 && enemy[i]._posY == _posY)
                            {
                                break;
                            }
                        }
                        _posX++;
                    }
                    else if (targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '*' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '+')
                    {
                        bool checkItemUp = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1);
                        if (checkItemUp) continue;
                        if (player._posX == _posX && player._posY == _posY - 1)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            continue;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX && enemy[i]._posY == _posY - 1)
                            {
                                break;
                            }
                        }
                        _posY--;
                    }
                    else if (targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '*' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '+')
                    {
                        bool checkItemDown = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1);
                        if (checkItemDown) continue;
                        if (player._posX == _posX && player._posY == _posY + 1)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            continue;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX && enemy[i]._posY == _posY + 1)
                            {
                                break;
                            }
                        }
                        _posY++;
                    }
                }
            }
            else
            {
                Random random = new Random();

                int randomDirection = random.Next(4); // 0 = left, 1 = right, 2 = up, 3 = down

                if (randomDirection == 0)
                {
                    if (_posX - 1 >= 0 && (_map.mapInGame[_posY][_posX - 1] == '*' || _map.mapInGame[_posY][_posX - 1] == '+'))
                    {
                        bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY); //Enemies picking up items is on purpose
                        if (checkItem) return;
                        if (player._posX == _posX - 1 && player._posY == _posY)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            return;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX - 1 && enemy[i]._posY == _posY)
                            {
                                return;
                            }
                        }
                        _posX--;
                    }
                }
                else if (randomDirection == 1)
                {
                    if (_posX + 1 < _map.mapHeight && (_map.mapInGame[_posY][_posX + 1] == '*' || _map.mapInGame[_posY][_posX + 1] == '+'))
                    {
                        bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY);
                        if (checkItem) return;
                        if (player._posX == _posX + 1 && player._posY == _posY)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            return;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX + 1 && enemy[i]._posY == _posY)
                            {
                                return;
                            }
                        }
                        _posX++;
                    }
                }
                else if (randomDirection == 2)
                {
                    if (_posY - 1 >= 0 && (_map.mapInGame[_posY - 1][_posX] == '*' || _map.mapInGame[_posY - 1][_posX] == '+'))
                    {
                        bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1);
                        if (checkItem) return;
                        if (player._posX == _posX && player._posY == _posY - 1)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            return;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX && enemy[i]._posY == _posY - 1)
                            {
                                return;
                            }
                        }
                        _posY--;
                    }
                }
                else
                {
                    if (_posY + 1 < _map.mapLength && (_map.mapInGame[_posY + 1][_posX] == '*' || _map.mapInGame[_posY + 1][_posX] == '+'))
                    {
                        bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1);
                        if (checkItem) return;
                        if (player._posX == _posX && player._posY == _posY + 1)
                        {
                            player._health.TakeDamage(_damage);
                            player._lastEncounteredEnemy = enemyTurn;
                            return;
                        }
                        for (int i = 0; i < enemy.Count; i++)
                        {
                            if (i == enemyTurn)
                            {
                                continue;
                            }
                            if (enemy[i]._posX == _posX && enemy[i]._posY == _posY + 1)
                            {
                                return;
                            }
                        }
                        _posY++;
                    }
                }
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