using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ProjectIntercept.Log;
using ProjectIntercept.Memory;

namespace ProjectIntercept.Bhd
{
    public static class GameThreads
    {


        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr hProcess, Int32 dwMinimumWorkingSetSize,
                                                            Int32 dwMaximumWorkingSetSize);

        public static string GameName;



        static readonly Write Line = new Write(Application.StartupPath + "\\log.txt");

        //internal static bool Working;

        internal static void LowerMemoryUsage()
        {
            var theApp = Process.GetCurrentProcess();
            SetProcessWorkingSetSize(theApp.Handle, -1, -1);
        }

        internal static void ServerChangeEvent()
        {
            var serverNameOld = ReadProcMems.ReadString((IntPtr)0x9ED6B8);

            while (true)
            {
                Thread.Sleep(1000);
                var serverName = ReadProcMems.ReadString((IntPtr)0x9ED6B8);
                //Fist check if it's changed

                if (serverName != serverNameOld && serverName.Length > 0)
                {
                    serverNameOld = serverName;
                    GameName = GameInfo.ServerName();
                    Line.Line("Server change: " + GameInfo.ServerName());
                    MySql.Commands.QueryEx("INSERT INTO gamehistory (pcid,date,gameid,server,ip) VALUES('" + Security.Hardware.GetPcId() + "','" + Lobby.Player.GetUnixDate() + "','" + Start.TheGame.Id + "','" + GameInfo.ServerName().Replace("'", "") + "','" + GameInfo.ServerIp() + "')");
                }
                Thread.Sleep(10000);
            }
            // ReSharper disable FunctionNeverReturns
        }

        // ReSharper restore Func

        internal static void ScanMem()
        {

            var i = Data.CAddy.Capacity - 2;

            while (true)
            {
                Thread.Sleep(1000);
                for (var j = 0; j < i; j++)//?
                {
                    if (ReadProcMems.ReadInt16((IntPtr)Convert.ToInt32(Data.CAddy[j], 16)).ToString() !=
                        Data.CValue[j])
                    {
                        // if (Working)
                        //return;
                        //MessageBox.Show(@"You'd normally be banned right now");
                        Line.Line("Suspicion reported [" + Data.CAddy[j] + "] != " + Data.CValue[j]);
                        //Lobby.Player.BanPlayer("Memory Alteration: " + Games.BHD.Data.c_desc[j]);
                        // Working = true;
                    } //end if                        

                } //end for
            } //end while
        }
    }
}