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

        public void MoveEnemy(int playerPosX, int playerPosY)
        {
            if(health <= 0) return;
            Thread.Sleep(500);

            int targetX = playerPosX - _posX;
            int targetY = playerPosY - _posY;

            if(targetX < 0 && _map.mapInGame[_posY][_posX - 1] == '*')
            {
                _posX--;
            }
            else if (targetX < 0 && _map.mapInGame[_posY][_posX + 1] == '*')
            {
                _posX++;
            }
            else if (targetX < 0 && _map.mapInGame[_posY-1][_posX] == '*')
            {
                _posY--;
            }
            else if (targetX < 0 && _map.mapInGame[_posY + 1][_posX] == '*')
            {
                _posY++;
            }
        }
    }
}