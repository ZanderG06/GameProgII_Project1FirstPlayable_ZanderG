using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Health
    {
        public int health { get; private set; }
        public int maxHealth { get; private set; }

        public Health(int hp)
        {
            health = hp;
            maxHealth = hp;
        }

        public void Heal()
        {
            if (health < maxHealth)
                health++;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}