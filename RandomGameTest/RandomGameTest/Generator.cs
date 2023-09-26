using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public interface Generator
    {
        public Area Generate(string name, int w, int h, Game game);
    }
    public struct DirectionList
    {
        public Dictionary<Direction,bool> dirs = new Dictionary<Direction,bool>();
        public Direction GetRandom(Game game)
        {
            List<Direction> list = new List<Direction>();
            if (dirs[Direction.NORTH]) { list.Add(Direction.NORTH); }
            if (dirs[Direction.NORTHEAST]) { list.Add(Direction.NORTHEAST); }
            if (dirs[Direction.EAST]) { list.Add(Direction.EAST); }
            if (dirs[Direction.SOUTHEAST]) { list.Add(Direction.SOUTHEAST); }
            if (dirs[Direction.SOUTH]) { list.Add(Direction.SOUTH); }
            if (dirs[Direction.SOUTHWEST]) { list.Add(Direction.SOUTHWEST); }
            if (dirs[Direction.WEST]) { list.Add(Direction.WEST); }
            if (dirs[Direction.NORTHWEST]) { list.Add(Direction.NORTHWEST); }
            return list[game.RandInt(list.Count)];
        }
        public DirectionList(bool N = false,bool NE = false, bool E = false, bool SE = false, bool S = false, bool SW = false, bool W = false, bool NW = false)
        {
            dirs.Add(Direction.NORTH, N);
            dirs.Add(Direction.NORTHEAST, NE);
            dirs.Add(Direction.EAST, E);
            dirs.Add(Direction.SOUTHEAST, SE);
            dirs.Add(Direction.SOUTH,S);
            dirs.Add(Direction.SOUTHWEST, SW);
            dirs.Add(Direction.WEST, W);
            dirs.Add(Direction.NORTHWEST, NW);
        }
    }
    public class Generator_PATH : Generator
    {
        public static Generator_PATH Instance = new Generator_PATH();
        public Area Generate(string name, int w, int h, TileDef floormat, TileDef pathmat, DirectionList DL, Game game)
        {

            Area area = new Area(name, w, h, game);
            area.FillRect(floormat, 0, 0, w, h);
            if (DL.dirs[Direction.NORTH])
            {
                area.FillRect(pathmat, (int)Math.Floor(w / 2d) - 1, 0, 3, (int)Math.Floor(h/2d));
            }
            if (DL.dirs[Direction.SOUTH])
            {
                area.FillRect(pathmat, (int)Math.Floor(w / 2d) - 1, (int)Math.Floor(h / 2d), 3, (int)Math.Floor(h / 2d));
            }
            if (DL.dirs[Direction.WEST])
            {
                area.FillRect(pathmat, 0,(int)Math.Floor(h / 2d)-1, (int)Math.Floor(w / 2d), 3);
            }
            if (DL.dirs[Direction.EAST])
            {
                area.FillRect(pathmat, (int)Math.Floor(w / 2d), (int)Math.Floor(w / 2d)-1, (int)Math.Floor(w/ 2d), 3);
            }

            return area;
        }

        public Area Generate(string name, int w, int h, Game game)
        {
            return Generate(name, w, h, TileDef.GRASS,TileDef.DIRT,new DirectionList(), game);
        }
    }
    public class Generator_VILLAGE : Generator
    {
        public static Generator_VILLAGE Instance = new Generator_VILLAGE();
        public Area Generate(string name, int w, int h, TileDef floormat, TileDef pathmat, DirectionList DL, Game game)
        {
            Area area = Generator_PATH.Instance.Generate(name,w,h,floormat,pathmat,DL,game);
            for (int i = 0; i < 3; i++)
            {
                GenerateHouse(TileDef.WOOD, TileDef.WOOD_WALL, DL, area, game);
            }
            area.ReplaceInRect(TileDef.PATH_PLACEHOLDER, TileDef.DIRT, 0, 0, area.width, area.height);
            return area;
        }

        public Area Generate(string name, int w, int h, Game game)
        {
            return Generate(name, w, h,  TileDef.WOOD,TileDef.WOOD_WALL, new DirectionList(N:true),game);
        }
        public void GeneratePath (Direction dir, Direction stepdir, int x, int y, Area area, Game game)
        {
            int dx = 0;
            int dy = 0;
            int sx = 0;
            int sy = 0;
            TileDef pathmat = TileDef.PATH_PLACEHOLDER;
            switch (dir)
            {
                case Direction.NORTH:
                    dy = -1;
                    break;
                case Direction.SOUTH:
                    dy = 1;
                    break;
                case Direction.WEST:
                    dx = -1;
                    break;
                case Direction.EAST:
                    dx = 1;
                    break;
            }
            switch (stepdir)
            {
                case Direction.NORTH:
                    sy = -1;
                    break;
                case Direction.SOUTH:
                    sy = 1;
                    break;
                case Direction.WEST:
                    sx = -1;
                    break;
                case Direction.EAST:
                    sx = 1;
                    break;
            }
            x += dx;
            y += dy;
            while(x >= 0 && y >= 0 && x < area.width && y < area.height && area.GetTileDef(x,y) != pathmat)
            {
                area.SetTile(x, y, pathmat);
                if (area.IsTileEmpty(x,y))
                {
                    x += dx;
                    y += dy;
                }
                else
                {
                    x -= dx;
                    y -= dy;
                    x += sx;
                    y += sy;
                }
            }
        }
        public bool GenerateHouse(TileDef floor, TileDef walls, DirectionList DL, Area area, Game game)
        {
            int w = -1;
            int h = -1;
            int x = -1;
            int y = -1;
            Direction road = DL.GetRandom(game);
            switch (road)
            {
                case Direction.NORTH:
                    bool side;
                    int attempts = 0;
                    bool foundspace = false;
                    while (!foundspace && attempts < 25)
                    {
                        side = game.RandBool();
                        w = game.RandInt(4) + 5;
                        h = game.RandInt(5) + 8;
                        if (area.width / 2 >= 14 && area.height / 2 >= 20)
                        {
                            if (side)
                            {
                                x = game.RandInt(7, (area.width / 2) - 7);
                                y = game.RandInt(10, (area.height / 2) - 10);
                                if (area.IsRectEmpty(x- (w / 2), y-(h / 2), w,h))
                                {
                                    foundspace = true;
                                    GeneratePath(Direction.EAST, Direction.NORTH, x, y, area, game);

                                    area.FillRect(walls, x - (w / 2), y - (h / 2), w, h);
                                    area.FillRect(floor, x - (w / 2) + 1, y - (h / 2) + 1, w - 2, h - 2);
                                }
                                else
                                {
                                    attempts++;
                                }
                            }
                            else
                            {
                                x = game.RandInt((area.width / 2)+7, area.width - 7);
                                y = game.RandInt(10, (area.height / 2) - 10);
                                if (area.IsRectEmpty(x - (w / 2), y - (h / 2), w, h))
                                {
                                    foundspace = true;
                                    GeneratePath(Direction.WEST, Direction.NORTH, x, y, area, game);
                                    area.FillRect(walls, x - (w / 2), y - (h / 2), w, h);
                                    area.FillRect(floor, x - (w / 2)+1, y - (h / 2)+1, w-2, h-2);
                                }
                                else
                                {
                                    attempts++;
                                }
                            }
                        }
                        else
                        {
                            attempts = 100;
                        }
                    }
                    if (foundspace)
                    {
                        Debug.WriteLine("Built house: (" + x + "," + y + "," + w + "," + h + ")");
                    }
                    else
                    {
                        Debug.WriteLine("Failed to build a house.");
                    }
                    return foundspace;
                default:
                    return false;
            }
        }
    }
}
