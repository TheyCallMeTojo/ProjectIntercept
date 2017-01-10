using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ProjectIntercept.Lobby
{
    internal class AdRotator
    {
        public static List<string> RotateAd()
        {
            var wc = new WebClient();
            var utf8 = new UTF8Encoding();

            var list = utf8.GetString(wc.DownloadData("http://project-intercept.com/stable/randad.php"));
            var split = list.Split(',');

            var rtn = split.ToList();
            wc.Dispose();
            return rtn;
        }
    }
}