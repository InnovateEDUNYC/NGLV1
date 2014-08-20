using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using NGL.Web.Models.ParentCourse;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseGradesPage : Page<FindParentCourseModel>
    {
        public void SelectAParentCourse()
        {
            Input.ReplaceInputValueWith(m => m.SessionId, 1);
            Input.ReplaceInputValueWith(m => m.SectionId, 1);
            Execute.Script("$('#SectionId').trigger('populated');");
        }

        public void EnterGrades()
        {
            throw new NotImplementedException();
        }
    }
}
