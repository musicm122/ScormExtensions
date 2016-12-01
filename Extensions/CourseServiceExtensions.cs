using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RusticiSoftware.HostedEngine.Client;
using System.Diagnostics;

namespace HackerFerret.ScormHelper.Extensions
{
    public static class CourseServiceExtensions
    {
        public static async Task<CourseData> GetCourseDetailsAsync(this CourseService CourseServiceInstance, string courseSeq)
        {
            try
            {
                var retval = await Task.Run(() =>
                     CourseServiceInstance.GetCourseList().FirstOrDefault(x => x.CourseId == courseSeq)
                );
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static async Task<List<CourseData>> GetCourseDetailListAsync(this CourseService CourseServiceInstance)
        {
            try
            {
                var retval = await Task.Run(() =>
               CourseServiceInstance.GetCourseList()
           );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static async Task<string> GetCoursePreviewUrlAsync(this CourseService CourseServiceInstance, string courseSeq, string redirectOnExitUrl = "")
        {
            try
            {
                var retval = await Task.Run(() =>
                    CourseServiceInstance.GetPreviewUrl(courseSeq, redirectOnExitUrl)
                );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static string GetCourseTitle(this CourseService CourseServiceInstance, string courseSeq)
        {
            try
            {
                var course = CourseServiceInstance.GetCourseDetails(courseSeq);
                var retval = course.Title;
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static CourseData GetCourseDetails(this CourseService CourseServiceInstance, string courseSeq)
        {
            try
            {
                CourseData retval = CourseServiceInstance.GetCourseList().FirstOrDefault(x => x.CourseId == courseSeq);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }



        public static async Task<string> GetCourseTitleAsync(this CourseService CourseServiceInstance, string courseId)
        {
            try
            {
                var retval = await CourseServiceInstance.GetCourseDetailsAsync(courseId);
                return retval.Title;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static async Task DeleteCourseAsync(this CourseService CourseServiceInstance, string courseSeq)
        {
            try
            {
                await Task.Run(() =>
                    CourseServiceInstance.DeleteCourse(courseSeq)
                );

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static async Task<bool> CourseExistsAsync(this CourseService CourseServiceInstance, string courseSeq)
        {
            try
            {
                var retval = await Task.Run(() =>
                    CourseServiceInstance.Exists(courseSeq)
                );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                throw;
            }
        }

        public static async Task<bool> UploadCourseAsync(this CourseService CourseServiceInstance, string zipPath, string domain)
        {
            try
            {
                var retval = await Task.Run(() =>
                {
                    var result = ScormCloud.UploadService.UploadFile(zipPath, domain);
                    return String.IsNullOrWhiteSpace(result.location);
                });
                return retval;
            }
            catch (System.Exception ex)
            {
                Debug.Write(ex.Message, "ScormHelper.Api.CourseApi");
                return false;

            }
        }

    }
}