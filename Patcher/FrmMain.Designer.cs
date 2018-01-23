namespace Patcher2
{
    partial class FrmMain
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
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.lblinf = new System.Windows.Forms.Label();
            this.cbBackup = new System.Windows.Forms.CheckBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.btnVerifyPatch = new System.Windows.Forms.Button();
            this.btnPatch = new System.Windows.Forms.Button();
            this.ms1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.ms1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.lblinf);
            this.gb1.Controls.Add(this.cbBackup);
            this.gb1.Controls.Add(this.pb1);
            this.gb1.Controls.Add(this.btnVerifyPatch);
            this.gb1.Controls.Add(this.btnPatch);
            this.gb1.Location = new System.Drawing.Point(2, 26);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(363, 169);
            this.gb1.TabIndex = 24;
            this.gb1.TabStop = false;
            this.gb1.Text = "CodeJock Skin Framework disabler";
            // 
            // lblinf
            // 
            this.lblinf.AutoSize = true;
            this.lblinf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinf.Location = new System.Drawing.Point(220, 16);
            this.lblinf.Name = "lblinf";
            this.lblinf.Size = new System.Drawing.Size(124, 15);
            this.lblinf.TabIndex = 26;
            this.lblinf.Text = "Windows 10 Patch";
            // 
            // cbBackup
            // 
            this.cbBackup.AutoSize = true;
            this.cbBackup.Checked = true;
            this.cbBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBackup.Location = new System.Drawing.Point(66, 105);
            this.cbBackup.Name = "cbBackup";
            this.cbBackup.Size = new System.Drawing.Size(92, 17);
            this.cbBackup.TabIndex = 25;
            this.cbBackup.Text = "Make backup";
            this.cbBackup.UseVisualStyleBackColor = true;
            // 
            // pb1
            // 
            this.pb1.Image = global::Patcher2.Properties.Resources.codejock;
            this.pb1.Location = new System.Drawing.Point(60, 45);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(240, 50);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb1.TabIndex = 23;
            this.pb1.TabStop = false;
            // 
            // btnVerifyPatch
            // 
            this.btnVerifyPatch.Location = new System.Drawing.Point(193, 132);
            this.btnVerifyPatch.Name = "btnVerifyPatch";
            this.btnVerifyPatch.Size = new System.Drawing.Size(109, 23);
            this.btnVerifyPatch.TabIndex = 24;
            this.btnVerifyPatch.Text = "Verify patch";
            this.btnVerifyPatch.Click += new System.EventHandler(this.btnVerifyPatch_Click);
            // 
            // btnPatch
            // 
            this.btnPatch.Location = new System.Drawing.Point(60, 132);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(109, 23);
            this.btnPatch.TabIndex = 21;
            this.btnPatch.Text = "Apply patch";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // ms1
            // 
            this.ms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.ms1.Location = new System.Drawing.Point(0, 0);
            this.ms1.Name = "ms1";
            this.ms1.Size = new System.Drawing.Size(367, 24);
            this.ms1.TabIndex = 26;
            this.ms1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 196);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.ms1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.ms1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: 5D Embroidory Organizer 9.5.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ms1.ResumeLayout(false);
            this.ms1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnVerifyPatch;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.MenuStrip ms1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.CheckBox cbBackup;
        private System.Windows.Forms.Label lblinf;
    }
}

