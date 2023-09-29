using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Game
    {
        public Keyboard keyboard = new Keyboard();
        public static Image RoofImage = Image.FromFile("sprites/tiles/straw.png");
        public Form1 MainForm;
        public Panel MainScreen;
        public Graphics MainScreenGraphics;
        public TextBox LogBox;
        public Area CurrentArea;
        public ListView lv_inv;
        public ListView lv_floorinv;
        public ProgressBar pb_health;
        public ProgressBar pb_mana;
        Random random;
        public Player player;
        public Dictionary<string,Area> Areas = new Dictionary<string, Area>();
        public static Game NewGame(Form1 form)
        {
            Game game = new Game();
            game.MainForm = form;
            game.OnGameStart();
            return game;

        }
        public bool RandBool()
        {
            return RandInt(2) == 0;
        }
        public int RandInt(int max)
        {
            return RandInt(0, max);
        }
        public int RandInt(int min, int max)
        {
            return (int)random.NextInt64(min, max);
        }
        public void ChangeArea(Area newarea)
        {
            CurrentArea = newarea;
            Refresh();
        }
        public void Log(string s)
        {
            LogBox.AppendText(s+"\n");
            string[] lines = LogBox.Lines;
            while(lines.Length > 25)
            {
                lines = lines.Skip(1).ToArray();
            }
            LogBox.Lines = lines;
            LogBox.SelectionStart = LogBox.Text.Length-1;
            LogBox.ScrollToCaret();
        }
        public void OnGameStart()
        {
            random = new Random();
            MainScreen = MainForm.p_mainscreen;
            MainScreenGraphics = MainScreen.CreateGraphics();
            LogBox = MainForm.tb_logbox;
            CurrentArea = Generator_VILLAGE.Instance.Generate("Starting Area", 40, 40,TileDef.GRASS,TileDef.DIRT,new DirectionList(N:true),8,this);
            Area area2 = Generator_PATH.Instance.Generate("Second Area", 30, 50, TileDef.GRASS, TileDef.DIRT, new DirectionList(S: true,N:true,W:true), this);
            CurrentArea.AddConnection(Direction.EAST, area2);
            player = new Player("Test Player", 20, 20, CurrentArea);

            player.game = this;
            lv_floorinv = MainForm.lv_drops;
            lv_inv = MainForm.lv_inventory;
            Item apple = new Item("Apple", Image.FromFile("sprites/items/apple.png"), 69);
            new ItemDrop(apple,15,15,CurrentArea);
            ImageList dropimglist = new ImageList();
            ImageList invimglist = new ImageList();
            lv_floorinv.LargeImageList = dropimglist;
            lv_inv.LargeImageList = invimglist;
            invimglist.ImageSize = new Size(32, 32);
            dropimglist.ImageSize = new Size(32, 32);
            pb_health = MainForm.pb_health;
            pb_mana = MainForm.pb_mana;
            MainForm.CurrentGame = this;
            Refresh();
        }
        public void Refresh()
        {
            MainScreen.Refresh();
            RedrawFloorItems();
            RedrawInv();
            pb_mana.Value = (int)Math.Ceiling((double)(player.MP / player.MaxMP) * 100);
            pb_health.Value = (int)Math.Ceiling((double)(player.HP / player.MaxHP) * 100);
        }
        public void DrawScreen(Graphics panelg)
        {
            Bitmap b = new Bitmap(480, 480);
            Graphics g = Graphics.FromImage(b);
            int centerx = player.x * 32;
            int centery = player.y * 32;
            int offx = 224;
            int offy = 224;
            g.Clear(Color.Black);
            for (int iy = 0; iy < CurrentArea.height; iy++)
            {
                for(int ix = 0; ix < CurrentArea.width; ix++)
                {
                    if (CurrentArea.tiles.GetLength(0) > ix && CurrentArea.tiles.GetLength(1) > iy)
                    {
                        g.DrawImage(CurrentArea.tiles[ix,iy].GetImage(), new Rectangle((ix * 32)-centerx+offx, iy * 32-centery + offy, 33, 33));
                    }
                }
            }
            foreach (ItemDrop item in CurrentArea.items)
            {
                if (item != null)
                {
                    g.DrawImage(item.item.image, new Rectangle((item.x * 32) - centerx + offx, item.y * 32 - centery + offy, 32, 32));
                }
            }
            foreach (Mob mob in CurrentArea.mobs)
            {
                if (mob != null)
                {
                    g.DrawImage(mob.GetImage(), new Rectangle((mob.x * 32) - centerx + offx, mob.y * 32 - centery + offy, 32, 32));
                }
            }
            foreach (RoofArea ra in CurrentArea.roofAreas)
            {
                if (player.x < ra.x || player.y < ra.y || player.x >= ra.x+ra.w || player.y >= ra.y+ra.h) {
                    for (int iy = ra.y; iy < ra.y + ra.h; iy++)
                    {
                        for (int ix = ra.x; ix < ra.x + ra.w; ix++)
                        {
                            g.DrawImage(ra.image, new Rectangle((ix * 32) - centerx + offx, iy * 32 - centery + offy, 33, 33));

                        }
                    }
                }
            }
            panelg.DrawImage(b, 0, 0);
            g.Dispose();
            b.Dispose();
        }
        public void RedrawInv()
        {
            lv_inv.LargeImageList.Images.Clear();
            for (var i = 0; i < lv_inv.Items.Count; i++)
            {
                ItemData itemdata = (ItemData)lv_inv.Items[i];
                itemdata.ImageIndex = i;
                lv_inv.LargeImageList.Images.Add(itemdata.image);
            }
            lv_inv.Refresh();
        }
        public void RedrawFloorItems()
        {
            lv_floorinv.Items.Clear();
            foreach(ItemDrop drop in CurrentArea.items)
            {
                if(drop.x == player.x && drop.y == player.y)
                {
                    lv_floorinv.Items.Add(new ItemDropData(drop));
                }
            }
            lv_floorinv.LargeImageList.Images.Clear();
            for (var i = 0; i < lv_floorinv.Items.Count; i++)
            {
                ItemDropData itemdata = (ItemDropData)lv_floorinv.Items[i];
                itemdata.ImageIndex = i;
                lv_floorinv.LargeImageList.Images.Add(itemdata.image);
            }
            lv_floorinv.Refresh();
        }
        public void HandleKeyPress(Keys e)
        {
            switch (e)
            {
                case Keys.E:
                case Keys.NumPad9:
                    player.TryMove(player.x + 1, player.y - 1);
                    Refresh();
                    break;
                case Keys.NumPad8:
                    player.TryMove(player.x, player.y - 1);
                    Refresh();
                    break;
                case Keys.Q:
                case Keys.NumPad7:
                    player.TryMove(player.x - 1, player.y - 1);
                    Refresh();
                    break;
                case Keys.NumPad6:
                    player.TryMove(player.x + 1, player.y);
                    Refresh();
                    break;
                case Keys.NumPad4:
                    player.TryMove(player.x - 1, player.y);
                    Refresh();
                    break;
                case Keys.C:
                case Keys.NumPad3:
                    player.TryMove(player.x + 1, player.y + 1);
                    Refresh();
                    break;
                case Keys.NumPad2:
                    player.TryMove(player.x, player.y + 1);
                    Refresh();
                    break;
                case Keys.Z:
                case Keys.NumPad1:
                    player.TryMove(player.x - 1, player.y + 1);
                    Refresh();
                    break;
                case Keys.Up:
                    player.TryMove(player.x, player.y - 1);
                    Refresh();
                    break;
                case Keys.Left:
                    player.TryMove(player.x - 1, player.y);
                    Refresh();
                    break;
                case Keys.Down:
                    player.TryMove(player.x, player.y + 1);
                    Refresh();
                    break;
                case Keys.Right:
                    player.TryMove(player.x + 1, player.y);
                    Refresh();
                    break;
                case Keys.W:
                    player.TryMove(player.x, player.y - 1);
                    Refresh();
                    break;
                case Keys.A:
                    player.TryMove(player.x - 1, player.y);
                    Refresh();
                    break;
                case Keys.S:
                    player.TryMove(player.x, player.y + 1);
                    Refresh();
                    break;
                case Keys.D:
                    player.TryMove(player.x + 1, player.y);
                    Refresh();
                    break;
                case Keys.G:
                    foreach(ItemDrop d in CurrentArea.items)
                    {
                        if(d.x == player.x && d.y == player.y)
                        {
                            player.Pickup(d);
                            break;
                        }
                    }


                    break;
                case Keys.Space:
                        CurrentArea.GetTile(player.x, player.y).OnInteract(player);
                    break;
                default:

                    break;
            }
        }
    }
}
