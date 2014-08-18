using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Attendance
{
    public class TakeAttendanceModel
    {
        public string Session { get; set; }
        public int? SessionId { get; set; }
        public string Section { get; set; }
        public int? SectionId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IList<StudentAttendanceRowModel> StudentRows { get; set; }

        public static TakeAttendanceModel CreateNew()
        {
            return new TakeAttendanceModel {Date = DateTime.Now.Date};
        }

        public TakeAttendanceModel Clone()
        {
            return new TakeAttendanceModel
            {
                Section = Section,
                Session = Session,
                SectionId = SectionId,
                SessionId = SessionId,
                Date = Date
            };
        }
    }

    public class StudentAttendanceRowModel
    {
        public int StudentUsi { get; set; }
        public string StudentName { get; set; }
        public AttendanceEventCategoryDescriptorEnum AttendanceType { get; set; }
        public string ProfileThumbnailUrl { get; set; }
    }
}