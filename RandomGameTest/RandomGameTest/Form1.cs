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

        private void lv_inventory_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private void lv_inventory_SizeChanged(object sender, EventArgs e)
        {
        }

        private void lv_inventory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void lv_inventory_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void lv_inventory_MouseEnter(object sender, EventArgs e)
        {
        }

        private void lv_inventory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lv_drops_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lv_inventory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemDropData)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lv_inventory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemDropData)))
            {
                ItemDropData dropdata = (ItemDropData)e.Data.GetData(typeof(ItemDropData));
                ItemData data = new ItemData(dropdata.item);
                dropdata.drop.Destroy();
                dropdata.Remove();
                lv_inventory.Items.Add(data);
                CurrentGame.Refresh();
            }
        }

        private void lv_drops_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemData)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lv_drops_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemData)))
            {
                ItemData data = (ItemData)e.Data.GetData(typeof(ItemData));
                ItemDrop drop = new ItemDrop(data.item, CurrentGame.player.x, CurrentGame.player.y, CurrentGame.player.area);
                data.Remove();
                CurrentGame.Refresh();
            }
        }

        private void p_mainscreen_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemData)))
            {
                ItemData data = (ItemData)e.Data.GetData(typeof(ItemData));
                ItemDrop drop = new ItemDrop(data.item, CurrentGame.player.x, CurrentGame.player.y, CurrentGame.player.area);
                data.Remove();
                CurrentGame.Refresh();
            }
        }

        private void p_mainscreen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemData)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pb_mana_Click(object sender, EventArgs e)
        {

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