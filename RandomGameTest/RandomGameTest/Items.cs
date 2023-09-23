using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Item
    {
        public string name;
        public Image image;
        public int value;
        public Item(string name, Image image, int value)
        {
            this.name = name;
            this.image = image;
            this.value = value;
        }
        public Item CloneBasicItem()
        {
            return new Item(name, image, value);
        }
    }
    public class ItemDrop
    {
        public Item item;
        public int x;
        public int y;
        public Area area;
        public ItemDrop(Item item,int x, int y, Area area) {
            area.items.Add(this);
            this.item = item;
            this.x = x;
            this.y = y;
            this.area = area;
        }
        public void Destroy()
        {
            area.items.Remove(this);
            area = null;
            x = -1; y = -1;
        }
    }
    public class ItemDropData : ListViewItem
    {
        public Image image;
        public Item item;
        public ItemDrop drop;
        public ItemDropData(ItemDrop drop)
        {
            this.drop = drop;
            this.item = drop.item;
            this.Text = drop.item.name;
            this.image = drop.item.image;
            ImageIndex = 0;
            
        }
    }
    public class ItemData : ListViewItem
    {
        public Image image;
        public Item item;
        public ItemData(Item item)
        {
            this.item = item;
            this.Text = item.name;
            this.image = item.image;
            ImageIndex = 0;

        }
    }
}
