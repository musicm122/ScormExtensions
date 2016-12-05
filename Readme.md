# Scorm Extensions

### About:
Extension methods for working with [SCORM Cloud Service .Net Library](https://github.com/RusticiSoftware/SCORMCloud_NetLibrary)

### Using the Library:

#### Install via Nuget
>PM> Install-Package ScormExtensions


#### Extension Methods

```Csharp
public static class RegistrationServiceExtensions
public static async Task<List<RegistrationData>> GetAllRegistrationDataAsync(this RegistrationService service)
public static async Task<RegistrationData> GetRegistrationDetailAsync(this RegistrationService service, string regId)
public static async Task<PostbackInfo> GetRegistrationPostbackUrlAsync(this RegistrationService service, string regId)
public static async Task<RegistrationSummary> GetRegistrationSummaryAsync(this RegistrationService service, string regId)
public static bool ScormRegistrationRecordExistsInCloud(this RegistrationService service, string regId)

public static class CourseServiceExtensions
public static async Task<CourseData> GetCourseDetailsAsync(this CourseService CourseServiceInstance, string courseSeq)
public static async Task<List<CourseData>> GetCourseDetailListAsync(this CourseService CourseServiceInstance)
public static async Task<string> GetCoursePreviewUrlAsync(this CourseService CourseServiceInstance, string courseSeq, string redirectOnExitUrl = "")
public static string GetCourseTitle(this CourseService CourseServiceInstance, string courseSeq)
public static CourseData GetCourseDetails(this CourseService CourseServiceInstance, string courseSeq)
public static async Task<string> GetCourseTitleAsync(this CourseService CourseServiceInstance, string courseId)
public static async Task DeleteCourseAsync(this CourseService CourseServiceInstance, string courseSeq)
public static async Task<bool> CourseExistsAsync(this CourseService CourseServiceInstance, string courseSeq)
public static async Task<bool> UploadCourseAsync(this CourseService CourseServiceInstance, string zipPath, string domain)

public static class ReportingServiceExtensions
public static string GetReportUrl(this ReportingService service, string applicationId)

public static class RegistrationExtensions
public static string ToFormattedString(this RegistrationData data)
public static string ToCSVString(this RegistrationData data)
public static string ToCSVString(this List<RegistrationData> dataList)
public static string ToCSVString(this List<InstanceData> InstanceData)

public static class CourseExtensions
public static string ToFormattedString(this CourseData data)
public static string ToCSVString(this CourseData data)
public static string ToCSVString(this List<CourseData> dataList)

public static class StringExtensions
public static bool IsNumericString(this string val)
public static bool IsDateString(this string val)
public static bool IsValidUrl(string url)

public static class Converter
public static RegistrationResult ToRegistrationResult(string xmlVal)
public static IList<CourseData> ToCourseData(string courseListXml)
public static IList<RegistrationData> ToRegistrationData(string xmlVal)
```
### Updates:

- 12/5/2016: Init release
