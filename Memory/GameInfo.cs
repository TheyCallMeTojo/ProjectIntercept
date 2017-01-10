using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectIntercept.Memory
{
    internal class GameInfo
    {
        

        internal static string PlayerName()
        {
            //00ECE2A8   0x00A35307
            var tmp = ReadProcMems.ReadString((IntPtr)0x00ECE2A8);
            return tmp.Length < 1 ? "Not Detected" : tmp.Replace("'","").Replace("`","").Replace("\"", "");
        }

        internal static string MapName()
        {
            var tmp = ReadProcMems.ReadString((IntPtr)0x0071569C);
            return tmp.Length < 1 ? "Not Detected" : tmp.Replace("'", "").Replace("`", "").Replace("\"", "");
        }

        internal static string ServerName()
        {
            var tmp = ReadProcMems.ReadString((IntPtr)0x9ED6B8);
            return tmp.Length < 1 ? "Not Detected" : tmp.Replace("'", "").Replace("`", "").Replace("\"", "");
        }

        internal static List<string> ProfileNames()
        {
            var tmp = new[] { 0x00A146EC, 0x00A1AC48, 0x00A211A4, 0x00A27700 };
            return tmp.Select(a => ReadProcMems.ReadString((IntPtr)a)).ToList();
        }

        internal static string ServerIp()
        {
            var ip = "";

            var memory = ReadProcMems.ReadBytes(((IntPtr)0x9DDA50), 32);
            for (var i = 0; i < memory.Length; i++)
            {
                ip = string.Concat(ip, memory[i].ToString("X"));
            }

            ip = Regex.Replace(ip, "00", "");
            ip = Regex.Replace(ip, @"[^\u0000-\u007F]", "");
            ip = HextoAsc(ip);
            var regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            var ipString = regex.Match(ip).Value;
            return ipString;
        }

        public static string HextoAsc(string data)
        {
            var sData = "";
            while (data.Length > 1)
            {
                var data1 = Convert.ToChar(Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
                sData = sData + data1;
                data = data.Substring(2, data.Length - 2);
            }
            return sData;
        }
    }
}