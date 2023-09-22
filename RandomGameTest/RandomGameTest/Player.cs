using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Player : Mob
    {
        Image img = Image.FromFile("sprites/mobs/player.png");
        public Player(string name, int x, int y, Area area) : base(name, x, y, area)
        {
        }

        public override Image GetImage()
        {
            return img;
        }
    }
}
