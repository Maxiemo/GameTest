﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public virtual bool TryMove(int newx, int newy)
        {
            if (area.IsTileEmpty(newx, newy))
            {
                x = newx;
                y = newy;
                area.GetTile(newx, newy).OnMobEnter(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void ChangeArea(int newx, int newy, Area newarea)
        {
            //Debug.WriteLine("Moving mob to: " + newx + ", " + newy);
            x = newx;
            y = newy;
            area.mobs.Remove(this);
            area = newarea;
            newarea.mobs.Add(this);
        }
        public abstract Image GetImage();
    }
}
