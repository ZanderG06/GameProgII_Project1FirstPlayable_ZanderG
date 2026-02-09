using System;
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

        public Enemy(Health health, int posX, int posY)
        {
            _health = health;
            _posX = posX;
            _posY = posY;
        }
    }
}
