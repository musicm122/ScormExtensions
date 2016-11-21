﻿# Scorm Helper

### About:
Helper and Wrapper methods for working with [SCORM Cloud Service .Net Library](https://github.com/RusticiSoftware/SCORMCloud_NetLibrary)

### Using the Library:

#### Install via Nuget
>PM> Install-Package ScormHelper


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
### Updates:

- 11/17/2016: Init release
- 11/18/2016: Fix issue with InitScormConfig
- 11/21/2016: Added ToFormattedString and ToCSVString extension methods to Courses and Registrations.

