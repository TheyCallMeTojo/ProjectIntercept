using ProjectIntercept.MySql;

namespace ProjectIntercept.Security
{
    internal class Network
    {
        private const string IsOnline = "SELECT online FROM version";

        //Simply checks the table 'version' for row 'online' to see if our lobby is up
        public static bool IsLobbyOnline()
        {
            var results = Commands.QueryGet(IsOnline);
            return results[0] == "online";
        }
    }
}