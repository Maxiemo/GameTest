using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Area
    {
        public string name;
        public int width;
        public int height;
        public Tile[,] tiles;
        public List<Mob> mobs = new List<Mob>();
        public List<ItemDrop> items = new List<ItemDrop>();
        public Area(string name, int width, int height)
        {
            this.name = name;
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            for(int iy = 0; iy < height; iy++)
            {
                for(int ix = 0; ix < width;  ix++)
                {
                    tiles[ix, iy] = new Tile(ix,iy,TileDef.GRASS,this);
                }
            }
        }
        public Area FillRect(TileDef def, int x, int y, int w, int h)
        {
            for(int iy = 0; iy < h; iy++)
            {
                for (int ix = 0; ix < w; ix++)
                {
                    tiles[x + ix, y + iy].def = def;
                }
            }
            return this;
        }
    }
    public class Tile
    {
        public int x;
        public int y;
        public Area area;
        public TileDef def;
        public Tile(int x, int y, TileDef def,Area area)
        {
            this.x = x;
            this.y = y;
            this.area = area;
            this.def = def;
        }
        public Image GetImage()
        {
            return def.image;
        }
    }
}
