using System;
using System.Windows.Forms;
using ProjectIntercept.Player;

namespace ProjectIntercept
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        readonly PlayerDetails _dets = new PlayerDetails(Security.Hardware.GetPcId(), Security.Hardware.GetMachineId());

        private void FrmMail_Load(object sender, EventArgs e)
        {

            var theList = MySql.Commands.QueryGet("SELECT mpcid FROM messages WHERE mto='" + _dets.Name + "'");

            foreach (var a in theList)
            {
                var tmp = MySql.Commands.QueryGet("SELECT mfrom,msubject,mbody FROM messages WHERE mpcid='" + a + "'");

                var item1 = new ListViewItem(tmp[0]);
                item1.SubItems.Add(tmp[1]);
                item1.SubItems.Add(tmp[2]);
                listView1.Items.Add(item1);
            }
        }

        private void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
            var tmp = listView1.SelectedItems[0].SubItems[2].Text;
            var tmp2 = listView1.SelectedItems[0].Text;

            MySql.Commands.QueryEx("UPDATE messages SET mnew='0' WHERE mfrom = '" + tmp2 + "' AND mbody='" + tmp + "'");
        }
    }
}
