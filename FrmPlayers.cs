using System.Windows.Forms;
using System.Threading;
using ProjectIntercept.Player;

namespace ProjectIntercept
{
    public partial class FrmPlayers : Form
    {
        private readonly bool _clan;
        private string _q;
        readonly PlayerDetails _dets = new PlayerDetails(Security.Hardware.GetPcId(), Security.Hardware.GetMachineId());
        public FrmPlayers(bool clan)
        {
            _clan = clan;
            _refresh = new Thread(BegindoRefresh);
            InitializeComponent();
        }

        readonly Thread _refresh;
        private void FrmPlayers_Load(object sender, System.EventArgs e)
        {
            if (_clan)
            {
                _q = string.Format("SELECT nickname FROM players WHERE lastlogin > '{0}' AND clan = '{1}'",
                   Lobby.Player.GetUnixDate() - 90, _dets.Clan);

            }
            else
            {
                _q = string.Format("SELECT nickname FROM players WHERE lastlogin > '{0}'",
                                  Lobby.Player.GetUnixDate() - 90);

            }
            _refresh.Start();
        }

        private delegate void Refr();

        private void BegindoRefresh()
        {
            Refr a = DoRefresh;
            while (true)
            {
                Invoke(a);
                Thread.Sleep(30000);
            }
            // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns
        private void DoRefresh()
        {
            listView1.Items.Clear();

            var theList = MySql.Commands.QueryGet(_q);

            foreach (var a in theList)
            {
                var tmp = MySql.Commands.QueryGet("SELECT server,map FROM players WHERE nickname='" + a + "'");

                var item1 = new ListViewItem(a);
                item1.SubItems.Add(tmp[0]);
                item1.SubItems.Add(tmp[1]);
                listView1.Items.Add(item1);
            }

            // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns

        private void Form_Closing(object sender, System.EventArgs e)
        {
            _refresh.Abort();
        }

        private void DetailsToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                MessageBox.Show(@"Details for " + listView1.SelectedItems[0].Text + @" will be available in the next update!");
        }

        private void MessageToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
            var frmSend = new FrmSend(listView1.SelectedItems[0].Text); 
            frmSend.Show();
        }

        private void ListView1SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
