using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumericString(this string val)
        {
            var retval = false;
            if (string.IsNullOrWhiteSpace(val))
            {
                return retval;
            }
            var tempNum = 0;
            retval = int.TryParse(val, out tempNum);
            return retval;
        }

        public static bool IsDateString(this string val)
        {
            var retval = false;
            if (string.IsNullOrWhiteSpace(val))
            {
                return retval;
            }
            var tempDate = DateTime.Now;
            retval = DateTime.TryParse(val, out tempDate);
            return retval;
        }

        public static bool IsValidUrl(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            Uri uriResult;
            bool isUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return isUrl;
        }


    }
}
