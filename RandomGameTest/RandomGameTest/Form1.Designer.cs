﻿namespace RandomGameTest
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
            lv_drops = new ListView();
            label1 = new Label();
            label2 = new Label();
            pb_health = new ProgressBar();
            pb_mana = new ProgressBar();
            labHealth = new Label();
            label3 = new Label();
            button1 = new Button();
            tb_logbox = new TextBox();
            p_minimap = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1029, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_newgame });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmi_newgame
            // 
            tsmi_newgame.Name = "tsmi_newgame";
            tsmi_newgame.Size = new Size(165, 26);
            tsmi_newgame.Text = "New Game";
            tsmi_newgame.Click += tsmi_newgame_Click;
            // 
            // lv_inventory
            // 
            lv_inventory.AllowDrop = true;
            lv_inventory.Location = new Point(587, 314);
            lv_inventory.Margin = new Padding(3, 4, 3, 4);
            lv_inventory.MultiSelect = false;
            lv_inventory.Name = "lv_inventory";
            lv_inventory.ShowItemToolTips = true;
            lv_inventory.Size = new Size(356, 361);
            lv_inventory.TabIndex = 2;
            lv_inventory.TileSize = new Size(64, 64);
            lv_inventory.UseCompatibleStateImageBehavior = false;
            lv_inventory.View = View.Tile;
            lv_inventory.DrawItem += lv_inventory_DrawItem;
            lv_inventory.ItemDrag += lv_inventory_ItemDrag;
            lv_inventory.SelectedIndexChanged += lv_inventory_SelectedIndexChanged;
            lv_inventory.SizeChanged += lv_inventory_SizeChanged;
            lv_inventory.ControlAdded += lv_inventory_ControlAdded;
            lv_inventory.DragDrop += lv_inventory_DragDrop;
            lv_inventory.DragEnter += lv_inventory_DragEnter;
            lv_inventory.MouseEnter += lv_inventory_MouseEnter;
            lv_inventory.Validating += lv_inventory_Validating;
            // 
            // p_mainscreen
            // 
            p_mainscreen.AllowDrop = true;
            p_mainscreen.BackColor = Color.Black;
            p_mainscreen.Location = new Point(24, 36);
            p_mainscreen.Margin = new Padding(3, 4, 3, 4);
            p_mainscreen.Name = "p_mainscreen";
            p_mainscreen.Size = new Size(538, 640);
            p_mainscreen.TabIndex = 3;
            p_mainscreen.DragDrop += p_mainscreen_DragDrop;
            p_mainscreen.DragEnter += p_mainscreen_DragEnter;
            p_mainscreen.Paint += p_mainscreen_Paint;
            // 
            // lv_drops
            // 
            lv_drops.AllowDrop = true;
            lv_drops.Location = new Point(587, 708);
            lv_drops.Margin = new Padding(3, 4, 3, 4);
            lv_drops.MultiSelect = false;
            lv_drops.Name = "lv_drops";
            lv_drops.Size = new Size(356, 261);
            lv_drops.TabIndex = 4;
            lv_drops.UseCompatibleStateImageBehavior = false;
            lv_drops.ItemDrag += lv_drops_ItemDrag;
            lv_drops.DragDrop += lv_drops_DragDrop;
            lv_drops.DragEnter += lv_drops_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 290);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 5;
            label1.Text = "Inventory";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 684);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 6;
            label2.Text = "Items on Ground";
            label2.Click += label2_Click;
            // 
            // pb_health
            // 
            pb_health.ForeColor = Color.Red;
            pb_health.Location = new Point(635, 67);
            pb_health.Margin = new Padding(3, 4, 3, 4);
            pb_health.Name = "pb_health";
            pb_health.Size = new Size(207, 31);
            pb_health.Style = ProgressBarStyle.Continuous;
            pb_health.TabIndex = 7;
            pb_health.Value = 50;
            // 
            // pb_mana
            // 
            pb_mana.ForeColor = Color.DodgerBlue;
            pb_mana.Location = new Point(635, 117);
            pb_mana.Margin = new Padding(3, 4, 3, 4);
            pb_mana.Name = "pb_mana";
            pb_mana.Size = new Size(207, 31);
            pb_mana.Style = ProgressBarStyle.Continuous;
            pb_mana.TabIndex = 8;
            pb_mana.Value = 50;
            pb_mana.Click += pb_mana_Click;
            // 
            // labHealth
            // 
            labHealth.AutoSize = true;
            labHealth.Location = new Point(587, 69);
            labHealth.Name = "labHealth";
            labHealth.Size = new Size(53, 20);
            labHealth.TabIndex = 9;
            labHealth.Text = "Health";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(593, 121);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 10;
            label3.Text = "Mana";
            // 
            // button1
            // 
            button1.Location = new Point(965, 314);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(64, 81);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // tb_logbox
            // 
            tb_logbox.BackColor = Color.White;
            tb_logbox.BorderStyle = BorderStyle.FixedSingle;
            tb_logbox.Location = new Point(24, 708);
            tb_logbox.Multiline = true;
            tb_logbox.Name = "tb_logbox";
            tb_logbox.ReadOnly = true;
            tb_logbox.ScrollBars = ScrollBars.Vertical;
            tb_logbox.Size = new Size(538, 261);
            tb_logbox.TabIndex = 12;
            // 
            // p_minimap
            // 
            p_minimap.Location = new Point(858, 51);
            p_minimap.Name = "p_minimap";
            p_minimap.Size = new Size(195, 195);
            p_minimap.TabIndex = 13;
            p_minimap.Paint += p_minimap_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1029, 987);
            Controls.Add(p_minimap);
            Controls.Add(tb_logbox);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(labHealth);
            Controls.Add(pb_mana);
            Controls.Add(pb_health);
            Controls.Add(lv_drops);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(p_mainscreen);
            Controls.Add(lv_inventory);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Game Thing";
            Load += Form1_Load;
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
        public ListView lv_drops;
        private Label label1;
        private Label label2;
        public ProgressBar pb_health;
        public ProgressBar pb_mana;
        private Label labHealth;
        private Label label3;
        private Button button1;
        public TextBox tb_logbox;
        public Panel p_minimap;
    }
}