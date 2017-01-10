namespace ProjectIntercept
{
    partial class FrmRegister
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
            this.BtnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(215, 51);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(75, 23);
            this.BtnRegister.TabIndex = 2;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email Address";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(15, 25);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(128, 20);
            this.TxtEmail.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 34);
            this.label3.TabIndex = 5;
            this.label3.Text = "After registration please check your email for a verification email.";
            // 
            // TxtNick
            // 
            this.TxtNick.Location = new System.Drawing.Point(162, 25);
            this.TxtNick.Name = "TxtNick";
            this.TxtNick.Size = new System.Drawing.Size(128, 20);
            this.TxtNick.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nickname";
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 85);
            this.Controls.Add(this.TxtNick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRegister";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Intercept - Registation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label2;
    }
}