using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class QuickEnemy : Enemy
    {
        public QuickEnemy(int hp, int posX, int posY, int damage, Map gameMap, char icon) : base(hp, posX, posY, damage, gameMap, icon)
        {
        }

        public override void Move(Player player, List<Enemy> enemy, int enemyTurn, List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, Hud hud)
        {
            if (_health.health <= 0) return;

            Random random = new Random();
            int moveAttempts = random.Next(1, 3);

            for (int j = 0; j < moveAttempts; j++)
            {
                int targetX = player._posX - _posX;
                int targetY = player._posY - _posY;

                if (targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '+' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '=')
                {
                    bool checkItemLeft = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY, hud, enemyTurn); //Enemies picking up items is on purpose
                    if (checkItemLeft) continue;
                    if (player._posX == _posX - 1 && player._posY == _posY)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    RefreshTileBehind();
                    _posX--;
                }
                else if (targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '*' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '+' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '=')
                {
                    bool checkItemRight = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY, hud, enemyTurn);
                    if (checkItemRight) continue;
                    if (player._posX == _posX + 1 && player._posY == _posY)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    RefreshTileBehind();
                    _posX++;
                }
                else if (targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '*' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '+' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '=')
                {
                    bool checkItemUp = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1, hud, enemyTurn);
                    if (checkItemUp) continue;
                    if (player._posX == _posX && player._posY == _posY - 1)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    RefreshTileBehind();
                    _posY--;
                }
                else if (targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '*' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '+' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '=')
                {
                    bool checkItemDown = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1, hud, enemyTurn);
                    if (checkItemDown) continue;
                    if (player._posX == _posX && player._posY == _posY + 1)
                    {
                        player._health.TakeDamage(_damage);
                        player._lastEncounteredEnemy = enemyTurn;
                        hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
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
                    RefreshTileBehind();
                    _posY++;
                }
            }
        }
    }
}
