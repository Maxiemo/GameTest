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
        public static TileDef WOOD_WALL = new TileDef("WoodWall", Image.FromFile("sprites/tiles/woodwall.png"),false);
        public static TileDef PATH_PLACEHOLDER = new TileDef("ERROR PATH PLACEHOLDER",Image.FromFile("sprites/tiles/placeholder.png"),false);
    }
}
