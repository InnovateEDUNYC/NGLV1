using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Attendance;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Attendance
{
    public class TakeAttendancePage : Page<TakeAttendanceModel>
    {
        public TakeAttendancePage SearchForStudents(TakeAttendanceModel takeAttendanceModel)
        {
            Input.Model(takeAttendanceModel);
            return Navigate.To<TakeAttendancePage>(By.Id("get-students-btn"));
        }

        public List<string> GetStudentAttendance()
        {
            var studentAttendance = Find.Elements(By.CssSelector("Input[checked=checked]")).Select(e => e.GetAttribute("value")).ToList();
            return studentAttendance;
        }

        public TakeAttendancePage EnterAttendanceStatus(AttendanceEventCategoryDescriptorEnum attendanceEventCategoryDescriptorEnum)
        {
            attendanceEventCategoryDescriptorEnum.ToString();
            var tardyCheckboxes = Find.Elements(By.CssSelector("label." + String.Join("", attendanceEventCategoryDescriptorEnum.ToString().Split(' '))));
            tardyCheckboxes.ForEach(tcb => tcb.Click());

            return Navigate.To<TakeAttendancePage>(By.ClassName("save-button"));
        }


        public void MarkPresentForDate(string date)
        {
            var takeAttendanceModel = new TakeAttendanceModelBuilder().WithDate(date).Build();
            SearchForStudents(takeAttendanceModel);
            EnterAttendanceStatus(AttendanceEventCategoryDescriptorEnum.InAttendance);
        }
    }
}
