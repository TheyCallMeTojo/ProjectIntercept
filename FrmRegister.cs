using System;
using System.Windows.Forms;
using ProjectIntercept.Security;

namespace ProjectIntercept
{
    ///<summary>
    ///</summary>
    public partial class FrmRegister : Form
    {
        ///<summary>
        ///</summary>
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (Computer.RegisterPlayer(TxtEmail.Text, TxtNick.Text))
            {
                MessageBox.Show(@"Please verifiy your email before using the software", @"Thanks", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Lobby.Email.SendEmail(Hardware.GetPcId(), Hardware.GetMachineId(), TxtEmail.Text);
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show(@"It seems I can't register you right now, try again later", @"Registration Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}