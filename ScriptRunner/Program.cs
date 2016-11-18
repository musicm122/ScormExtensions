using HackerFerret.ScormHelper.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var appId = "ARVWL99E4K";
            var secret = "efVZZXxMmDqc3uNRMlgwid8mwD5DAiALrOR0lGbh";
            // start by init your config

            HackerFerret.ScormHelper.Api.Common.InitScormConfig(appId: appId, secretKey: secret);

            //get all courses
            var courses = CourseApi.GetCourseDetailList();

            //get all registrations
            var registrations = RegistrationApi.GetAllRegistrationData();

        }
    }
}
