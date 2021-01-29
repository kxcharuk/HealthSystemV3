using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HealthSystemV3
{
    class Enemy : Character
    {
        private string[] enemyList = File.ReadAllLines(@"EnemyInfo.txt");
        private string ability;
        private int abilityUses;
        private int abilityBaseDamage;
        private int worth;

        Random randomNum = new Random();

        // -------------------------------Assignment Methods -----------------
        public Enemy()
        {
            if (!File.Exists(@"EnemyInfo.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("ERROR: File missing: EnemyInfo.txt");
                Console.WriteLine();
                Console.WriteLine("Application cannot proceed. Press any key to close.");
                Console.ReadKey(true);
                Environment.Exit(-1);
            }
            Random randomNum = new Random();
            int rnd = randomNum.Next(0,enemyList.Length);
            string[] unitInfo = enemyList[rnd].Split(';');
            name = unitInfo[0];
            int.TryParse(unitInfo[1], out strength);
            int.TryParse(unitInfo[2], out vitality);
            int.TryParse(unitInfo[3], out magic);
            int.TryParse(unitInfo[4], out speed);
            ability = unitInfo[5];
            int.TryParse(unitInfo[6], out abilityBaseDamage);
            int.TryParse(unitInfo[7], out abilityUses);

            maxHealth = (vitality * 2) + 10;
            maxBarrier = (magic * 2) + 10;
            currentHealth = maxHealth;
            currentBarrier = maxBarrier;

            physicalDef = (strength * vitality) / 2;
            magicalDef = (magic * vitality) / 2;


            worth = (maxHealth + maxBarrier + strength + speed) / 4;

            level = 1;

            Console.WriteLine();
            Console.WriteLine(name + " has appeared! They are looking for a fight...");
        }
        public void DisplayHUD()
        {
            //just the essentials like Name, Level, Health, Barrier and Exp.
            Console.WriteLine();
            Console.WriteLine("---------------- Enemy: " + name + " --------------------");
            //Console.WriteLine("Name: " + name);
            Console.WriteLine();
            Console.WriteLine("Level: " + level);
            Console.WriteLine();
            Console.WriteLine("Health: " + currentHealth + "/" + maxHealth);
            Console.WriteLine("Barrier: " + currentBarrier + "/" + maxBarrier);
            Console.WriteLine("-----------------------------------------------");
        }


        // ----------------------------- Gameplay Methods ---------------------

        //---------------------- public methods

        public void NewEnemy(int playerLevel)
        {
            if(playerLevel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("ERROR! NewEnemy() cannot take in a negative value or a null value. Value of: int playerLevel = " + playerLevel);
                Console.WriteLine();
                Console.WriteLine("Application cannot proceed, press any key to close.");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            if(playerLevel == 1)
            {
                int rnd = randomNum.Next(0, enemyList.Length);
                string[] unitInfo = enemyList[rnd].Split(';');
                name = unitInfo[0];
                int.TryParse(unitInfo[1], out strength);
                int.TryParse(unitInfo[2], out vitality);
                int.TryParse(unitInfo[3], out magic);
                int.TryParse(unitInfo[4], out speed);
                ability = unitInfo[5];
                int.TryParse(unitInfo[6], out abilityBaseDamage);
                int.TryParse(unitInfo[7], out abilityUses);

                maxHealth = (vitality * 2) + 10;
                maxBarrier = (magic * 2) + 10;
                currentHealth = maxHealth;
                currentBarrier = maxBarrier;

                worth = (maxHealth + maxBarrier + strength + speed) / 4;
            }
            else
            {
                int enemyStatMod = playerLevel * 2;
                strength = NewStatCalc(enemyStatMod, strength);
                vitality = NewStatCalc(enemyStatMod, vitality);
                magic = NewStatCalc(enemyStatMod, magic);
                speed = NewStatCalc(enemyStatMod, speed);

                maxHealth = (vitality * 2) + 10;
                maxBarrier = (magic * 2) + 10;
                currentHealth = maxHealth;
                currentBarrier = maxBarrier;

                level = playerLevel;

                worth = (maxHealth + maxBarrier + strength + speed) / 4;
            }
            ResetCharacter();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(name + " has appeared! They are looking for a fight...");
            Console.ReadKey(true);
        }

        public void EnemyChoice()
        {
            // Send message to player that it is the enemies turn
            Console.WriteLine();
            Console.WriteLine("> It is " + name + "'s turn.");
            Console.WriteLine();
            // Regenerate some of barrier (arbitrary battle mechanic, shield regenerates a little each turn)
            int rndRegen = randomNum.Next(1, magic);
            regenAmount = (magic + rndRegen) / 2;
            RegenerateBarrier(regenAmount);
            // Randomly select an action for the enemy (Attack | Ability (if uses still available) | Defend)
            if(abilityUses > 0)
            {
                //choose between attack, ability and defend
                int choice = randomNum.Next(1, 3);
                if(choice == 1)
                {
                    // attack
                    Console.WriteLine();
                    Console.WriteLine("> " + name + " attacked!");
                    Console.WriteLine();
                    isAtk = true;
                    Console.ReadKey(true);
                }
                else if(choice == 2)
                {
                    // use ability
                    Console.WriteLine();
                    Console.WriteLine("> " + name + " used " + ability + "!");
                    Console.WriteLine();
                    isMagicAtk = true;
                    Console.ReadKey(true);
                }
                else if(choice == 3)
                {
                    // defend
                    Console.WriteLine();
                    Console.WriteLine("> " + name + " is defending!");
                    Console.WriteLine();
                    isDef = true;
                    Console.ReadKey(true);
                }
            }
            else if(abilityUses == 0)
            {
                int choice = randomNum.Next(1, 2);
                if(choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("> " + name + " attacked!");
                    Console.WriteLine();
                    isAtk = true;
                    Console.ReadKey(true);
                }
                else if(choice == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("> "+ name + " is defending!");
                    Console.WriteLine();
                    isDef = true;
                    Console.ReadKey(true);
                }
            }
            // Display the enemies choice and the results
        }

        public int ReturnWorth()
        {
            return worth;
        }

        public int UseAbility()
        {
            int damage = (abilityBaseDamage * magic * 2);
            abilityUses = abilityUses - 1;
            return damage;
        }

    }
}
