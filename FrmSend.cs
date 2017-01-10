using System;
using System.Windows.Forms;
using ProjectIntercept.Player;

namespace ProjectIntercept
{
    public partial class FrmSend : Form
    {
        private readonly string _name;
        readonly PlayerDetails _dets = new PlayerDetails(Security.Hardware.GetPcId(), Security.Hardware.GetMachineId());
        public FrmSend(string name)
        {
            _name = name;
            InitializeComponent();
        }

        private void FrmSend_Load(object sender, EventArgs e)
        {
            Text += _name;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(@"Please fill out the form and try again");
                return;
            }
            //       "INSERT INTO messages (to,from,subject,body) VALUES ('{0}','{1}','{2}','{3}')"
            const string q = "INSERT INTO messages (mto,mfrom,msubject,mbody) VALUES ('{0}','{1}','{2}','{3}')";
            if (MySql.Commands.QueryEx(string.Format(q, _name, _dets.Name, textBox1.Text, textBox2.Text)))
            { Dispose(); }
            else { MessageBox.Show(@"Unable to send, try again!"); return; }
        }
    }
}
