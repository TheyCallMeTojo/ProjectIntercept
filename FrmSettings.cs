using System;
using System.Windows.Forms;
using ProjectIntercept.Player;

namespace ProjectIntercept
{
    ///<summary>
    ///</summary>
    public partial class FrmSettings : Form
    {
        ///<summary>
        ///</summary>
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (FindExe)
            {
                FindExe.Filter = @"Black Hawk Down|dfbhd.exe";
                FindExe.ShowDialog();
                if (string.IsNullOrEmpty(FindExe.FileName)) return;
                textBox1.Text = FindExe.FileName;
            }
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            Config.Actions.Change("GamePath", FindExe.FileName);
            Dispose();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Config.Actions.Get("GamePath");
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var dets = new PlayerDetails(Security.Hardware.GetPcId(),Security.Hardware.GetMachineId());
            MessageBox.Show(dets.Name);
        }
    }
}
