using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Extensions
{
    public static class ReportingServiceExtensions
    {
        public static string GetReportUrl(this ReportingService service, string applicationId)
        {
            var ReportUrlPart = "/Reportage/reportage.php";
            var serviceUrl = service.GetReportageServiceUrl();
            String reportageAuth = ScormCloud.ReportingService.GetReportageAuth(ReportageNavPermission.FREENAV, false);
            String authenticatedUrl = ScormCloud.ReportingService.GetReportUrl(reportageAuth, $"{serviceUrl  }{ReportUrlPart}?appId={applicationId}");
            return authenticatedUrl;
        }
    }
}
