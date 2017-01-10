using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ProjectIntercept.MySql;

namespace ProjectIntercept.Lobby
{
    internal class Player
    {
        private const string LoginQ = "SELECT hardwareid,pcid,status FROM players WHERE hardwareid='{0}' AND pcid='{1}'";

        private const string GetDetailsQ =
            "SELECT id,nickname,rank,clan,message FROM players WHERE hardwareid='{0}' AND pcid='{1}'";

        public static List<string> PlayerDetails = new List<string>();

        public static bool Login(string hardwareid, string pcid)
        {
            try
            {
                var results = Commands.QueryGet(string.Format(LoginQ, hardwareid, pcid));
                switch (results[2])
                {
                    case "-1":
                        MessageBox.Show(@"This computer is banned", @"Account Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        Environment.Exit(0);
                        // ReSharper disable HeuristicUnreachableCode
                        break;
                        // ReSharper restore HeuristicUnreachableCode
                    case "0":
                        //MessageBox.Show(@"Please check your email for a verification email and then try again!",
                                       // @"Account not activated",
                                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(@"Please restart the client now!", @"Information", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        Environment.Exit(0);
                        // ReSharper disable HeuristicUnreachableCode
                        break;
                        // ReSharper restore HeuristicUnreachableCode
                    case "1":
                        PlayerDetails = Commands.QueryGet(string.Format(GetDetailsQ, hardwareid, pcid));
                        return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.Write(e.Message);
            }

            return false;
        }

        public static bool Logout()
        {
            return true;
        }

        public static int GetUnixDate()
        {
            return (int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static string GetMyIp()
        {
            var wc = new WebClient();
            var utf8 = new UTF8Encoding();

            var list = utf8.GetString(wc.DownloadData("http://project-intercept.com/ip.php"));

            wc.Dispose();
            return list;
        }
    }
}