using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Api
{
    public static class ReportApi
    {
        private static string ReportUrlPart = "/Reportage/reportage.php";
        public static string GetReportUrl()
        {
            Common.InitScormConfig();

            String reportageAuth = ScormCloud.ReportingService.GetReportageAuth(ReportageNavPermission.FREENAV, false);
            String authenticatedUrl = ScormCloud.ReportingService.GetReportUrl(reportageAuth, $"{Common.ScormServiceRootUrl}{ReportUrlPart}?appId={Common.AppliationId}");
            return authenticatedUrl;
        }
    }
}
