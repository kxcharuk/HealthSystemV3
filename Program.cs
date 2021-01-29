using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3
{
    class Program
    {
        static Player myPlayer;
        static Enemy myEnemy;

        static void Main(string[] args)
        {

            Player player = new Player();
            Enemy enemy = new Enemy();
            myPlayer = player;
            myEnemy = enemy;
            TestHealthSystem();
            //StartGame();
        }

        // ------------- Method's related to Assignment --------------
        static void TestHealthSystem()
        {
            // ---------------- ERROR CHECKING
            Console.Clear();
            myPlayer.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking on TakeDamage() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myPlayer.TakeDamage(-10);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myPlayer.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking in Heal() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myPlayer.Heal(-10);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myPlayer.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking in RegenerateBarrier() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myPlayer.RegenerateBarrier(-10);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            // ----------------- RANGE CHECKING
            Console.Clear();
            myPlayer.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing TakeDamage() decreases barrier(shield), and spillsover, decreasing health.");
            Console.ReadKey(true);
            myPlayer.TakeDamage(30);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myPlayer.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing RegenerateBarrier() increases barrier(shield) and range checking.");
            Console.ReadKey(true);
            myPlayer.RegenerateBarrier(75);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);
            myPlayer.TakeDamage(30);

            Console.Clear();
            myPlayer.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine("// Showcasing Heal() increases health and range checking.");
            Console.ReadKey(true);
            myPlayer.Heal(60);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myPlayer.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine("// Showcasing TakeDamage() range checking.");
            Console.ReadKey(true);
            myPlayer.TakeDamage(150);
            Console.ReadKey(true);
            myPlayer.DisplayHUD();
            Console.ReadKey(true);

            // --------------------------------------------- same test but for the enemy object

            Console.Clear();
            Console.WriteLine("THE FOLLOWING IS THE EXACT SAME TEST BUT FOR THE ENEMY OBJECT.");
            Console.ReadKey(true);

            // ---------------- ERROR CHECKING
            Console.Clear();
            myEnemy.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking on TakeDamage() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myEnemy.TakeDamage(-10);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myEnemy.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking in Heal() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myEnemy.Heal(-10);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myEnemy.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing error checking in RegenerateBarrier() by attempting to pass in a negative value.");
            Console.ReadKey(true);
            myEnemy.RegenerateBarrier(-10);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);

            // ----------------- RANGE CHECKING
            Console.Clear();
            myEnemy.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing TakeDamage() decreases barrier(shield), and spillsover, decreasing health.");
            Console.ReadKey(true);
            myEnemy.TakeDamage(30);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myEnemy.DisplayHUD();
            Console.WriteLine();
            Console.WriteLine("// Showcasing RegenerateBarrier() increases barrier(shield) and range checking.");
            Console.ReadKey(true);
            myEnemy.RegenerateBarrier(75);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);
            myEnemy.TakeDamage(30);

            Console.Clear();
            myEnemy.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine("// Showcasing Heal() increases health and range checking.");
            Console.ReadKey(true);
            myEnemy.Heal(60);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);

            Console.Clear();
            myEnemy.DisplayHUD();
            Console.ReadKey(true);
            Console.WriteLine("// Showcasing TakeDamage() range checking.");
            Console.ReadKey(true);
            myEnemy.TakeDamage(150);
            Console.ReadKey(true);
            myEnemy.DisplayHUD();
            Console.ReadKey(true);
        }

        // -------------- Methods related to Gameplay -----------------
        // GAMEPLAY IS NOT FLUSHED OUT OR BALANCED IN ANY MANNER. ALGORITHMS USED TO CALCULATE ATTKPWR ETC. ARE EXTREMELY FLAWED.
        // THIS IS TO PRACTICE CODING INPUT SYTEMS, READING IN TEXT FILES AND EXPERIMENTING WITH OOP(WHO'S JOB IS IT TO DO WHAT).

        static void StartGame()
        {
            PlayerTurn();
        }

        static void CheckIfAlive()
        {
            if(myPlayer.isAlive == false)
            {
                GameOver();
            }
            else if(myEnemy.isAlive == false)
            {
                myPlayer.GainExp(myEnemy.ReturnWorth());
                Console.WriteLine();
                myEnemy.NewEnemy(myPlayer.GetLevel());
            }
            else
            {   
                return;
            }
        }

        static void PlayerTurn()
        {
            CheckIfAlive();
            myPlayer.ResetCharacter();
            NewTurn();
            Console.WriteLine();
            int regenAmount = myPlayer.GetRandRegen();
            myPlayer.RegenerateBarrier(regenAmount);
            
            // Start turn by writing a message to the player that it is their turn
            
            Console.WriteLine("> It is your turn.");

            // display turn options to player (Attack | Spell | Defend)
            myPlayer.DisplayTurnOptions();
            myPlayer.ReadInput(); // returns an int(attack, magatk or defense)
            if (myPlayer.isAtk)
            {
                // modify atk by enemyDef
                int amount = myPlayer.GetPhysicalPwr() / myEnemy.GetPhysicalDef();
                myEnemy.TakeDamage(amount);
                // end turn
            }
            else if (myPlayer.isHealing)
            {
                int amount = myPlayer.GetMagicalPwr() / myPlayer.GetMagicDef();
                myPlayer.Heal(amount);
            }
            else if (myPlayer.isDef)
            {
                myPlayer.ModifyDef();
            }
            // read player input(also need to error check player input)
            Console.ReadKey(true);
            EnemyTurn();
        }

        static void EnemyTurn()
        {
            CheckIfAlive();
            myEnemy.ResetCharacter();
            Console.WriteLine();
            NewTurn();
            myEnemy.EnemyChoice();
            if (myEnemy.isAtk == true)
            {
                // atk
                int damage = myEnemy.GetPhysicalPwr()/myPlayer.GetPhysicalDef();
                myPlayer.TakeDamage(damage);
            }
            else if (myEnemy.isDef == true)
            {
                myEnemy.ModifyDef();
            }
            else if (myEnemy.isMagicAtk == true)
            {
                int damage = myEnemy.UseAbility() / myPlayer.GetMagicDef();
                myPlayer.TakeDamage(damage);
            }
            Console.ReadKey(true);
            PlayerTurn();
        }

        static void NewTurn()
        {
            Console.Clear();
            myEnemy.DisplayHUD();
            Console.WriteLine();
            myPlayer.DisplayHUD();
            // maybe displaying the hud should be in here
        }

        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("GAMEOVER.");
            Console.WriteLine();
            Console.WriteLine("> 1 Play Again?");
            Console.WriteLine("> 2 Quit?");
            string inputString = Console.ReadLine();
            int input;
            int.TryParse(inputString, out input);
            while(!int.TryParse(inputString, out input) || input > 2 || input < 1)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: Invalid input. Please input again.");
                Console.WriteLine();
                Console.Write("> ");
                inputString = Console.ReadLine();
                int.TryParse(inputString, out input);
            }
            if(input == 1)
            {
                Console.Clear();
                myPlayer.NewPlayer();
                myEnemy.NewEnemy(1);
                PlayerTurn();
            }
            else if(input == 2)
            {
                Environment.Exit(-1);
            }
        }
    }
}
