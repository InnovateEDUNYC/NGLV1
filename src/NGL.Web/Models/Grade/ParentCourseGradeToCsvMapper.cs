using System;
using System.Collections.Generic;
using System.IO;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Grade
{
    public class ParentCourseGradeToCsvMapper
    {
        public byte[] Build(List<ParentCourseGrade> parentCourseGrades)
        {
            var memoryStream = new MemoryStream();
            TextWriter textWriter = new StreamWriter(memoryStream);
            textWriter.WriteLine("StudentLastName,StudentUSI,Course,Grade");
            foreach (var grade in parentCourseGrades)
            {
                textWriter.WriteLine(string.Join(",", grade.Student.LastSurname,
                    grade.StudentUSI, grade.ParentCourse.ParentCourseCode,
                    grade.GradeEarned));
            }
            var e = memoryStream;
            textWriter.Flush();
            byte[] bytesInStream = memoryStream.ToArray();
            memoryStream.Close();
            return bytesInStream;
        }
    }
}