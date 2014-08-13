// <auto-generated />
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
namespace NGL.Web.Controllers
{
    public partial class StudentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected StudentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Index()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UploadPhoto()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadPhoto);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public StudentController Actions { get { return MVC.Student; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Student";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Student";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string All = "All";
            public readonly string Reports = "Reports";
            public readonly string Index = "Index";
            public readonly string UploadPhoto = "UploadPhoto";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string All = "All";
            public const string Reports = "Reports";
            public const string Index = "Index";
            public const string UploadPhoto = "UploadPhoto";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string usi = "usi";
        }
        static readonly ActionParamsClass_UploadPhoto s_params_UploadPhoto = new ActionParamsClass_UploadPhoto();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UploadPhoto UploadPhotoParams { get { return s_params_UploadPhoto; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UploadPhoto
        {
            public readonly string profilePhoto = "profilePhoto";
            public readonly string usi = "usi";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string All = "All";
                public readonly string Delete = "Delete";
                public readonly string Edit = "Edit";
                public readonly string Index = "Index";
                public readonly string Reports = "Reports";
            }
            public readonly string All = "~/Views/Student/All.cshtml";
            public readonly string Delete = "~/Views/Student/Delete.cshtml";
            public readonly string Edit = "~/Views/Student/Edit.cshtml";
            public readonly string Index = "~/Views/Student/Index.cshtml";
            public readonly string Reports = "~/Views/Student/Reports.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_StudentController : NGL.Web.Controllers.StudentController
    {
        public T4MVC_StudentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void AllOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult All()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.All);
            AllOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ReportsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Reports()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reports);
            ReportsOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int usi);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(int usi)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "usi", usi);
            IndexOverride(callInfo, usi);
            return callInfo;
        }

        [NonAction]
        partial void UploadPhotoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Web.HttpPostedFileBase profilePhoto, int usi);

        [NonAction]
        public override System.Web.Mvc.ActionResult UploadPhoto(System.Web.HttpPostedFileBase profilePhoto, int usi)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadPhoto);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "profilePhoto", profilePhoto);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "usi", usi);
            UploadPhotoOverride(callInfo, profilePhoto, usi);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
