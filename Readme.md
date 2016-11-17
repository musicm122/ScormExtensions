# Scorm Helper

### About:
Helper and Wrapper methods for working with [SCORM Cloud Service .Net Library](https://github.com/RusticiSoftware/SCORMCloud_NetLibrary)

### Using the Library:

#### Install via Nuget
todo;

#### Manual Install
todo;


#### Examples

```Csharp
//start by init your config
ScormHelper.Api.Common.InitScormConfig(appId: "yourAppId", secretKey: "yourSecretKey");

//get all courses
var courses = CourseApi.GetCourseDetailList().OrderBy(x => x.Title);

//get all courses async
var courseResultAsync = CourseApi.GetCourseDetailListAsync().OrderBy(x => x.Title);

//get all registrations
var registrations = RegistrationApi.GetAllRegistrationData();

//get all registrations async
var registrationsResultAsync = await GetAllRegistrationDataAsync();
```
todo;
### Updates:

