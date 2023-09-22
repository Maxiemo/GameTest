using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public abstract class Mob
    {
        public int x;
        public int y;
        public Area area;
        public Mob(string name, int x, int y, Area area)
        {
            this.x = x;
            this.y = y;
            this.area = area;
            this.area.mobs.Add(this);
        }
        public void ChangeArea(int newx, int newy, Area newarea)
        {
            x = newx;
            y = newy;
            area.mobs.Remove(this);
            area = newarea;
            newarea.mobs.Add(this);
        }
        public abstract Image GetImage();
    }
}
