namespace RandomGameTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tsmi_newgame = new ToolStripMenuItem();
            lv_inventory = new ListView();
            p_mainscreen = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(816, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_newgame });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmi_newgame
            // 
            tsmi_newgame.Name = "tsmi_newgame";
            tsmi_newgame.Size = new Size(132, 22);
            tsmi_newgame.Text = "New Game";
            tsmi_newgame.Click += tsmi_newgame_Click;
            // 
            // lv_inventory
            // 
            lv_inventory.Location = new Point(529, 241);
            lv_inventory.Name = "lv_inventory";
            lv_inventory.Size = new Size(279, 281);
            lv_inventory.TabIndex = 2;
            lv_inventory.UseCompatibleStateImageBehavior = false;
            lv_inventory.SelectedIndexChanged += lv_inventory_SelectedIndexChanged;
            // 
            // p_mainscreen
            // 
            p_mainscreen.BackColor = Color.Black;
            p_mainscreen.Location = new Point(21, 27);
            p_mainscreen.Name = "p_mainscreen";
            p_mainscreen.Size = new Size(480, 480);
            p_mainscreen.TabIndex = 3;
            p_mainscreen.Paint += p_mainscreen_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 525);
            Controls.Add(p_mainscreen);
            Controls.Add(lv_inventory);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Thing";
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem tsmi_newgame;
        public ListView lv_inventory;
        public Panel p_mainscreen;
    }
}