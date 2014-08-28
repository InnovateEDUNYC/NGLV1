using System;
using System.Collections.Generic;
using System.IO;
using NGL.Web.Data.Entities;
using NGL.Web.Models.ParentCourse;

namespace NGL.Web.Models.Grade
{
    public class ParentCourseGradeToCsvMapper
    {
        public byte[] Build(string parentCourse, List<GradeModel> parentGradesModelList
            
            )
        {
            var memoryStream = new MemoryStream();
            TextWriter textWriter = new StreamWriter(memoryStream);
            textWriter.WriteLine("StudentLastName,StudentUSI,Course,Grade");
            foreach (var parentCourseGradesModel in parentGradesModelList)
            {
                textWriter.WriteLine(string.Join(",", parentCourseGradesModel.StudentLastName,
                    parentCourseGradesModel.StudentUSI, parentCourse,
                    parentCourseGradesModel.Grade));
            }
            var e = memoryStream;
            textWriter.Flush();
            byte[] bytesInStream = memoryStream.ToArray();
            memoryStream.Close();
            return bytesInStream;
        }

    }
}