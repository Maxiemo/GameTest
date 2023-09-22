namespace RandomGameTest
{
    public partial class Form1 : Form
    {
        public Game CurrentGame;
        public Form1()
        {
            InitializeComponent();
        }

        private void lv_inventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsmi_newgame_Click(object sender, EventArgs e)
        {
            CurrentGame = Game.NewGame(this);
        }

        private void pb_mainscreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentGame != null)
            {
                CurrentGame.HandleKeyPress(e.KeyCode);
            }
        }

        private void p_mainscreen_Paint(object sender, PaintEventArgs e)
        {
            if (CurrentGame != null)
            {
                CurrentGame.DrawScreen(e.Graphics);
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}