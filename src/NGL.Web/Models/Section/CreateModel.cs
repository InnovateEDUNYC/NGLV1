using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChameleonForms.Attributes;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Section
{
    public class CreateModel
    {
        [Required]
        public SchoolYearTypeEnum SchoolYear { get; set; }

        [Required]
        public TermTypeEnum Term { get; set; }

        public List<ClassPeriodListItemModel> Periods { get; set; }

        [Required]
        [ExistsIn("Periods", "ClassPeriodName", "ClassPeriodName")]
        public string Period { get; set; }
        
        public List<LocationListItemModel> Classrooms { get; set; }

        [Required]
        [ExistsIn("Classrooms", "Classroom", "Classroom")]
        public string Classroom { get; set; }

        public List<CourseListItemModel> Courses { get; set; }

        [ExistsIn("Courses", "CourseCode", "CourseTitle")]
        public string Course { get; set; }
            
        [Required]
        [StringLength(20)]
        public string LocalCourseCode { get; set; }

        [Required]
        [StringLength(255)]
        public string UniqueSectionCode { get; set; }

        [Required]
        public int SequenceOfCourse { get; set; }


        public CreateModel()
        {
            Periods = new List<ClassPeriodListItemModel>();
            Classrooms = new List<LocationListItemModel>();
            Courses = new List<CourseListItemModel>();
        }

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