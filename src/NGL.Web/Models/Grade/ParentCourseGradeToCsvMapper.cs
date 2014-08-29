using System;
using System.Collections.Generic;
using System.IO;
using NGL.Web.Data.Entities;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Models.Grade
{
    public class ParentCourseGradeToCsvMapper
    {
        public byte[] Build(List<ParentCourseGrade> parentCourseGrades)
        {
            var memoryStream = new MemoryStream();
            TextWriter textWriter = new StreamWriter(memoryStream);
            textWriter.WriteLine("StudentLastName,StudentUSI,CourseCode,CourseTitle,Grade");
            foreach (var parentCourseGrade in parentCourseGrades)
            {
                textWriter.WriteLine(string.Join(",", parentCourseGrade.Student.LastSurname,
                    parentCourseGrade.StudentUSI, parentCourseGrade.ParentCourse.ParentCourseCode, parentCourseGrade.ParentCourse.ParentCourseTitle,
                    parentCourseGrade.GradeEarned));
            }
            textWriter.Flush();
            byte[] bytesInStream = memoryStream.ToArray();
            memoryStream.Close();
            return bytesInStream;
        }
    }
}