using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();
            //player.DisplayStats();


            //------------------------------------- Testing Level Up System
            //Console.WriteLine(enemy.strength);
            //player.LevelUp();
            //player.GainExp(75);
            //Console.WriteLine();
            //Console.WriteLine("Level up!!");
            //Console.WriteLine();
            //Console.ReadKey(true);
            //player.DisplayStats();
            //player.GainExp(200);
            //Console.ReadKey(true);
            //player.DisplayStats();

            //----------------------------------- Testing player.TakeDamage();
            // -------- ERROR CHECKING
            /*player.TakeDamage(-10); 
            Console.WriteLine();
            Console.ReadKey(true);
            player.DisplayStats();
            player.Heal(-10);
            player.RegenerateBarrier(-10);*/
            // -------- RANGE CHECKING
            Console.WriteLine();
            player.DisplayStats();
            Console.WriteLine();
            Console.WriteLine("Showcasing TakeDamage() spillover.");
            player.TakeDamage(30);
            Console.WriteLine();
            player.DisplayStats();
            Console.ReadKey(true);

            Console.WriteLine();
            Console.WriteLine("Showcasing RegenerateBarrier() range checking.");
            player.RegenerateBarrier(50);
            Console.WriteLine();
            player.DisplayStats();
            Console.ReadKey(true);

            player.TakeDamage(30);
            Console.ReadKey(true);

            Console.WriteLine("Showcasing Heal() range checking.");
            Console.WriteLine();
            player.DisplayStats();
            player.Heal(50);
            Console.ReadKey(true);

            Console.WriteLine("Showcasing TakeDamage() range checking.");
            Console.WriteLine();
            player.DisplayStats();
            player.TakeDamage(150);
            Console.ReadKey(true);

            Console.WriteLine();
            player.DisplayStats();
            

            Console.ReadKey(true);
        }
    }
}
