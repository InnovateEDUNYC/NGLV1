using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.CourseOffering;

namespace NGL.Web.Models.Course
{
    public class CourseModel
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int NumberOfParts { get; set; }
        public string CourseDescription { get; set; }

        public ICollection<CourseOfferingModel> CourseOfferings { get; set; }
    }
}