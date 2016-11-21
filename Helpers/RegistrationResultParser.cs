using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using HackerFerret.ScormHelper.Extensions;
using HackerFerret.ScormHelper.Model;

namespace ScormApi.Helpers
{
    public static class RegistrationResultParser
    {
        public static RegistrationResult ConvertToRegResult(string xmlVal)
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
    }
}