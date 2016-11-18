using System;
using System.Collections.Generic;
using System.Linq;
using RusticiSoftware.HostedEngine.Client;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HackerFerret.ScormHelper.Api
{
    public static class RegistrationApi
    {
        public static void ResetRegistration(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                ScormCloud.RegistrationService.ResetRegistration(regId);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.ResetRegistration");
                throw;
            }

        }

        public static RegistrationSummary GetRegistrationSummary(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.RegistrationService.GetRegistrationSummary(regId);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationSummary");
                throw;
            }

        }

        public async static Task<RegistrationSummary> GetRegistrationSummaryAsync(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run<RegistrationSummary>(() =>
                {
                    return ScormCloud.RegistrationService.GetRegistrationSummary(regId);
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationSummaryAsync");
                throw;
            }
        }


        public static async Task<RegistrationData> GetRegistrationDetailAsync(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run<RegistrationData>(() =>
                {
                    return ScormCloud.RegistrationService.GetRegistrationDetail(regId);
                });

                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationDetailAsync");
                throw;
            }

        }

        public static void DeleteRegistration(string regId, bool deleteLatestOnlyFlag = false)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                ScormCloud.RegistrationService.DeleteRegistration(regId.ToString(), deleteLatestOnlyFlag);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationDetailAsync");
                throw;
            }

        }

        public static string GetRegistrationResult(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.RegistrationService.GetRegistrationResult(regId.ToString(), RegistrationResultsFormat.ACTIVITY);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationResult");
                throw;
            }

        }

        public static bool ScormRegistrationRecordExistsInCloud(string regId)
        {
            var retval = true;

            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
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
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.RegistrationService.GetRegistrationList();
                return retval.ToList();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetAllRegistrationData");
                throw;
            }

        }

        public async static Task<List<RegistrationData>> GetAllRegistrationDataAsync()
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run<List<RegistrationData>>(() =>
                {
                    return ScormCloud.RegistrationService.GetRegistrationList().ToList();
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetAllRegistrationDataAsync");
                throw;
            }

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
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.RegistrationService.GetPostbackInfo(regId);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationPostbackUrl");
                throw;
            }

        }

        public async static Task<PostbackInfo> GetRegistrationPostbackUrlAsync(string regId)
        {
            global::HackerFerret.ScormHelper.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run<PostbackInfo>(() =>
                {
                    return ScormCloud.RegistrationService.GetPostbackInfo(regId);
                });
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.RegistrationApi.GetRegistrationPostbackUrlAsync");
                throw;
            }

        }
    }
}
