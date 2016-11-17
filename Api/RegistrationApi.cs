using System;
using System.Collections.Generic;
using System.Linq;
using RusticiSoftware.HostedEngine.Client;
using System.Threading.Tasks;


namespace HackerFerret.ScormHelper.Api
{
    public static class RegistrationApi
    {
        public static void ResetRegistration(string regId)
        {
            Common.InitScormConfig();
            ScormCloud.RegistrationService.ResetRegistration(regId);
        }

        public static RegistrationSummary GetRegistrationSummary(string regId)
        {
            Common.InitScormConfig();
            var retval = ScormCloud.RegistrationService.GetRegistrationSummary(regId);
            return retval;
        }

        public async static Task<RegistrationSummary> GetRegistrationSummaryAsync(string regId)
        {
            Common.InitScormConfig();
            var retval = await Task.Run<RegistrationSummary>(() =>
            {
                return ScormCloud.RegistrationService.GetRegistrationSummary(regId);
            });

            return retval;
        }


        public static async Task<RegistrationData> GetRegistrationDetailAsync(string regId)
        {
            Common.InitScormConfig();
            var retval = await Task.Run<RegistrationData>(() =>
            {
                return ScormCloud.RegistrationService.GetRegistrationDetail(regId);
            });

            return retval;
        }

        public static void DeleteRegistration(string regId, bool deleteLatestOnlyFlag = false)
        {
            Common.InitScormConfig();
            ScormCloud.RegistrationService.DeleteRegistration(regId.ToString(), deleteLatestOnlyFlag);
        }

        public static string GetRegistrationResult(string regId)
        {
            Common.InitScormConfig();

            var retval = ScormCloud.RegistrationService.GetRegistrationResult(regId.ToString(), RegistrationResultsFormat.ACTIVITY);
            return retval;
        }

        public static bool ScormRegistrationRecordExistsInCloud(string regId)
        {
            var retval = true;

            Common.InitScormConfig();
            try
            {
                var regData = ScormCloud.RegistrationService.GetRegistrationDetail(regId.ToString());
                retval = String.IsNullOrWhiteSpace(regData.RegistrationId);
            }
            catch (Exception)
            {
                retval = false;
            }

            return retval;
        }

        public static List<RegistrationData> GetAllRegistrationData()
        {
            Common.InitScormConfig();
            var retval = ScormCloud.RegistrationService.GetRegistrationList();
            return retval.ToList();
        }

        public async static Task<List<RegistrationData>> GetAllRegistrationDataAsync()
        {
            Common.InitScormConfig();
            var retval = await Task.Run<List<RegistrationData>>(() =>
            {
                return ScormCloud.RegistrationService.GetRegistrationList().ToList();
            });
            return retval;
        }


        /// <summary>
        ///   Gets an existing postback url associated with a given registration
        /// </summary>
        /// <param name="regId"></param>
        /// <param name="postbackUrl"></param>
        /// <returns></returns>
        /// <remarks>
        ///   Will always return an object. For validation check the url field. For more info about postbacks
        ///   http://cloud.scorm.com/doc/web-services/api.html#rustici.registration.updatePostbackInfo
        /// </remarks>
        public static PostbackInfo GetRegistrationPostbackUrl(string regId)
        {
            Common.InitScormConfig();
            var retval = ScormCloud.RegistrationService.GetPostbackInfo(regId);
            return retval;
        }

        public async static Task<PostbackInfo> GetRegistrationPostbackUrlAsync(string regId)
        {
            Common.InitScormConfig();
            var retval = await Task.Run<PostbackInfo>(() =>
            {
                return ScormCloud.RegistrationService.GetPostbackInfo(regId);
            });
            return retval;
        }
    }
}
