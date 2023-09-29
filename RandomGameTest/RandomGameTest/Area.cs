using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Game game;
        public Tile[,] tiles;
        public List<RoofArea> roofAreas = new List<RoofArea>();
        public List<Mob> mobs = new List<Mob>();
        public List<ItemDrop> items = new List<ItemDrop>();
        public Dictionary<Direction,Area> Connections = new System.Collections.Generic.Dictionary<Direction,Area>();
        public Area AddConnection(Direction direction, Area area)
        {
            Connections[direction] = area;
            area.Connections[direction.Opposite()] = this;
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
        public void MakeStairs(int x, int y, Area target, int tx, int ty)
        {
            tiles[x, y] = new TransTile(x, y, TileDef.DOWN_STAIRS, this, target, tx, ty);
            target.tiles[tx, ty] = new TransTile(tx, ty, TileDef.UP_STAIRS, target, this, x, y);
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
            if(x >= 0 && y >= 0 && x < tiles.GetLength(0) && y < tiles.GetLength(1))
            {
                return !tiles[x, y].def.solid;
            }
            else
            {
                return false;
            }
            
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
        public virtual void OnMobEnter(Mob mob)
        {
            //Debug.WriteLine("Entered tile: " + x + ", " + y);
        }

        public virtual void OnInteract(Mob mob)
        {
            
        }
    }
    public class TransTile : Tile
    {
        public int tx;
        public int ty;
        public Area targetarea;
        public TransTile(int x, int y, TileDef def, Area area, Area targetarea, int tx, int ty) : base(x, y, def, area)
        {
            this.tx = tx;
            this.ty = ty;
            this.targetarea = targetarea;
        }
        public override void OnInteract(Mob mob)
        {
            mob.ChangeArea(tx, ty, targetarea);
        }
    }
    public struct RoofArea
    {
        public Image image;
        public int x, y, w, h;
        public RoofArea (int x, int y, int w, int h, Image image)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.image = image;
        }
    }

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

    public static class DirExtension
    {
        public static Direction Opposite(this Direction dir)
        {
            switch (dir)
            {
                case (Direction.NORTH):
                    return Direction.SOUTH;
                case (Direction.NORTHEAST):
                    return Direction.SOUTHWEST;
                case (Direction.EAST):
                    return Direction.WEST;
                case (Direction.SOUTHEAST):
                    return Direction.NORTHWEST;
                case (Direction.SOUTH):
                    return Direction.NORTH;
                case (Direction.SOUTHWEST):
                    return Direction.NORTHEAST;
                case (Direction.WEST):
                    return Direction.EAST;
                case (Direction.NORTHWEST):
                    return Direction.SOUTHEAST;

                default:
                    return Direction.NORTH;
            }
        }
    }

}