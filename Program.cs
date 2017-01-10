using System;
using System.IO;
using System.Windows.Forms;
using ProjectIntercept.Log;
using ProjectIntercept.MySql;
using ProjectIntercept.Security;

namespace ProjectIntercept
{
    internal static class Program
    {
        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Clipboard.SetText(Security.Hardware.GetPcId());
            //Check for our config file
            if (!File.Exists(Application.StartupPath + "\\mySettings.xml"))
                Config.Actions.ResetDefaults();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Create our connection
            Commands.Connect();

            //Is the lobby accepting connections
            if (!Network.IsLobbyOnline())
            {
                MessageBox.Show(@"The Lobby is currently offline, try again later", @"Lobby Message",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Log.Line("Lobby is offline.");
                Environment.Exit(0);
            }
            
            //does this computer exist?
            if (!Computer.CheckComputerExist())
            {
                Log.Line("Computer not recognized, attempting registration. {" + Hardware.GetPcId() + "}");
                var results = MessageBox.Show(@"This computer needs registered, do it now?",
                                                       @"Unidentified Computer", MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation);

                if (results == DialogResult.Yes)
                {
                    var regThis = new FrmRegister();
                    regThis.ShowDialog();
                }
                else
                {
                    Log.Line("Computer not recognized, user declined registration request.");
                    Environment.Exit(0);
                }
            }

           
            Log.Line("All test passed, attempting login. {" + Hardware.GetMachineId() + "}");
            Application.Run(new FrmMain());
        }
    }
}