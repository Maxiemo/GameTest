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
        public override void ChangeArea(int newx, int newy, Area newarea)
        {
            base.ChangeArea(newx, newy, newarea);
            game.ChangeArea(newarea);
        }
        public override bool TryMove(int newx, int newy)
        {
            if (area.IsTileEmpty(newx, newy))
            {
                x = newx;
                y = newy;
                return true;
            }
            else
            {
                if(newy < 0 && area.Connections.ContainsKey(Direction.NORTH))
                {
                    Area newarea = area.Connections[Direction.NORTH];
                    if (newarea.IsTileEmpty(x - (area.width / 2) + (newarea.width / 2), newarea.height - 1))
                    {
                        ChangeArea(x - (area.width / 2) + (newarea.width / 2), newarea.height - 1, newarea);
                        return true;
                    }
                }
                if (newy >= area.height && area.Connections.ContainsKey(Direction.SOUTH))
                {
                    Area newarea = area.Connections[Direction.SOUTH];
                    if (newarea.IsTileEmpty(x - (area.width / 2) + (newarea.width / 2), 0))
                    {
                        ChangeArea(x - (area.width / 2) + (newarea.width / 2), 0, newarea);
                        return true;
                    }
                }
                if (newx >= area.width && area.Connections.ContainsKey(Direction.EAST))
                {
                    Area newarea = area.Connections[Direction.EAST];
                    if (newarea.IsTileEmpty(0, y - (area.height / 2) + (newarea.height / 2)))
                    {
                        ChangeArea(0, y - (area.height / 2) + (newarea.height / 2),newarea);
                        return true;
                    }
                }
                if (newx < 0 && area.Connections.ContainsKey(Direction.WEST))
                {
                    Area newarea = area.Connections[Direction.WEST];
                    if (newarea.IsTileEmpty(newarea.width-1,y - (area.height / 2) + (newarea.height / 2)))
                    {
                        ChangeArea(newarea.width - 1, y - (area.height / 2) + (newarea.height / 2),newarea);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
