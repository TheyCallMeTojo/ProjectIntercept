using System.ComponentModel;

namespace ProjectIntercept
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
            this.components = new System.ComponentModel.Container();
            this.StMain = new System.Windows.Forms.StatusStrip();
            this.LblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblName = new System.Windows.Forms.Label();
            this.LblClan = new System.Windows.Forms.Label();
            this.LblPCID = new System.Windows.Forms.Label();
            this.LblRank = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LnkPlayers = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ChkWindowed = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.StMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // StMain
            // 
            this.StMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblStatus,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2});
            this.StMain.Location = new System.Drawing.Point(0, 315);
            this.StMain.Name = "StMain";
            this.StMain.Size = new System.Drawing.Size(253, 22);
            this.StMain.SizingGrip = false;
            this.StMain.TabIndex = 1;
            this.StMain.Text = "      ";
            // 
            // LblStatus
            // 
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(65, 17);
            this.LblStatus.Text = "Not Ready!";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel3.Text = "      ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "View Log";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.ToolStripStatusLabel1Click);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel4.Text = "      ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel2.Text = "Mail:";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.ToolStripStatusLabel2Click);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblName.ForeColor = System.Drawing.Color.Blue;
            this.LblName.Location = new System.Drawing.Point(56, 9);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(38, 13);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Name:";
            this.toolTip1.SetToolTip(this.LblName, "Click to change nickname");
            this.LblName.Click += new System.EventHandler(this.LblName_Click);
            // 
            // LblClan
            // 
            this.LblClan.AutoSize = true;
            this.LblClan.ForeColor = System.Drawing.Color.Green;
            this.LblClan.Location = new System.Drawing.Point(56, 33);
            this.LblClan.Name = "LblClan";
            this.LblClan.Size = new System.Drawing.Size(31, 13);
            this.LblClan.TabIndex = 3;
            this.LblClan.Text = "Clan:";
            // 
            // LblPCID
            // 
            this.LblPCID.AutoSize = true;
            this.LblPCID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblPCID.ForeColor = System.Drawing.Color.Red;
            this.LblPCID.Location = new System.Drawing.Point(56, 81);
            this.LblPCID.Name = "LblPCID";
            this.LblPCID.Size = new System.Drawing.Size(35, 13);
            this.LblPCID.TabIndex = 5;
            this.LblPCID.Text = "PCID:";
            this.toolTip1.SetToolTip(this.LblPCID, "Click to copy");
            this.LblPCID.Click += new System.EventHandler(this.LblPcidClick);
            // 
            // LblRank
            // 
            this.LblRank.AutoSize = true;
            this.LblRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LblRank.Location = new System.Drawing.Point(56, 57);
            this.LblRank.Name = "LblRank";
            this.LblRank.Size = new System.Drawing.Size(36, 13);
            this.LblRank.TabIndex = 4;
            this.LblRank.Text = "Rank:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "PCID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rank:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Clan:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picBanner
            // 
            this.picBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBanner.Location = new System.Drawing.Point(6, 231);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(240, 80);
            this.picBanner.TabIndex = 10;
            this.picBanner.TabStop = false;
            this.picBanner.Click += new System.EventHandler(this.PicBannerClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Black Hawk Down",
            "Black Hawk Down - Shock"});
            this.comboBox1.Location = new System.Drawing.Point(26, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Select Game";
            // 
            // BtnSettings
            // 
            this.BtnSettings.Location = new System.Drawing.Point(26, 169);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(75, 23);
            this.BtnSettings.TabIndex = 13;
            this.BtnSettings.Text = "Settings";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Enabled = false;
            this.BtnStart.Location = new System.Drawing.Point(151, 169);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 14;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LnkPlayers
            // 
            this.LnkPlayers.AutoSize = true;
            this.LnkPlayers.Location = new System.Drawing.Point(36, 204);
            this.LnkPlayers.Name = "LnkPlayers";
            this.LnkPlayers.Size = new System.Drawing.Size(67, 13);
            this.LnkPlayers.TabIndex = 15;
            this.LnkPlayers.TabStop = true;
            this.LnkPlayers.Text = "View Players";
            this.LnkPlayers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkPlayers_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 20;
            this.button1.Text = "+";
            this.toolTip1.SetToolTip(this.button1, "Add player to clan");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // ChkWindowed
            // 
            this.ChkWindowed.AutoSize = true;
            this.ChkWindowed.Location = new System.Drawing.Point(26, 148);
            this.ChkWindowed.Name = "ChkWindowed";
            this.ChkWindowed.Size = new System.Drawing.Size(77, 17);
            this.ChkWindowed.TabIndex = 18;
            this.ChkWindowed.Text = "Windowed";
            this.ChkWindowed.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(109, 204);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(45, 13);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "My Clan";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.Location = new System.Drawing.Point(161, 204);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 13);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Search";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 337);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ChkWindowed);
            this.Controls.Add(this.LnkPlayers);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnSettings);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblPCID);
            this.Controls.Add(this.LblRank);
            this.Controls.Add(this.LblClan);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.StMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Project Intercept 2.0";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmMain_Closing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.StMain.ResumeLayout(false);
            this.StMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StMain;
        private System.Windows.Forms.ToolStripStatusLabel LblStatus;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblClan;
        private System.Windows.Forms.Label LblPCID;
        private System.Windows.Forms.Label LblRank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.LinkLabel LnkPlayers;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ChkWindowed;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.LinkLabel linkLabel2;

        
    }
}

