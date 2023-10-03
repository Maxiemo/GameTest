using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    
    public class TileDef
    {
        public readonly Image image;
        public readonly string Name;
        public readonly bool solid;
        public TileDef(string Name, Image image, bool solid = false)
        {
            this.Name = Name;
            this.image = image;
            this.solid = solid;
        }

        public static TileDef GRASS = new TileDef("Grass", Image.FromFile("sprites/tiles/grass.png"));
        public static TileDef DIRT = new TileDef("Dirt", Image.FromFile("sprites/tiles/dirt.png"));
        public static TileDef WOOD = new TileDef("Wood", Image.FromFile("sprites/tiles/wood.png"));
        public static TileDef WOOD_WALL = new TileDef("Wood Wall", Image.FromFile("sprites/tiles/woodwall.png"),true);
        public static TileDef PATH_PLACEHOLDER = new TileDef("ERROR PATH PLACEHOLDER",Image.FromFile("sprites/tiles/placeholder.png"),true);
        public static TileDef DOWN_STAIRS = new TileDef("Down Stairs", Image.FromFile("sprites/tiles/downstairs.png"),false);
        public static TileDef UP_STAIRS = new TileDef("Up Stairs", Image.FromFile("sprites/tiles/upstairs.png"), false);
        public static TileDef STONE = new TileDef("Stone", Image.FromFile("sprites/tiles/stone.png"), false);
        public static TileDef STONE_WALL = new TileDef("Stone", Image.FromFile("sprites/tiles/stonewall.png"), true);
        public static TileDef PH_ROOMWALL = new TileDef("ROOM WALL PLACEHOLDER", Image.FromFile("sprites/tiles/placeholder.png"), true);
        public static TileDef PH_ROOMINSIDE = new TileDef("ROOM FLOOR PLACEHOLDER", Image.FromFile("sprites/tiles/placeholder.png"), true);
        public static TileDef PH_EMPTY = new TileDef("EMPTY PLACEHOLDER", Image.FromFile("sprites/tiles/placeholder.png"), false);

    }
}
