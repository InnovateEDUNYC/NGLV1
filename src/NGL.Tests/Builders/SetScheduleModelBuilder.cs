﻿
using System;
using NGL.Web.Models.Schedule;

namespace NGL.Tests.Builders
{
    public class SetScheduleModelBuilder
    {
        private readonly DateTime _beginDate = new DateTime(2004, 2, 2);
        private readonly DateTime _endDate = new DateTime(2004, 8, 8);
        private string _studentName = "Jack Conway";
        private const string ProfilePhotoUrl = "example.com";
        private int _studentUsi = 443;
        private int _sectionId = 11;

        public SetModel Build()
        {
         return new SetModel
         {
             BeginDate = _beginDate,
             EndDate = _endDate,
             StudentName = _studentName,
             ProfilePhotoUrl = ProfilePhotoUrl,
             StudentUsi = _studentUsi,
             SectionId = _sectionId
         };
        }

        public SetScheduleModelBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _studentName = String.Join(" ", student.FirstName, student.LastSurname);
            _studentUsi = student.StudentUSI;
            return this;
        }

        public SetScheduleModelBuilder WithSectionId(int sectionId)
        {
            _sectionId = sectionId;
            return this;
        }
    }
}
