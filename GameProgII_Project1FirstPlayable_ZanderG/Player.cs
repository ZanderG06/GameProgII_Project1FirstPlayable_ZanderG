using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Player : Health
    {
        public Map _map;
        public int _posX;
        public int _posY;
        public int _damage;

        public Player(int hp, int posX, int posY, int damage, Map gameMap) : base(hp)
        {
            _posX = posX;
            _posY = posY;
            _damage = damage;
            _map = gameMap;
        }

        public void MovePlayer(ConsoleKey input, (int, int) enemy1Pos, (int, int) enemy2Pos, Enemy enemy1, Enemy enemy2)
        {
            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (_posY <= 0) break;
                    if (_map.mapInGame[_posY-1][_posX] == '|' || _map.mapInGame[_posY - 1][_posX] == '-' || _map.mapInGame[_posY - 1][_posX] == '~') break;
                    if (_map.gold.Contains((_posY - 1, _posX)))
                    {
                        _map.gold.Remove((_posY - 1, _posX));
                        _damage++;
                        break;
                    }
                    if(enemy1Pos == (_posY - 1, _posX))
                    {
                        enemy1.TakeDamage(_damage);
                        break;
                    }
                    if(enemy2Pos == (_posY - 1, _posX))
                    {
                        enemy2.TakeDamage(_damage);
                        break;
                    }
                    if(_map.mapInGame[_posY - 1][_posX] == '+') Heal();
                    _posY--;
                    break;
                
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (_posY >= _map.mapLength-1) break;
                    if (_map.mapInGame[_posY + 1][_posX] == '|' || _map.mapInGame[_posY + 1][_posX] == '-' || _map.mapInGame[_posY + 1][_posX] == '~') break;
                    if (_map.gold.Contains((_posY + 1, _posX)))
                    {
                        _map.gold.Remove((_posY + 1, _posX));
                        _damage++;
                        break;
                    }
                    if (enemy1Pos == (_posY + 1, _posX))
                    {
                        enemy1.TakeDamage(_damage);
                        break;
                    }
                    if (enemy2Pos == (_posY + 1, _posX))
                    {
                        enemy2.TakeDamage(_damage);
                        break;
                    }
                    if (_map.mapInGame[_posY + 1][_posX] == '+') Heal();
                    _posY++;
                    break;
                
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (_posX <= 0) break;
                    if (_map.mapInGame[_posY][_posX-1] == '|' || _map.mapInGame[_posY][_posX-1] == '-' || _map.mapInGame[_posY][_posX-1] == '~') break;
                    if (_map.gold.Contains((_posY, _posX-1)))
                    {
                        _map.gold.Remove((_posY, _posX - 1));
                        _damage++;
                        break;
                    }
                    if (enemy1Pos == (_posY, _posX-1))
                    {
                        enemy1.TakeDamage(_damage);
                        break;
                    }
                    if (enemy2Pos == (_posY, _posX-1))
                    {
                        enemy2.TakeDamage(_damage);
                        break;
                    }
                    if (_map.mapInGame[_posY][_posX-1] == '+') Heal();
                    _posX--;
                    break;
                
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (_posX >= _map.mapHeight-1) break;
                    if (_map.mapInGame[_posY][_posX + 1] == '|' || _map.mapInGame[_posY][_posX + 1] == '-' || _map.mapInGame[_posY][_posX + 1] == '~') break;
                    if (_map.gold.Contains((_posY, _posX + 1)))
                    {
                        _map.gold.Remove((_posY, _posX + 1));
                        _damage++;
                        break;
                    }
                    if (enemy1Pos == (_posY, _posX + 1))
                    {
                        enemy1.TakeDamage(_damage);
                        break;
                    }
                    if (enemy2Pos == (_posY, _posX + 1))
                    {
                        enemy2.TakeDamage(_damage);
                        break;
                    }
                    if (_map.mapInGame[_posY][_posX + 1] == '+') Heal();
                    _posX++;
                    break;
            }
        }
    }
}