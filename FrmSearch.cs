using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectIntercept.Player;
using ProjectIntercept.Security;

namespace ProjectIntercept
{
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();
        }
        private readonly PlayerDetails _dets = new PlayerDetails(Hardware.GetPcId(), Hardware.GetMachineId());
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            var tmp = MySql.Commands.QueryGet("SELECT nickname FROM players");
            foreach (var variable in tmp)
            {
                LstPlayers.Items.Add(variable);
            }
            if (_dets.Rank.Contains("Leader"))
                LblIp.Visible = true;
        }

        private void LstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblIp.Items.Clear();

            var tmp = MySql.Commands.QueryGet("SELECT nickname,pcid,windowsversion,ip,lastlogin,status,rank,clan FROM players WHERE nickname='" + LstPlayers.SelectedItem + "'");

            LblNick.Text = tmp[0];
            LblPcId.Text = tmp[1];
            LblVersion.Text = tmp[2];
            lblLastLogin.Text = string.IsNullOrEmpty(tmp[4]) ? @"Never" : (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(Convert.ToDouble(tmp[4])).ToString();

            if (tmp[5] == "1")
                tmp[5] = "Good Standing";
            if (tmp[5] == "0")
                tmp[5] = "Not Activated";
            if (tmp[5] == "-1")
                tmp[5] = "Banned";
            LblStatus.Text = tmp[5];
            LblRank.Text = tmp[6];

            if (tmp[7] == "Join Clan")
                tmp[7] = "None";
            LblClan.Text = tmp[7];

            var tmp2 = MySql.Commands.QueryGet("SELECT ip FROM iphistory WHERE pcid='" + tmp[1] + "'");
            foreach (var ip in tmp2)
            {
                if (LblIp.Items.Contains(ip))
                    continue;
                LblIp.Items.Add(ip);
            }
        }
    }
}
