namespace ProjectIntercept
{
    partial class FrmSearch
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
            this.LstPlayers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblClan = new System.Windows.Forms.Label();
            this.LblRank = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblPcId = new System.Windows.Forms.Label();
            this.LblNick = new System.Windows.Forms.Label();
            this.LblIp = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstPlayers
            // 
            this.LstPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPlayers.FormattingEnabled = true;
            this.LstPlayers.ItemHeight = 18;
            this.LstPlayers.Location = new System.Drawing.Point(12, 12);
            this.LstPlayers.Name = "LstPlayers";
            this.LstPlayers.Size = new System.Drawing.Size(175, 364);
            this.LstPlayers.TabIndex = 0;
            this.LstPlayers.SelectedIndexChanged += new System.EventHandler(this.LstPlayers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nickname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(517, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "PCID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Windows Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(517, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "IP History";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(207, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Last Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(517, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(209, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Rank";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(517, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Clan";
            // 
            // LblClan
            // 
            this.LblClan.AutoSize = true;
            this.LblClan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClan.ForeColor = System.Drawing.Color.Blue;
            this.LblClan.Location = new System.Drawing.Point(517, 267);
            this.LblClan.Name = "LblClan";
            this.LblClan.Size = new System.Drawing.Size(32, 15);
            this.LblClan.TabIndex = 16;
            this.LblClan.Text = "Clan";
            // 
            // LblRank
            // 
            this.LblRank.AutoSize = true;
            this.LblRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRank.ForeColor = System.Drawing.Color.Blue;
            this.LblRank.Location = new System.Drawing.Point(209, 267);
            this.LblRank.Name = "LblRank";
            this.LblRank.Size = new System.Drawing.Size(36, 15);
            this.LblRank.TabIndex = 15;
            this.LblRank.Text = "Rank";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.ForeColor = System.Drawing.Color.Blue;
            this.LblStatus.Location = new System.Drawing.Point(517, 213);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(41, 15);
            this.LblStatus.TabIndex = 14;
            this.LblStatus.Text = "Status";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLogin.ForeColor = System.Drawing.Color.Blue;
            this.lblLastLogin.Location = new System.Drawing.Point(207, 213);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(64, 15);
            this.lblLastLogin.TabIndex = 13;
            this.lblLastLogin.Text = "Last Login";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(207, 159);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(101, 15);
            this.LblVersion.TabIndex = 11;
            this.LblVersion.Text = "Windows Version";
            // 
            // LblPcId
            // 
            this.LblPcId.AutoSize = true;
            this.LblPcId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPcId.ForeColor = System.Drawing.Color.Blue;
            this.LblPcId.Location = new System.Drawing.Point(517, 105);
            this.LblPcId.Name = "LblPcId";
            this.LblPcId.Size = new System.Drawing.Size(35, 15);
            this.LblPcId.TabIndex = 10;
            this.LblPcId.Text = "PCID";
            // 
            // LblNick
            // 
            this.LblNick.AutoSize = true;
            this.LblNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNick.ForeColor = System.Drawing.Color.Blue;
            this.LblNick.Location = new System.Drawing.Point(207, 105);
            this.LblNick.Name = "LblNick";
            this.LblNick.Size = new System.Drawing.Size(63, 15);
            this.LblNick.TabIndex = 9;
            this.LblNick.Text = "Nickname";
            // 
            // LblIp
            // 
            this.LblIp.FormattingEnabled = true;
            this.LblIp.Location = new System.Drawing.Point(520, 159);
            this.LblIp.Name = "LblIp";
            this.LblIp.Size = new System.Drawing.Size(160, 21);
            this.LblIp.TabIndex = 17;
            this.LblIp.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(517, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Permission Denied";
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 391);
            this.Controls.Add(this.LblIp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblClan);
            this.Controls.Add(this.LblRank);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.lblLastLogin);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblPcId);
            this.Controls.Add(this.LblNick);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearch";
            this.ShowIcon = false;
            this.Text = "Global Player Information Database";
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblClan;
        private System.Windows.Forms.Label LblRank;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblPcId;
        private System.Windows.Forms.Label LblNick;
        private System.Windows.Forms.ComboBox LblIp;
        private System.Windows.Forms.Label label9;
    }
}