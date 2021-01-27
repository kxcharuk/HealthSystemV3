using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3
{
    abstract class Character
    {
        //------------- fields --------
        // health var
        protected int maxHealth;
        protected int currentHealth;
        // shield var
        protected int currentBarrier;
        protected int maxBarrier;
        // char stats ?? ----> could be cool to experiment with adjusting stats with each level up and having stats effect health and takedamage
        protected string name;
        protected int level;

        public int strength;
        protected int vitality;
        protected int magic;
        protected int speed;

        protected Random randomNum = new Random();

        // --------- public methods -----------

        public void TakeDamage(int damage)
        {    
            if (damage < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! TakeDamage() cannot take in a negative value. Value of: int damage = " + damage);
                return;
            }
            if(currentBarrier > 0)
            {
                currentBarrier -= damage;
                if(currentBarrier < 0)
                {
                        int spillOver = -currentBarrier;
                        currentHealth -= spillOver;
                }
            }
            else
            {
                currentHealth -= damage;
            }
            Console.WriteLine();
            Console.WriteLine(this.name + " took " + damage + " damage!");
            RangeCheck();
            if(currentHealth == 0)
            {
                Console.WriteLine();
                Console.WriteLine(this.name + " has died...");
            }
        }

        /*public void Heal(int amount)
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += amount;
                if(currentHealth > maxHealth)
                {
                    int spillOver = (currentHealth - maxHealth);
                    currentBarrier += spillOver;
                }
            }
            else
            {
                currentBarrier += amount;
            }
            RangeCheck();
        }*/

        public void Heal(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! Heal() cannot take in a negative value. Value of: int amount = " + amount);
                return;
            }
            Console.WriteLine();
            Console.WriteLine(this.name + " healed " + amount + " health!");
            currentHealth += amount;
            RangeCheck();
        }

        public void RegenerateBarrier(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! RegenerateBarrier() cannot take in a negative value. Value of: int amount = " + amount);
                return;
            }
            Console.WriteLine();
            Console.WriteLine(this.name + " regenerated " + amount + " barrier!");
            currentBarrier += amount;
            RangeCheck();
        }

        // ----------- private methods ----------

        private void RangeCheck()
        {
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            if(currentHealth < 0)
            {
                currentHealth = 0;
            }
            if(currentBarrier > maxBarrier)
            {
                currentBarrier = maxBarrier;
            }
            if(currentBarrier < 0)
            {
                currentBarrier = 0;
            }
        }

    }

}
