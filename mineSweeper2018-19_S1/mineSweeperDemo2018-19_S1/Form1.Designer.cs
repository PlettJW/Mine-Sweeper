namespace mineSweeperDemo2018_19_S1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easy9X910MinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medium16X940MinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficult32X1699MinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.butReset = new System.Windows.Forms.Button();
            this.lblFlags = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem,
            this.highScoresToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easy9X910MinesToolStripMenuItem,
            this.medium16X940MinesToolStripMenuItem,
            this.difficult32X1699MinesToolStripMenuItem});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.difficultyToolStripMenuItem.Text = "&Difficulty";
            // 
            // easy9X910MinesToolStripMenuItem
            // 
            this.easy9X910MinesToolStripMenuItem.Name = "easy9X910MinesToolStripMenuItem";
            this.easy9X910MinesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.easy9X910MinesToolStripMenuItem.Text = "Easy  (9 x 9, 10 mines)";
            this.easy9X910MinesToolStripMenuItem.Click += new System.EventHandler(this.easy9X910MinesToolStripMenuItem_Click);
            // 
            // medium16X940MinesToolStripMenuItem
            // 
            this.medium16X940MinesToolStripMenuItem.Name = "medium16X940MinesToolStripMenuItem";
            this.medium16X940MinesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.medium16X940MinesToolStripMenuItem.Text = "Normal (16 x 16, 40 mines)";
            this.medium16X940MinesToolStripMenuItem.Click += new System.EventHandler(this.medium16X940MinesToolStripMenuItem_Click);
            // 
            // difficult32X1699MinesToolStripMenuItem
            // 
            this.difficult32X1699MinesToolStripMenuItem.Name = "difficult32X1699MinesToolStripMenuItem";
            this.difficult32X1699MinesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.difficult32X1699MinesToolStripMenuItem.Text = "Heroic (32 x 16, 99 mines)";
            this.difficult32X1699MinesToolStripMenuItem.Click += new System.EventHandler(this.difficult32X1699MinesToolStripMenuItem_Click);
            // 
            // highScoresToolStripMenuItem
            // 
            this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
            this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.highScoresToolStripMenuItem.Text = "HighScores";
            this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(41, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(28, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "0:00";
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(76, 0);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(92, 24);
            this.butReset.TabIndex = 2;
            this.butReset.Text = "Reset";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Location = new System.Drawing.Point(177, 6);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(38, 13);
            this.lblFlags.TabIndex = 3;
            this.lblFlags.Text = "flags:?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFlags);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easy9X910MinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medium16X940MinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficult32X1699MinesToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
    }
}

