using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class UtilityService
    {
        public static string FormatUrl(string url)
        {
            return url.Replace("\"", "").Replace("http://", "").Replace("https://", "").Replace("ftp://", "");
        }

        public static string FormatInput(string url)
        {
            return url.Replace("\"", "");
        }
    }
}
