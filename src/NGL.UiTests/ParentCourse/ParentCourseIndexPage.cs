﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGL.Web.Models.ParentCourse;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.ParentCourse
{
    public class ParentCourseIndexPage : Page<IndexModel>
    {
        public ParentCourseCreatePage GoToCreatePage()
        {
            return Navigate.To<ParentCourseCreatePage>(By.LinkText("Create New Parent Course"));
        }

        public bool ParentCourseExists(CreateModel createParentCourseModel)
        {
            return Find.Element(By.CssSelector("tr:last-of-type td.course-code")).Text.Equals(createParentCourseModel.ParentCourseCode);
        }
    }
}