using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HealthSystemV3
{
    class Player : Character
    {
        //---------------fields------------
        private int exp;
        private int maxExp;

        // ---------------------------------- Public Methods ----------------------------------

        // ----------------------------------------- Relevant to "ask" of Assignment ------------------------------
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

            SetName();
        }

        public void NewPlayer()
        {
            strength = NewStatCalc(1, 1);
            vitality = NewStatCalc(1, 1);
            magic = NewStatCalc(1, 1);
            speed = NewStatCalc(1, 1);

            level = 1;
            exp = 0;
            maxExp = 50;

            maxHealth = (vitality * 2) + 10;
            maxBarrier = (magic * 2) + 10;
            currentHealth = maxHealth;
            currentBarrier = maxBarrier;

            SetName();
            ResetCharacter();
        } // does the same thing as public Player()... Maybe I just need NewPlayer()?

        public void DisplayHUD()
        {
            //just the essentials like Name, Level, Health, Barrier and Exp.
            Console.WriteLine();
            Console.WriteLine("-------------------- " + name + " --------------------");
            //Console.WriteLine("Name: " + name);
            Console.WriteLine();
            Console.WriteLine("Level: " + level);
            Console.WriteLine();
            Console.WriteLine("Health: " + currentHealth + "/" + maxHealth);
            Console.WriteLine("Barrier: " + currentBarrier + "/" + maxBarrier);
            Console.WriteLine("Exp: " + exp +  "/" + maxExp);
            Console.WriteLine("-----------------------------------------------");
        }

        // ------------------------------------------- Irrelevant to "ask" of Assignment -------------------------------------
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
            Console.WriteLine();
            Console.WriteLine("Attack Power: " + physicalPwr);
            Console.WriteLine("----------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Spell Name: " + currentSpells[0,0] + " Spell Base Damage: " + currentSpells[0,1] + " Spell Uses: " + currentSpells[0,2]);
        }

        public void DisplayTurnOptions()
        {
            Console.WriteLine();
            Console.WriteLine("> 1 - Attack");
            Console.WriteLine("> 2 - Heal");
            Console.WriteLine("> 3 - Defend");
        }

        public void ReadInput()
        {
            Console.WriteLine();
            Console.Write("> ");
            int choice;
            string input = Console.ReadLine();
            int.TryParse(input, out choice);
            while(choice < 1 || choice > 3 || !int.TryParse(input, out choice))
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: Invalid input. Please input again.");
                Console.WriteLine();
                Console.Write("> ");
                input = Console.ReadLine();
                int.TryParse(input, out choice);
            }
            if (choice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("> " + name + " attacks!");
                Console.WriteLine();
                isAtk = true;
                Console.ReadKey(true);
            }
            else if (choice == 2)
            {
                isHealing = true;
                Console.ReadKey(true);
            }
            else if (choice == 3)
            {
                // display defense options (block or evade) and check player input again
                //DisplayDefenseOptions();
                isDef = true;
                Console.ReadKey(true);
            }
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

            Console.WriteLine();
            Console.WriteLine("> " + name + " has leveled up! New Level: " + level);
        }

        public void GainExp(int expGain)
        {
            if(expGain <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! GainExp() cannot take in a negative value or a null value. Value of: int level = " + expGain);
                Console.WriteLine();
                Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            exp = exp + expGain;
            Console.WriteLine();
            Console.WriteLine("> "+name+" has gained " + expGain + " exp!");
            Console.WriteLine();
            Console.ReadKey(true);
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

        public void PlayerDied()
        {
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("GAMEOVER.");
            Console.WriteLine();
            Console.WriteLine("> 1 Play Again?");
            Console.WriteLine("> 2 Quit?");
        }


        // may need this, setting up incase ---------------------------- gets
        public int GetLevel()
        {
            return level;
        }

        /*public int GetMagic()
        {
            return magic;
        }*/

        // ------------------------------------------------------------ sets(pseudo set)
        private void SetName()
        {
            Console.WriteLine("Name your character: ");
            Console.Write("> ");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine();
                Console.WriteLine("Cannot enter a null or empty value for name.");
                Console.WriteLine("Name your character: ");
                Console.Write("> ");
                name = Console.ReadLine();
            }
        }

        // ------------------------------------- Private Methods --------------------------
    }
}
