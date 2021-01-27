using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3
{
    class Player : Character
    {

        //---------------fields-----------
        int exp;
        int maxExp;

        // -------------- Public Methods ---------------
        public Player()
        {

            strength = NewStatCalc(1,1);
            vitality = NewStatCalc(1,1);
            magic = NewStatCalc(1,1);
            speed = NewStatCalc(1,1);

            level = 1;
            exp = 0;
            maxExp = 50;

            maxHealth = (vitality * 2) + 10;
            maxBarrier = (magic * 2) + 10;
            currentHealth = maxHealth;
            currentBarrier = maxBarrier;

            Console.WriteLine("What is you name?");
            name = Console.ReadLine();
        }
        

        public void DisplayStats()
        {
            //Console.WriteLine("------------- Status -------------");
            Console.WriteLine("------------- Stats --------------");
            Console.WriteLine(name);
            Console.WriteLine();
            Console.WriteLine("Level: " + level);
            Console.WriteLine();
            Console.WriteLine("Health: " + currentHealth + "/" + maxHealth);
            Console.WriteLine("Shield: " + currentBarrier + "/" + maxBarrier);
            Console.WriteLine("Exp: " + exp + "/" + maxExp);
            Console.WriteLine();
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Vitality: " + vitality);
            Console.WriteLine("Speed: " + speed);
            Console.WriteLine("Magic: " + magic);
            Console.WriteLine("----------------------------------");
        }

        //--------------------- Private Methods -------------------
        private int NewStatCalc(int level, int currentStat)
        {
            int rnd = randomNum.Next(1, 10);
            int newStat;
            int minStatGrowth = 2;
            int rndIncrease;
            rndIncrease = (rnd + level) / 2;
            newStat = currentStat + minStatGrowth + rndIncrease;

            return newStat;
        }

        public void LevelUp()
        {
            level = level+1;
            strength = NewStatCalc(strength, level);
            vitality = NewStatCalc(vitality, level);
            magic = NewStatCalc(magic, level);
            speed = NewStatCalc(speed, level);

            maxHealth = (vitality * 2) + 10;
            maxBarrier = (magic * 2) + 10;

            currentHealth = maxHealth;
            currentBarrier = maxBarrier;

        }

        public void GainExp(int expGain)
        {
            exp = exp + expGain;
            if(exp >= maxExp)
            {
                int spillOver;
                spillOver = exp - maxExp;
                exp = spillOver;
                int newMaxExp;
                LevelUp();
                newMaxExp = (maxExp + level) * 2;
                maxExp = newMaxExp;
            }
        }
    }
}
