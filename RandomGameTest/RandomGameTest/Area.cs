using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public enum Direction
    {
        NORTH,
        NORTHEAST,
        EAST,
        SOUTHEAST,
        SOUTH,
        SOUTHWEST,
        WEST,
        NORTHWEST
    }    
    public class Area
    {
        public string name;
        public int width;
        public int height;
        public Game game;
        public Tile[,] tiles;
        public List<Mob> mobs = new List<Mob>();
        public List<ItemDrop> items = new List<ItemDrop>();
        public Dictionary<Direction,Area> Connections = new System.Collections.Generic.Dictionary<Direction,Area>();
        public Area AddConnection(Direction direction, Area area)
        {
            Connections[direction] = area;
            return this;
        }
        public Area(string name, int width, int height, Game game)
        {
            this.game = game;
            if (game.Areas.ContainsKey(name))
            {
                throw new Exception("Tried to create area " + name + " but that area already exists in current game.");
            }
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
            game.Areas.Add(name, this);
        }
        public Area FillRect(TileDef def, int x, int y, int w, int h)
        {
            for (int iy = 0; iy < h; iy++)
            {
                for (int ix = 0; ix < w; ix++)
                {
                    tiles[x + ix, y + iy].def = def;
                }
            }
            return this;
        }
        public Area ReplaceInRect(TileDef olddef,TileDef newdef, int x, int y, int w, int h)
        {
            for(int iy = 0; iy < h; iy++)
            {
                for (int ix = 0; ix < w; ix++)
                {
                    if (tiles[x + ix, y + iy].def == olddef)
                    {
                        tiles[x + ix, y + iy].def = newdef;
                    }
                }
            }
            return this;
        }
        public void SetTile(int x, int y, TileDef def)
        {
            tiles[x,y].def = def;
        }
        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }
        public TileDef GetTileDef(int x, int y)
        {
            return tiles[x, y].def;
        }
        public bool IsTileEmpty(int x, int y)
        {
            return !tiles[x, y].def.solid;
        }
        public bool IsRectEmpty(int x, int y, int w, int h)
        {
            for(int iy = 0; iy < h; iy++)
            {
                for (int ix = 0; ix < w; ix++)
                {
                    if (tiles[x + ix, y + iy].def.solid) return false;
                }
            }
            return true;
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