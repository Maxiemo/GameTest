using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGameTest
{
    public class Game
    {
        public Form1 MainForm;
        public Panel MainScreen;
        public Graphics MainScreenGraphics;
        public Area CurrentArea;
        public Player player;
        public static Game NewGame(Form1 form)
        {
            Game game = new Game();
            game.MainForm = form;
            game.OnGameStart();
            return game;

        }
        public void OnGameStart()
        {
            MainScreen = MainForm.p_mainscreen;
            MainScreenGraphics = MainScreen.CreateGraphics();
            CurrentArea = new Area("Starting Area", 50, 50);
            CurrentArea.FillRect(TileDef.DIRT, 30, 0, 4, 50);
            player = new Player("Test Player", 20, 20, CurrentArea);
            MainForm.CurrentGame = this;
            Refresh();
        }
        public void Refresh()
        {
            MainScreen.Refresh();
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
            foreach(Mob mob in CurrentArea.mobs)
            {
                if (mob != null)
                {
                    g.DrawImage(mob.GetImage(), new Rectangle((mob.x * 32)-centerx + offx, mob.y * 32 - centery+offy, 32, 32));
                }
            }
            panelg.DrawImage(b, 0, 0);
            g.Dispose();
            b.Dispose();
        }
        public void HandleKeyPress(Keys e)
        {
            switch (e)
            {
                case Keys.W:
                    player.y -= 1;
                    Refresh();
                    break;
                case Keys.A:
                    player.x -= 1;
                    Refresh();
                    break;
                case Keys.S:
                    player.y += 1;
                    Refresh();
                    break;
                case Keys.D:
                    player.x += 1;
                    Refresh();
                    break;
                default:

                    break;
            }
        }
    }
}
