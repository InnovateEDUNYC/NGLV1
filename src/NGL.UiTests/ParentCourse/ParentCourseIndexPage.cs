﻿using System.Linq;
using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseIndexPage : Page<IndexModel>
    {
        public ParentCourseCreatePage GoToCreatePage()
        {
            return Navigate.To<ParentCourseCreatePage>(By.LinkText("Add Parent Course"));
        }

        public bool ParentCourseExists(CreateModel createParentCourseModel)
        {
            return Find.Element(By.CssSelector("tbody")).Text.Contains(createParentCourseModel.ParentCourseCode);
        }

        public ParentCourseEditPage GoToEditPage()
        {
            return Navigate.To<ParentCourseEditPage>(By.LinkText("Edit"));
        }

        public bool ParentCourseExists(EditModel createParentCourseModel)
        {
            return Find.Element(By.CssSelector("tbody")).Text.Contains(createParentCourseModel.ParentCourseCode);
        }

        public ParentCourseIndexPage GoDelete(string parentCourseCode)
        {
            Execute.Script("$('[data-course=\"" + parentCourseCode + "\"]').find('.delete-row-btn').click()");
            
            return this;
        }

        public int GetNumberOfParentCourses()
        {
            return Find.Elements(By.ClassName("delete-row-btn")).Count();
        }
    }
}
