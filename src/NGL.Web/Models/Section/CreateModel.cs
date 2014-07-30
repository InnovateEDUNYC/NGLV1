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

        public List<ClassPeriodNameModel> ClassPeriodNames { get; set; }

        [Required]
        [ExistsIn("ClassPeriodNames", "ClassPeriodName", "ClassPeriodName")]
        public string ClassPeriodName { get; set; }
        
        public List<ClassRoomModel> ClassRooms { get; set; }

        [Required]
        [ExistsIn("ClassRooms", "ClassRoom", "ClassRoom")]
        public string ClassRoom { get; set; }

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
            ClassPeriodNames = new List<ClassPeriodNameModel>();
            ClassRooms = new List<ClassRoomModel>();
        }

        public static CreateModel CreateNewWith(List<ClassPeriodNameModel> classPeriods, 
            List<ClassRoomModel> classRoomModels)
        {
            return new CreateModel
            {
                ClassPeriodNames = classPeriods,
                ClassRooms = classRoomModels
            };
        }
    }
}