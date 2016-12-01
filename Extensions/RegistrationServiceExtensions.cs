using RusticiSoftware.HostedEngine.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerret.ScormHelper.Extensions
{
    public static class RegistrationServiceExtensions
    {
        public static async Task<List<RegistrationData>> GetAllRegistrationDataAsync(this RegistrationService service)
        {
            try
            {
                var retval = await Task.Run<List<RegistrationData>>(() =>
                {
                    return service.GetRegistrationList().ToList();
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetAllRegistrationDataAsync");
                throw;
            }
        }

        public static async Task<RegistrationData> GetRegistrationDetailAsync(this RegistrationService service, string regId)
        {
            try
            {
                var retval = await Task.Run<RegistrationData>(() =>
                {
                    return service.GetRegistrationDetail(regId);
                });

                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationDetailAsync");
                throw;
            }
        }

        public static async Task<PostbackInfo> GetRegistrationPostbackUrlAsync(this RegistrationService service, string regId)
        {
            try
            {
                var retval = await Task.Run<PostbackInfo>(() =>
                {
                    return service.GetPostbackInfo(regId);
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationPostbackUrlAsync");
                throw;
            }
        }

        public static async Task<RegistrationSummary> GetRegistrationSummaryAsync(this RegistrationService service, string regId)
        {
            try
            {
                var retval = await Task.Run<RegistrationSummary>(() =>
                {
                    return service.GetRegistrationSummary(regId);
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationSummaryAsync");
                throw;
            }
        }

        public static bool ScormRegistrationRecordExistsInCloud(this RegistrationService service, string regId)
        {
            var retval = true;

            try
            {
                var regData = service.GetRegistrationDetail(regId.ToString());
                retval = String.IsNullOrWhiteSpace(regData.RegistrationId);
            }
            catch (Exception)
            {

                retval = false;
            }

            return retval;
        }
    }
}
