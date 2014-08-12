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
    public partial class LearningStandardController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected LearningStandardController(Dummy d) { }

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
        public virtual System.Web.Mvc.JsonResult GetCommonCoreStandards()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetCommonCoreStandards);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public LearningStandardController Actions { get { return MVC.LearningStandard; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "LearningStandard";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "LearningStandard";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetCommonCoreStandards = "GetCommonCoreStandards";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetCommonCoreStandards = "GetCommonCoreStandards";
        }


        static readonly ActionParamsClass_GetCommonCoreStandards s_params_GetCommonCoreStandards = new ActionParamsClass_GetCommonCoreStandards();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetCommonCoreStandards GetCommonCoreStandardsParams { get { return s_params_GetCommonCoreStandards; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetCommonCoreStandards
        {
            public readonly string gradeLevelTypeEnum = "gradeLevelTypeEnum";
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
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_LearningStandardController : NGL.Web.Controllers.LearningStandardController
    {
        public T4MVC_LearningStandardController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetCommonCoreStandardsOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string gradeLevelTypeEnum);

        [NonAction]
        public override System.Web.Mvc.JsonResult GetCommonCoreStandards(string gradeLevelTypeEnum)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetCommonCoreStandards);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "gradeLevelTypeEnum", gradeLevelTypeEnum);
            GetCommonCoreStandardsOverride(callInfo, gradeLevelTypeEnum);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
