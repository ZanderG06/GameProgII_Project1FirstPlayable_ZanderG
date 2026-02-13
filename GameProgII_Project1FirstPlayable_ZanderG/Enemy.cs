using System;
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

        public Enemy(int hp, int posX, int posY, int damage) : base(hp)
        {
            _posX = posX;
            _posY = posY;
            _damage = damage;
        }
    }
}