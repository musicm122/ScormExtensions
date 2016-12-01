using HackerFerret.ScormHelper.Extensions;
using HackerFerret.ScormHelper.Model;
using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HackerFerret.ScormHelper.Helpers
{
    /// <summary>
    /// Handles the parsing of raw scorm data into strongly typed collections
    /// </summary>
    public static class Converter
    {
        public static RegistrationResult ToRegistrationResult(string xmlVal)
        {
            var retval = new RegistrationResult();

            var mXmld = new XmlDocument();
            var readFile = new StringReader(xmlVal);
            mXmld.Load(readFile);


            //XmlNodeList m_nodelist = default(XmlNodeList);
            var nodelist = mXmld.SelectNodes("/registrationreport/activity");
            Debug.Assert(nodelist != null, "nodelist != null");
            foreach (XmlNode item in nodelist)
            {
                retval.Title = item.ChildNodes.Item(0)?.InnerText;
                retval.Complete = item.ChildNodes.Item(2)?.InnerText;
                retval.Success = item.ChildNodes.Item(3)?.InnerText;
                retval.Score = item.ChildNodes.Item(5)?.InnerText;
                if (retval.Score.IsNumericString())
                    retval.Score = (Convert.ToDouble(retval.Score) * 100).ToString(CultureInfo.InvariantCulture);
            }

            try
            {
                var mNodelist2 = mXmld.SelectNodes("/registrationreport/activity/children/activity");
                Debug.Assert(mNodelist2 != null, "m_nodelist2 != null");
                foreach (XmlNode item in mNodelist2)
                {
                    var xmlNode = item.ChildNodes.Item(1);
                    retval.Attempts = xmlNode?.InnerText;
                    retval.ViewTime = item.ChildNodes.Item(4)?.InnerText;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Helpers.RegistrationResultParser.ConvertToRegResult");
                throw;
            }

            return retval;
        }

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

        public static IList<RegistrationData> ToRegistrationData(string xmlVal)
        {
            var doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(xmlVal);
                var result = RegistrationData.ConvertToRegistrationDataList(doc);
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
