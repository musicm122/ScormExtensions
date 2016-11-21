using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Extensions
{

    public static class CourseExtensions
    {
        public static string ToFormattedString(this CourseData data)
        {
            return
$@"Title: {data.Title}
CourseId: {data.CourseId}
Number of Registrations:    {data.NumberOfRegistrations}
Number of Versions:    {data.NumberOfVersions}";

        }


        public static string ToCSVString(this CourseData data)
        {
            return $@"{data.Title}, {data.CourseId}, {data.NumberOfRegistrations}, {data.NumberOfVersions}";
        }

        public static string ToCSVString(this List<CourseData> dataList)
        {
            var rowSeperator = "\r\n";
            var result = dataList
                    .Select<CourseData, string>(c => c.ToCSVString())
                    .Aggregate((x, y) => x + rowSeperator + y);
            return result;
        }

    }
}
