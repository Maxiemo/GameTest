using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Player : Mob, ICombatMob
    {
        public Game game;
        public int MaxHP = 100;
        public int HP = 100;
        public int MaxMP = 4;
        public int MP = 4;
        Image img = Image.FromFile("sprites/mobs/player.png");
        public Player(string name, int x, int y, Area area) : base(name, x, y, area)
        {
        }

        public int GetHP()
        {
            return HP;
        }

        public override Image GetImage()
        {
            return img;
        }

        public void TryDamage(int power)
        {
            HP = Math.Max(0, HP - power);
            game.Refresh();
        }

        public void TryHeal(int power)
        {
            HP = Math.Max(MaxHP, HP + power);
            game.Refresh();
        }

        public void TryHit()
        {

        }
    }
}
