using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScormApi.Helpers
{
    public static class Converter
    {
        public static IList<CourseData> ToCourseData(string courseListXml)
        {
            var doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(courseListXml);
                var result = CourseData.ConvertToCourseDataList(doc);
                return result;
            }
            catch (Exception ex)
            {
                Debug.Write($"Error: Could not convert Xml String to Course Data.\r\n {ex.Message}", "ScormApi.Helper.Converter");
                throw;
            }
        }
    }
}
