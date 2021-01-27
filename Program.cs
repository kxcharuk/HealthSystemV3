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
            player.DisplayStats();
            //Console.WriteLine(enemy.strength);
            //player.LevelUp();
            player.GainExp(75);
            Console.WriteLine();
            //Console.WriteLine("Level up!!");
            Console.WriteLine();
            Console.ReadKey(true);
            player.DisplayStats();
            player.GainExp(200);
            Console.ReadKey(true);
            player.DisplayStats();
            Console.ReadKey(true);
        }
    }
}
