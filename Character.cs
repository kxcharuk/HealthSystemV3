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

        protected int strength;
        protected int vitality;
        protected int magic;
        protected int speed;

        protected int physicalPwr;
        protected int magicalPwr;

        protected int physicalDef;
        protected int magicalDef;

        //protected int evasion;

        protected int regenAmount;

        // char state var
        public bool isAlive = true;
        public bool isAtk;
        public bool isMagicAtk;
        public bool isHealing;
        public bool isDef;

        // random class
        Random randomNum = new Random();

        // -----------------------------------------Relevant to "ask" of Assignment ------------------------------

        // ----------- private methods ----------
        private void RangeCheck()
        {
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            if (currentBarrier > maxBarrier)
            {
                currentBarrier = maxBarrier;
            }
            if (currentBarrier < 0)
            {
                currentBarrier = 0;
            }
        }

        // --------- public methods -----------
        public void TakeDamage(int damage)
        {    
            if (damage < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! TakeDamage() cannot take in a negative value. Value of: int damage = " + damage);

                //--------------- NOTE: FOLLOWING CODE OMITTED FOR TESTING PURPOSES --------------
                /*Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);*/

                return; // return; EXISTS ONLY FOR TESTING PURPOSES. REMOVE AND REPLACE WITH ABOVE CODE.
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
            Console.WriteLine("> " + name + " took " + damage + " damage!");
            RangeCheck();
            if(currentHealth == 0)
            {
                Console.WriteLine();
                Console.WriteLine("> " + name + " has died...");
                isAlive = false;
            }
        }
        public void RegenerateBarrier(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! RegenerateBarrier() cannot take in a negative value. Value of: int amount = " + amount);
                //--------------- NOTE: FOLLOWING CODE OMITTED FOR MASS TESTING PURPOSES: SHOULD INCLUDE IN FINAL BUILD ----------
                /*Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);*/

                return; // return; EXISTS ONLY FOR TESTING PURPOSES. REMOVE AND REPLACE WITH ABOVE CODE.
            }
            Console.WriteLine();
            Console.WriteLine("> " + name + " regenerated " + amount + " barrier!");
            Console.WriteLine();
            currentBarrier += amount;
            RangeCheck();
        }
        public void Heal(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! Heal() cannot take in a negative value. Value of: int amount = " + amount);
                //--------------- NOTE: FOLLOWING CODE OMITED FOR MASS TESTING PURPOSES: SHOULD INCLUDE IN FINAL BUILD ----------
                /*Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);*/

                return; // return; EXISTS ONLY FOR TESTING PURPOSES. REMOVE AND REPLACE WITH ABOVE CODE.
            }
            Console.WriteLine();
            Console.WriteLine("> " + name + " healed " + amount + " health!");
            currentHealth += amount;
            RangeCheck();
        }

        //------------------------------------------- Irrelevant to "ask" of Assignment -------------------------------------
        protected int NewStatCalc(int level, int currentStat)
        {
            if (level <= 0 || currentStat <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("ERROR! NewStatCalc() cannot take in a negative value or a null value. Value of: int level = " + level + " Value of: int currentStat = " + currentStat);
                Console.WriteLine();
                Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            //int rnd = randomNum.Next(1, 10);
            int newStat;
            int minStatGrowth = 2;
            int rndIncrease;
            rndIncrease = (randomNum.Next(1,10) + level) / 2;
            newStat = currentStat + minStatGrowth + rndIncrease;
            return newStat;
        }

        // ----------------------------------------------- gets
        public int GetPhysicalPwr()
        {
            //Random randomNum = new Random();
            int atkRnd = randomNum.Next(strength, (strength * 3) / 2);
            physicalPwr = (strength * strength * atkRnd);
            return physicalPwr;
        }

        public int GetMagicalPwr()
        {
            //Random randomNum = new Random();
            int mgkRnd = randomNum.Next(magic, (magic * 3) / 2);
            magicalPwr = (magic * magic * mgkRnd);
            return magicalPwr;
        }

        public int GetPhysicalDef()
        {
            physicalDef = (strength * vitality) / 2;
            return physicalDef;
        }


        public int GetMagicDef()
        {
            magicalDef = (magic * vitality) / 2;
            return magicalDef;
        }

        public int GetRandRegen()
        {
            //Random randomNum = new Random();
            int rndRegen = randomNum.Next(1, magic);
            int regenAmount = (magic + rndRegen) / 2;
            return regenAmount;
        }

        //---------------------------------------------- sets(psuedo sets? still a modifier I suppose)
        public void ModifyDef()
        {
            physicalDef = (physicalDef * 3) / 2;
            magicalDef = (magicalDef * 3) / 2;
        }
        
        public void ResetCharacter()
        {
            isAtk = false;
            isMagicAtk = false;
            isHealing = false;
            isDef = false;
            isAlive = true;
            ResetDefence();
        }

        public void ResetDefence()
        {
            physicalDef = (strength * vitality) / 2;
        }


    }
}
