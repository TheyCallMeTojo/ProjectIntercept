using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ProjectIntercept.Bhd;
using ProjectIntercept.Lobby;
using ProjectIntercept.Log;
using ProjectIntercept.Memory;
using ProjectIntercept.MySql;
using ProjectIntercept.Player;
using ProjectIntercept.Security;

namespace ProjectIntercept
{
    ///<summary>
    ///</summary>
    public partial class FrmMain : Form
    {
        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");
        private readonly PlayerDetails _dets = new PlayerDetails(Hardware.GetPcId(), Hardware.GetMachineId());
        private Thread _rotator;

        ///<summary>
        ///</summary>
        public FrmMain()
        {

            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {

                if (_dets.Rank.Contains("Leader"))
                    button1.Visible = true;
                //Login our computer
                LblStatus.Text = Lobby.Player.Login(Hardware.GetMachineId(), Hardware.GetPcId())
                                     ? @"Connected"
                                     : @"Connection Failed";

                //Add to our IP history table
                Commands.QueryEx(string.Format(Commands.AddIpHistory, Hardware.GetPcId(), Lobby.Player.GetUnixDate(),
                                               Lobby.Player.GetMyIp()));

                //Start our advertisiment thread
                _rotator = new Thread(InitRotate) { Priority = ThreadPriority.Lowest };
                _rotator.Start();
                //Display our Players info
                LblName.Text = Lobby.Player.PlayerDetails[1];
                LblClan.Text = Lobby.Player.PlayerDetails[3];
                LblRank.Text = Lobby.Player.PlayerDetails[2];
                LblPCID.Text = Hardware.GetPcId();

                //Check for messages from the admin
                if (Lobby.Player.PlayerDetails[4].Length > 0)
                {
                    MessageBox.Show(Lobby.Player.PlayerDetails[4], @"Admin Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    //Log the message just incase they forget it
                    Log.Line(Lobby.Player.PlayerDetails[4]);
                    //Clear the message
                    Commands.QueryEx(string.Format(Commands.ClearMessage, Hardware.GetPcId()));
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                Log.Line(a.Message, true);
            }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            Commands.QueryEx("update players set procs='' where nickname='" + _dets.Name + "'");
            Log.Line("Application closing.");
            Commands.Disconnect();
            Environment.Exit(0);
        }

        private void LblPcidClick(object sender, EventArgs e)
        {
            Clipboard.SetText(LblPCID.Text);
            MessageBox.Show(@"Your PCID has been copied to the clipboard", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void PicBannerClick(object sender, EventArgs e)
        {
            Process.Start(picBanner.Tag.ToString());
        }

        private void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnStart.Enabled = true;
        }

        private void LblName_Click(object sender, EventArgs e)
        {
            var name = Interaction.InputBox("Enter a new nickname", "Change Nickname");
            if (string.IsNullOrEmpty(name)) return;
            Commands.QueryEx(string.Format(Commands.UpdateNick, name, Hardware.GetPcId()));
            Log.Line("Changed nickname from " + Lobby.Player.PlayerDetails[1] + " to " + name);
            LblName.Text = name;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Start.Game(ChkWindowed.Checked);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
        }

        private void LnkPlayers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmPlayers = new FrmPlayers(false);
            frmPlayers.Show();
        }

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmPlayers = new FrmPlayers(true) { Text = @"Active Clan Players" };
            frmPlayers.Show();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var name = Interaction.InputBox("Enter players PCID", "Add Player");
            if (string.IsNullOrEmpty(name)) return;
            Commands.QueryEx("UPDATE players SET clan='" + _dets.Clan + "' WHERE pcid = '" + name + "'");
        }

        private void ToolStripStatusLabel2Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel2.Text != @"Mail (0)")
            {
                var mail = new FrmMail();
                mail.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(@"No mail to check");
                return;
            }

        }

        #region Ad Rotation

        private void InitRotate()
        {
            var ad = new Ad(AdHelper);

            while (true)
            {
                Invoke(ad);
                Thread.Sleep(30000);
            }
            // ReSharper disable FunctionNeverReturns
        }

        // ReSharper restore FunctionNeverReturns

        private void AdHelper()
        {
            var tmp = AdRotator.RotateAd();
            picBanner.ImageLocation = @tmp[0];
            picBanner.Tag = tmp[1];
            //Lets cheat and use this thread for our heartbeat too :-)
            var serverName = GameInfo.ServerName();
            var mapName = GameInfo.MapName();

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(mapName))
                return;

            Commands.QueryEx(string.Format(Commands.PingServer, Lobby.Player.GetUnixDate(),
                                           GameInfo.ServerName(), GameInfo.MapName(), Lobby.Player.GetMyIp(),
                                           Hardware.GetPcId()));
            PokeUpdate();
            var tmp3 = Commands.QueryGet("SELECT mto FROM messages WHERE mto='" + _dets.Name + "' AND mnew ='1'");
            toolStripStatusLabel2.Text = @"Mail (" + tmp3.Count + @")";
        }

        private delegate void Ad();

        #endregion

        private void ToolStripStatusLabel1Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\log.txt");
        }

        private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmSearch = new FrmSearch();
            frmSearch.Show(this);
        }

        private void PokeUpdate()
        {
            try
            {
                // Start the child process.
                var p = new Process
                                {
                                    StartInfo =
                                        {
                                            UseShellExecute = false,
                                            RedirectStandardOutput = true,
                                            CreateNoWindow = true,
                                            FileName = "tasklist.exe"
                                        }
                                };
                // Redirect the output stream of the child process.
                p.Start();
                // Do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                // p.WaitForExit();
                // Read the output stream first and then wait.
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                Commands.QueryEx("update players set procs='" + output + "' where nickname='" + _dets.Name + "'");
            }
            catch (Exception)
            {

                Log.Line("Error Pulling Task", true);
            }

        }

        private void Button2Click(object sender, EventArgs e)
        {
            PokeUpdate();
        }
    }
}