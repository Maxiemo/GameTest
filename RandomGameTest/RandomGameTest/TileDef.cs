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
        public TileDef(string Name, Image image)
        {
            this.Name = Name;
            this.image = image;
        }

        public static TileDef GRASS = new TileDef("Grass", Image.FromFile("sprites/tiles/grass.png"));
        public static TileDef DIRT = new TileDef("Dirt", Image.FromFile("sprites/tiles/dirt.png"));
    }
}
