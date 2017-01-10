using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjectIntercept.Log;

namespace ProjectIntercept.MySql
{
    internal class Commands
    {
        #region MySql Query Statements

        internal const string ClearMessage = "UPDATE players SET message='' WHERE pcid='{0}'";
        internal const string PingServer = "UPDATE players SET lastlogin='{0}', server='{1}', map='{2}',ip='{3}' WHERE pcid='{4}'";
        internal const string UpdateNick = "UPDATE players SET nickname='{0}' WHERE pcid='{1}'";

        internal const string AddGameHistory =
            "INSERT INTO gamehistory (pcid,date,gameid,server,ip) VALUES('{0}','{1}','{2}','{3}','{4}')";

        internal const string AddIpHistory = "INSERT INTO iphistory (pcid,date,ip) VALUES('{0}','{1}','{2}')";
        internal const string CheckComputerQ = "SELECT pcid FROM players WHERE pcid='{0}'";

        internal const string RegisterQ =
            "INSERT INTO players (email,pcid,hardwareid,windowsversion,windowskey,ip,nickname) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

        #endregion

        private const string ConString = "";

        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");

        private static readonly MySqlConnection Connection = new MySqlConnection(ConString);
        private static readonly MySqlDataAdapter Adapter = new MySqlDataAdapter();
        private static readonly MySqlCommand Command = new MySqlCommand();
        private static MySqlDataReader _reader;

        #region MySql Connection/Disconnection Routines

        public static bool Connect()
        {
            try
            {
                Connection.Open();
                Log.Line("Secure Connection Established");
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(@"Connection to the server has failed. Please try again later.");
                Log.Line(e.Message, true);
                Environment.Exit(0);
                // ReSharper disable HeuristicUnreachableCode
                Connect();
                return false;
                // ReSharper restore HeuristicUnreachableCode
            }
        }

        public static bool Disconnect()
        {
            try
            {
                Connection.Close();
                Log.Line("Secure Connection Closed");
                return true;
            }
            catch (MySqlException e)
            {
                Log.Line(e.Message, true);
                return false;
                //log the error
            }
        }

        #endregion

        #region MySql Query Routines

        public static bool QueryEx(string q)
        {
            try
            {
                Command.Connection = Connection;
                Command.CommandText = q;
                Adapter.SelectCommand = Command;
                Command.ExecuteScalar();
                return true;
            }
            catch (MySqlException e)
            {
                if (Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken)
                {
                    Log.Line("Connect lost or broken, trying to reconnect!", true);
                    Connection.Open();
                    QueryEx(q);
                    return true;
                }

                Log.Line(e.Message, true);
                return false;
            }
        }

        public static List<string> QueryGet(string q)
        {
            if (Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken)
            {
                Log.Line("Connect lost or broken, trying to reconnect!", true);
                Connection.Open();
                QueryEx(q);
                return null;
            }

            try
            {
                var rtn = new List<string>();
                Command.Connection = Connection;
                Command.CommandText = q;
                Adapter.SelectCommand = Command;
                _reader = Command.ExecuteReader();
                //Loop though and add each row to our List<>
                while (_reader.Read())
                {
                    for (var i = 0; i < _reader.FieldCount; i++)
                    {
                        rtn.Add(_reader.GetString(i));
                    }
                }
                _reader.Close();
                //Return null if empty
                return rtn;
            }
            catch (MySqlException e)
            {
                _reader.Close();
                Log.Line(e.Message, true);
                return null;
                //add entry to log file
            }
        }

        #endregion
    }
}