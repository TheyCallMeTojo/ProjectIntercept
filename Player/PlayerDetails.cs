using System;

namespace ProjectIntercept.Player
{
    class PlayerDetails
    {
        //Setup a thread to auto update the players info every 30 seconds.
        //This will catch bans, rank changes, clan changes and so on.
        #region PlayerDetails Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string PcId { get; set; }
        public string MachineId { get; set; }
        public string Status { get; set; }
        public string Rank { get; set; }
        public string Clan { get; set; }
        public string Message { get; set; }
        #endregion

        public PlayerDetails(string pcId, string hardwareId)
        {
            if (string.IsNullOrEmpty(pcId) || string.IsNullOrEmpty(hardwareId))
                throw new ArgumentException("Null Parameter Found");

            var q = string.Format("SELECT nickname,email,id,pcid,hardwareid,status,rank,clan,message FROM players WHERE pcid='{0}' AND hardwareid='{1}'", pcId, hardwareId);

            var results = MySql.Commands.QueryGet(q);

            if (results == null) throw new ArgumentException("Null Parameter Found");

            Name = results[0];
            Email = results[1];
            Id = results[2];
            PcId = results[3];
            MachineId = results[4];
            Status = results[5];
            Rank = results[6];
            Clan = results[7];
            Message = results[8];
        }
    }
}
