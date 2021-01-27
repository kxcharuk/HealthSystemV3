using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3
{
    class Enemy : Character
    {
        int worth;

        public Enemy()
        {
            int rnd = randomNum.Next(1,10);
            level = 1;
            strength = (level + rnd)/2;
            vitality = 0;
            magic = 0;
            speed = 0;

            maxHealth = (vitality * 2) + 10;
            maxBarrier = (magic * 2) + 10;
        }
    }
}
