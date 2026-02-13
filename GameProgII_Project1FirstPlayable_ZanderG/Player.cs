using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Player : Health
    {
        public Map _map;
        public Health _health;
        public int _posX;
        public int _posY;

        public Player(int hp, int posX, int posY, Map gameMap) : base(hp)
        {
            _health = new Health(hp);
            _posX = posX;
            _posY = posY;
            _map = gameMap;
        }

        public void MovePlayer(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.W:
                    if (_posY <= 0) break;
                    if (_map.mapInGame[_posY-1][_posX] == '|' || _map.mapInGame[_posY - 1][_posX] == '-' || _map.mapInGame[_posY - 1][_posX] == '~' || _map.mapInGame[_posY - 1][_posX] == '@') break;
                    if (_map.gold.Contains((_posY - 1, _posX)))
                    {
                        _map.gold.Remove((_posY - 1, _posX));
                        break;
                    }
                    _posY--;
                    break;
                
                case ConsoleKey.S:
                    if (_posY >= _map.mapLength-1) break;
                    if (_map.mapInGame[_posY + 1][_posX] == '|' || _map.mapInGame[_posY + 1][_posX] == '-' || _map.mapInGame[_posY + 1][_posX] == '~' || _map.mapInGame[_posY + 1][_posX] == '@') break;
                    if (_map.gold.Contains((_posY + 1, _posX)))
                    {
                        _map.gold.Remove((_posY + 1, _posX));
                        break;
                    }
                    _posY++;
                    break;
                
                case ConsoleKey.A:
                    if (_posX <= 0) break;
                    if (_map.mapInGame[_posY][_posX-1] == '|' || _map.mapInGame[_posY][_posX-1] == '-' || _map.mapInGame[_posY][_posX-1] == '~' || _map.mapInGame[_posY][_posX-1] == '@') break;
                    if (_map.gold.Contains((_posY, _posX-1)))
                    {
                        _map.gold.Remove((_posY, _posX-1));
                        break;
                    }
                    _posX--;
                    break;
                
                case ConsoleKey.D:
                    if (_posX >= _map.mapHeight-1) break;
                    if (_map.mapInGame[_posY][_posX + 1] == '|' || _map.mapInGame[_posY][_posX + 1] == '-' || _map.mapInGame[_posY][_posX + 1] == '~' || _map.mapInGame[_posY][_posX + 1] == '@') break;
                    if (_map.gold.Contains((_posY, _posX + 1)))
                    {
                        _map.gold.Remove((_posY, _posX + 1));
                        break;
                    }
                    _posX++;
                    break;
            }
        }
    }
}
