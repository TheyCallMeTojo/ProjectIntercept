using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProjectIntercept.Log;
using ProjectIntercept.Memory;
using ProjectIntercept.MySql;

namespace ProjectIntercept.Bhd
{
    internal class Start
    {


        private static string _bhdPath;
        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");
        public static Thread CheckServerEvents;
        public static Thread CheckMemoryCheats;
        public static Process TheGame;
        private static string _args = "";

        public static int Game(bool windowed)
        {
            _bhdPath = Config.Actions.Get("GamePath").ToLower().Replace("dfbhd.exe", "");

            //MessageBox.Show(_bhdPath);
            if (string.IsNullOrEmpty(_bhdPath))
            {
                MessageBox.Show(@"Please set the game path in the settings dialog!", @"Game Path Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frmSettings = new FrmSettings();
                Log.Line("_bhdPath was empty, asking for location now.");
                frmSettings.ShowDialog();
                return 0;
            }

            //Get recent Cheat Information Database
            Data.GetCheatData();

            if (windowed)
                _args = "/w";
            try
            {
                Directory.SetCurrentDirectory(@_bhdPath);
            }
            catch (Exception ex)
            {
                Log.Line(ex.Message);
            }
            TheGame = new Process
                          {
                              StartInfo =
                                  {
                                      FileName = _bhdPath + "dfbhd.exe",
                                      Arguments = _args
                                  },
                              EnableRaisingEvents = true
                          };
            //Setup our Process exited event handler
            TheGame.Exited += GameDied;
            
            //Start the game
            TheGame.Start();
            ReadProcMems.MProcess = TheGame;
            //Here I will start the cheat detection
            CheckMemoryCheats = new Thread(GameThreads.ScanMem);
            CheckMemoryCheats.Start();
            Log.Line("Game with id: " + TheGame.Id + " has started");
            //Monitor server changes
            CheckServerEvents = new Thread(GameThreads.ServerChangeEvent);
            CheckServerEvents.Start();
            return 0;

            //Just incase I decide to use this for something else.
        }

        private static void GameDied(object sender, EventArgs e)
        {
            CheckMemoryCheats.Abort();
            CheckServerEvents.Abort();
            Log.Line("Game with id: " + TheGame.Id + " has ended");
        }
    }

    internal class Data
    {
        internal static List<string> CAddy = new List<string>();
        internal static List<string> CValue = new List<string>();
        internal static List<string> CDesc = new List<string>();
        // ReSharper disable InconsistentNaming
        internal static List<string> TData = new List<string>();
        // ReSharper restore InconsistentNaming

        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");

        internal static void GetCheatData()
        {
            try
            {
                CAddy = Commands.QueryGet("SELECT address FROM cheats");
                CValue = Commands.QueryGet("SELECT value FROM cheats");
                CDesc = Commands.QueryGet("SELECT description from cheats");
                //Known Cheat Window Titles
                TData = Commands.QueryGet("SELECT name FROM cheat_titles");

                Log.Line("Cheat database updated and checks have passed");
            }
            catch (Exception ex)
            {
                var log = new Write(Application.StartupPath + "\\log.txt");
                log.Line(ex.Message);
            }

        }
    }
}