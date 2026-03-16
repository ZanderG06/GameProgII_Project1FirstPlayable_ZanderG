using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class RandomEnemy : Enemy
    {
        public RandomEnemy(int hp, int posX, int posY, int damage, Map gameMap, char icon) : base(hp, posX, posY, damage, gameMap, icon)
        {
        }

        public override void Move(Player player, List<Enemy> enemy, int enemyTurn, List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, Hud hud)
        {
            if (_health.health <= 0) return;

            Random random = new Random();

            int randomDirection = random.Next(4); // 0 = left, 1 = right, 2 = up, 3 = down

            if (randomDirection == 0)
            {
                if (_posX - 1 >= 0 && (_map.mapInGame[_posY][_posX - 1] == '*' || _map.mapInGame[_posY][_posX - 1] == '+' || _map.mapInGame[_posY][_posX - 1] == '='))
                {
                    bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY, hud, enemyTurn);
                    if (checkItem) return;
                    if (player._posX == _posX - 1 && player._posY == _posY)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    if (_map.mapInGame[_posY][_posX - 1] == '+')
                    {
                        _health.Heal(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} healed 1 health point", _map);
                    }
                    if (_map.mapInGame[_posY][_posX - 1] == '=')
                    {
                        _health.TakeDamage(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} took 1 damage from Lava", _map);
                    }
                    _posX--;
                }
            }
            else if (randomDirection == 1)
            {
                if (_posX + 1 < _map.mapHeight && (_map.mapInGame[_posY][_posX + 1] == '*' || _map.mapInGame[_posY][_posX + 1] == '+' || _map.mapInGame[_posY][_posX + 1] == '='))
                {
                    bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY, hud, enemyTurn);
                    if (checkItem) return;
                    if (player._posX == _posX + 1 && player._posY == _posY)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    if (_map.mapInGame[_posY][_posX + 1] == '+')
                    {
                        _health.Heal(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} healed 1 health point", _map);
                    }
                    if (_map.mapInGame[_posY][_posX + 1] == '=')
                    {
                        _health.TakeDamage(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} took 1 damage from Lava", _map);
                    }
                    _posX++;
                }
            }
            else if (randomDirection == 2)
            {
                if (_posY - 1 >= 0 && (_map.mapInGame[_posY - 1][_posX] == '*' || _map.mapInGame[_posY - 1][_posX] == '+' || _map.mapInGame[_posY - 1][_posX] == '='))
                {
                    bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1, hud, enemyTurn);
                    if (checkItem) return;
                    if (player._posX == _posX && player._posY == _posY - 1)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    if (_map.mapInGame[_posY - 1][_posX] == '+')
                    {
                        _health.Heal(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} healed 1 health point", _map);
                    }
                    if (_map.mapInGame[_posY - 1][_posX] == '=')
                    {
                        _health.TakeDamage(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} took 1 damage from Lava", _map);
                    }
                    _posY--;
                }
            }
            else
            {
                if (_posY + 1 < _map.mapLength && (_map.mapInGame[_posY + 1][_posX] == '*' || _map.mapInGame[_posY + 1][_posX] == '+'))
                {
                    bool checkItem = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1, hud, enemyTurn);
                    if (checkItem) return;
                    if (player._posX == _posX && player._posY == _posY + 1)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    if (_map.mapInGame[_posY + 1][_posX] == '+')
                    {
                        _health.Heal(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} healed 1 health point", _map);
                    }
                    if (_map.mapInGame[_posY + 1][_posX] == '=')
                    {
                        _health.TakeDamage(1);
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} took 1 damage from Lava", _map);
                    }
                    _posY++;
                }
            }
        }
    }
}
