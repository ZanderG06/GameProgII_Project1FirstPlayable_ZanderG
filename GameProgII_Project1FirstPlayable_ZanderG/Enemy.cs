using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Enemy : Health
    {
        public int _posX;
        public int _posY;
        public int _damage;
        public Map _map;

        public Enemy(int hp, int posX, int posY, int damage, Map gameMap) : base(hp)
        {
            _posX = posX;
            _posY = posY;
            _damage = damage;
            _map = gameMap;
        }

        public void MoveEnemy(Player player, List<Enemy> enemy, int enemyTurn)
        {
            if(health <= 0) return;
            Thread.Sleep(250);

            int targetX = player._posX - _posX;
            int targetY = player._posY - _posY;

            if(targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '+')
            {
                if (_map.gold.Contains((_posY, _posX-1))) //Enemies picking up gold is on purpose, their damage can go up like the Player
                {
                    _map.gold.Remove((_posY, _posX-1));
                    _damage++;
                    return;
                }
                if(player._posX == _posX - 1 && player._posY == _posY)
                {
                    player.TakeDamage(_damage);
                    player._lastEncounteredEnemy = enemyTurn;
                    return;
                }
                for(int i = 0; i < enemy.Count; i++)
                {
                    if(i == enemyTurn) //Makes it so that the enemy doesn't check for itself when trying to move
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
            else if (targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '*' || targetX > 0 && _map.mapInGame[_posY][_posX + 1] == '+')
            {
                if (_map.gold.Contains((_posY, _posX + 1)))
                {
                    _map.gold.Remove((_posY, _posX + 1));
                    _damage++;
                    return;
                }
                if (player._posX == _posX + 1 && player._posY == _posY)
                {
                    player.TakeDamage(_damage);
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
            else if (targetY < 0 && _map.mapInGame[_posY-1][_posX] == '*' || targetY < 0 && _map.mapInGame[_posY - 1][_posX] == '+')
            {
                if (_map.gold.Contains((_posY-1, _posX)))
                {
                    _map.gold.Remove((_posY-1, _posX));
                    _damage++;
                    return;
                }
                if (player._posX == _posX && player._posY == _posY-1)
                {
                    player.TakeDamage(_damage);
                    player._lastEncounteredEnemy = enemyTurn;
                    return;
                }
                for(int i = 0; i < enemy.Count; i++)
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
            else if (targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '*' || targetY > 0 && _map.mapInGame[_posY + 1][_posX] == '+')
            {
                if (_map.gold.Contains((_posY + 1, _posX)))
                {
                    _map.gold.Remove((_posY + 1, _posX));
                    _damage++;
                    return;
                }
                if (player._posX == _posX && player._posY == _posY + 1)
                {
                    player.TakeDamage(_damage);
                    player._lastEncounteredEnemy = enemyTurn;
                    return;
                }
                for(int i = 0; i < enemy.Count; i++)
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