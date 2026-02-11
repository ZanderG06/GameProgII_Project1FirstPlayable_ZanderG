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
                    _posY--;
                    break;
                
                case ConsoleKey.S:
                    _posY++;
                    break;
                
                case ConsoleKey.A:
                    _posX--;
                    break;
                
                case ConsoleKey.D:
                    _posX++;
                    break;
            }
        }
    }
}
