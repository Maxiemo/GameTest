using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    internal interface ICombatMob
    {
        public int GetHP();
        public void TryDamage(int power);
        public void TryHit();
        public void TryHeal(int power);
    }
}
