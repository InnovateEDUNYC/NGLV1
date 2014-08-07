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
    public partial class AssessmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AssessmentController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Result()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Result);
        }
        public virtual System.Web.Mvc.ActionResult EnterResults()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterResults);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AssessmentController Actions { get { return MVC.Assessment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Assessment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Assessment";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Create = "Create";
            public readonly string Result = "Result";
            public readonly string EnterResults = "EnterResults";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Create = "Create";
            public const string Result = "Result";
            public const string EnterResults = "EnterResults";
        }


        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string createModel = "createModel";
        }
        static readonly ActionParamsClass_Result s_params_Result = new ActionParamsClass_Result();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Result ResultParams { get { return s_params_Result; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Result
        {
            public readonly string studentUsi = "studentUsi";
            public readonly string sessionId = "sessionId";
            public readonly string week = "week";
        }
        static readonly ActionParamsClass_EnterResults s_params_EnterResults = new ActionParamsClass_EnterResults();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EnterResults EnterResultsParams { get { return s_params_EnterResults; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EnterResults
        {
            public readonly string assessmentId = "assessmentId";
            public readonly string enterResultsModel = "enterResultsModel";
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
                public readonly string Create = "Create";
                public readonly string Result = "Result";
                public readonly string EnterResults = "EnterResults";
            }
            public readonly string Create = "~/Views/Assessment/Create.cshtml";
            public readonly string Result = "~/Views/Assessment/Result.cshtml";
            public readonly string EnterResults = "~/Views/Assessment/EnterResults.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AssessmentController : NGL.Web.Controllers.AssessmentController
    {
        public T4MVC_AssessmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, NGL.Web.Models.Assessment.CreateModel createModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(NGL.Web.Models.Assessment.CreateModel createModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createModel", createModel);
            CreateOverride(callInfo, createModel);
            return callInfo;
        }

        [NonAction]
        partial void ResultOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int studentUsi, int? sessionId, int week);

        [NonAction]
        public override System.Web.Mvc.ActionResult Result(int studentUsi, int? sessionId, int week)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Result);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "studentUsi", studentUsi);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "sessionId", sessionId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "week", week);
            ResultOverride(callInfo, studentUsi, sessionId, week);
            return callInfo;
        }

        [NonAction]
        partial void EnterResultsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int assessmentId);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterResults(int assessmentId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterResults);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "assessmentId", assessmentId);
            EnterResultsOverride(callInfo, assessmentId);
            return callInfo;
        }

        [NonAction]
        partial void EnterResultsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, NGL.Web.Models.Assessment.EnterResultsModel enterResultsModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterResults(NGL.Web.Models.Assessment.EnterResultsModel enterResultsModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterResults);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "enterResultsModel", enterResultsModel);
            EnterResultsOverride(callInfo, enterResultsModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
