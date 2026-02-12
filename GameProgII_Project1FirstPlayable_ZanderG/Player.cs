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
        public Map map = new Map();
        public Health _health;
        public int _posX;
        public int _posY;

        public Player(int hp, int posX, int posY) : base(hp)
        {
            _health = new Health(hp);
            _posX = posX;
            _posY = posY;
        }

        public void MovePlayer(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.W:
                    if (_posY <= 0) break;
                    if (map.mapInGame[_posY-1][_posX] == '|' || map.mapInGame[_posY - 1][_posX] == '-' || map.mapInGame[_posY - 1][_posX] == '~' || map.mapInGame[_posY - 1][_posX] == '@') break;
                    for(int i = 0; i < map.gold.Count; i++)
                    {
                        if(map.gold.Contains((_posY-1, _posX)))
                        {
                            break;
                        }
                    }
                    _posY--;
                    break;
                
                case ConsoleKey.S:
                    if (_posY >= map.mapLength-1) break;
                    if (map.mapInGame[_posY + 1][_posX] == '|' || map.mapInGame[_posY + 1][_posX] == '-' || map.mapInGame[_posY + 1][_posX] == '~' || map.mapInGame[_posY + 1][_posX] == '@') break;
                    _posY++;
                    break;
                
                case ConsoleKey.A:
                    if (_posX <= 0) break;
                    if (map.mapInGame[_posY][_posX-1] == '|' || map.mapInGame[_posY][_posX-1] == '-' || map.mapInGame[_posY][_posX-1] == '~' || map.mapInGame[_posY][_posX-1] == '@') break;
                    _posX--;
                    break;
                
                case ConsoleKey.D:
                    if (_posX >= map.mapHeight-1) break;
                    if (map.mapInGame[_posY][_posX + 1] == '|' || map.mapInGame[_posY][_posX + 1] == '-' || map.mapInGame[_posY][_posX + 1] == '~' || map.mapInGame[_posY][_posX + 1] == '@') break;
                    _posX++;
                    break;
            }
        }
    }
}
