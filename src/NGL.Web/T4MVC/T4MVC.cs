﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static NGL.Web.Controllers.AccountController Account = new NGL.Web.Controllers.T4MVC_AccountController();
    public static NGL.Web.Controllers.ClassPeriodController ClassPeriod = new NGL.Web.Controllers.T4MVC_ClassPeriodController();
    public static NGL.Web.Controllers.CourseController Course = new NGL.Web.Controllers.T4MVC_CourseController();
    public static NGL.Web.Controllers.CourseGenerationController CourseGeneration = new NGL.Web.Controllers.T4MVC_CourseGenerationController();
    public static NGL.Web.Controllers.EnrollmentController Enrollment = new NGL.Web.Controllers.T4MVC_EnrollmentController();
    public static NGL.Web.Controllers.ErrorController Error = new NGL.Web.Controllers.T4MVC_ErrorController();
    public static NGL.Web.Controllers.HomeController Home = new NGL.Web.Controllers.T4MVC_HomeController();
    public static NGL.Web.Controllers.LocationController Location = new NGL.Web.Controllers.T4MVC_LocationController();
    public static NGL.Web.Controllers.SchoolController School = new NGL.Web.Controllers.T4MVC_SchoolController();
    public static NGL.Web.Controllers.SectionController Section = new NGL.Web.Controllers.T4MVC_SectionController();
    public static NGL.Web.Controllers.SessionController Session = new NGL.Web.Controllers.T4MVC_SessionController();
    public static NGL.Web.Controllers.StudentController Student = new NGL.Web.Controllers.T4MVC_StudentController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static partial class Scripts {}
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static partial class Styles {}
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591


