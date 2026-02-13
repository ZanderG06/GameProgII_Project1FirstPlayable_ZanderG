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

        public void MoveEnemy(Player player)
        {
            if(health <= 0) return;
            Thread.Sleep(500);

            int targetX = player._posX - _posX;
            int targetY = player._posY - _posY;

            if(targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*' || targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '+')
            {
                if (_map.gold.Contains((_posY, _posX-1)))
                {
                    _map.gold.Remove((_posY, _posX-1));
                    _damage++;
                    return;
                }
                if(player._posX == _posX - 1 && player._posY == _posY)
                {
                    player.TakeDamage(_damage);
                    return;
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
                    return;
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
                    return;
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
                    return;
                }
                _posY++;
            }
        }
    }
}