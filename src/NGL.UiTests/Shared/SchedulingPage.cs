﻿using NGL.UiTests.ClassPeriod;
using NGL.UiTests.Session;
using OpenQA.Selenium;
using Page = TestStack.Seleno.PageObjects.Page;

namespace NGL.UiTests.Shared
{
    class SchedulingPage : Page
    {

        public SessionIndexPage GoToSessionIndexPage()
        {
            return Navigate.To<SessionIndexPage>(By.LinkText("Sessions"));
        }

        public ClassPeriodIndexPage GoToClassPeriodIndexPage()
        {
            return Navigate.To<ClassPeriodIndexPage>(By.LinkText("Periods"));
        }
    }
}
