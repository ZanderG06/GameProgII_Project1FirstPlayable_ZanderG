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

        public void Heal(int healAmount)
        {
            health += healAmount;

            if (health > maxHealth) health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health < 0) health = 0;
        }

        public void IncreaseMaxHealth()
        {
            maxHealth++;
            health = maxHealth;
        }
    }
}