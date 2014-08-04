using System.Collections.Generic;
using ChameleonForms.Attributes;

namespace NGL.Web.Models.Section
{
    public class CreateModel
    {
        public CreateModel()
        {
            Periods = new List<ClassPeriodListItemModel>();
            Classrooms = new List<LocationListItemModel>();
            Courses = new List<CourseListItemModel>();
        }

        public short SchoolYear { get; set; }

        public int Term { get; set; }

        public string Session { get; set; }

        public List<ClassPeriodListItemModel> Periods { get; set; }

        [ExistsIn("Periods", "ClassPeriodName", "ClassPeriodName", false)]
        public string Period { get; set; }

        public List<LocationListItemModel> Classrooms { get; set; }

        [ExistsIn("Classrooms", "Classroom", "Classroom", false)]
        public string Classroom { get; set; }

        public List<CourseListItemModel> Courses { get; set; }

        [ExistsIn("Courses", "CourseCode", "CourseTitle", false)]
        public string Course { get; set; }

        public string UniqueSectionCode { get; set; }

        public int? SequenceOfCourse { get; set; }


        public static CreateModel CreateNewWith(List<ClassPeriodListItemModel> classPeriods, List<LocationListItemModel> classRoomModels, List<CourseListItemModel> courses)
        {
            return new CreateModel
            {
                Periods = classPeriods,
                Classrooms = classRoomModels,
                Courses = courses
            };
        }
    }
}