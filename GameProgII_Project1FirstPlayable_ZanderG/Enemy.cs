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
        public char _icon;

        public Enemy(int hp, int posX, int posY, int damage, Map gameMap, char icon)
        {
            _health = new Health(hp);
            _posX = posX;
            _posY = posY;
            _damage = damage;
            _map = gameMap;
            _icon = icon;
        }

        //SO MANY IF STATEMENTS
        public virtual void Move(Player player, List<Enemy> enemy, int enemyTurn, List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, Hud hud)
        {
            if(_health.health <= 0) return;

            int targetX = player._posX - _posX;
            int targetY = player._posY - _posY;

            if (targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '+' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '=')
            {
                bool checkItemLeft = CheckForItem(gold, healthUp, healthMax, _posX - 1, _posY, hud, enemyTurn); //Enemies picking up items is on purpose
                if (checkItemLeft) return;
                if (player._posX == _posX - 1 && player._posY == _posY)
                {
                    player._health.TakeDamage(_damage);
                    player._lastEncounteredEnemy = enemyTurn;
                    hud.ChangeEventLog($"Enemy{enemyTurn + 1} attacked Player for {_damage} damage", _map);
                    return;
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
                _posX--;
            }
            else if (targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '*' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '+' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '=')
            {
                bool checkItemRight = CheckForItem(gold, healthUp, healthMax, _posX + 1, _posY, hud, enemyTurn);
                if (checkItemRight) return;
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
                _posX++;
            }
            else if (targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '*' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '+' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '=')
            {
                bool checkItemUp = CheckForItem(gold, healthUp, healthMax, _posX, _posY - 1, hud, enemyTurn);
                if (checkItemUp) return;
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
                _posY--;
            }
            else if (targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '*' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '+' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '=')
            {
                bool checkItemDown = CheckForItem(gold, healthUp, healthMax, _posX, _posY + 1, hud, enemyTurn);
                if (checkItemDown) return;
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
                _posY++;
            }
        }

        public bool CheckForItem(List<(int, int)> gold, List<(int, int)> healthUp, List<(int, int)> healthMax, int Xpos, int Ypos, Hud hud, int currentEnemy)
        {
            if (gold.Contains((Ypos, Xpos)))
            {
                gold.Remove((Ypos, Xpos));
                _damage++;
                hud.ChangeEventLog($"Enemy{currentEnemy+1} damage went up by 1", _map);
                return true;
            }
            if (healthUp.Contains((Ypos, Xpos)))
            {
                healthUp.Remove((Ypos, Xpos));
                _health.Heal(3);
                hud.ChangeEventLog($"Enemy{currentEnemy + 1} healed 3 health points", _map);
                return true;
            }
            if (healthMax.Contains((Ypos, Xpos)))
            {
                healthMax.Remove((Ypos, Xpos));
                _health.IncreaseMaxHealth();
                hud.ChangeEventLog($"Enemy{currentEnemy + 1}'s max health increased + full heal", _map);
                return true;
            }
            return false;
        }
    }
}