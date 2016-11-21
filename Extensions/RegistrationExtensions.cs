using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Extensions
{
    public static class RegistrationExtensions
    {


        public static string ToFormattedString(this RegistrationData data)
        {
            return
$@"CompletedDate: {data.CompletedDate}
CourseId: {data.CourseId}
CourseTitle: {data.CourseTitle}
CreateDate: {data.CreateDate}
Email: {data.Email}
FirstAccessDate: {data.FirstAccessDate}
Instances: {data.Instances.ToCSVString()}
LastAccessDate: {data.LastAccessDate}
LastCourseVersionLaunched: {data.LastCourseVersionLaunched}
LearnerFirstName: {data.LearnerFirstName}
LearnerId: {data.LearnerId}
LearnerLastName: {data.LearnerLastName}
RegistrationId: {data.RegistrationId}";
        }

        public static string ToCSVString(this RegistrationData data)
        {
            return $@"{ data.CompletedDate}, { data.CourseId}, { data.CourseTitle}, { data.CreateDate}, { data.Email}, { data.FirstAccessDate}, { data.Instances}, { data.LastAccessDate}, { data.LastCourseVersionLaunched}, { data.LearnerFirstName}, { data.LearnerId}, { data.LearnerLastName}, { data.RegistrationId}";
        }


        public static string ToCSVString(this List<RegistrationData> dataList)
        {
            var rowSeperator = "\r\n";
            var result = dataList
                    .Select<RegistrationData, string>(r => r.ToCSVString())
                    .Aggregate((x, y) => x + rowSeperator + y);
            return result;
        }

        public static string ToCSVString(this List<InstanceData> InstanceData)
        {
            var rowSeperator = "\r\n";

            if (InstanceData.Count == 0)
            {
                return String.Empty;
            }
            var result = InstanceData
                    .Select<InstanceData, string>(r => r.CourseVersion + "," + r.InstanceId + "," + r.UpdateDate)
                    .Aggregate((x, y) => x + rowSeperator + y);
            return result;
        }
    }
}
