using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Queries
{
    public class StudentSectionAssociationByPrimaryKeysQuery : IQuery<StudentSectionAssociation>
    {
        private readonly int _studentUsi;
        private readonly DateTime _beginDate;
        private readonly short _schoolYear;
        private readonly int _termTypeId;
        private readonly string _localCourseCode;
        private readonly string _classPeriodName;
        private readonly string _classroomIdentificationCode;

        public StudentSectionAssociationByPrimaryKeysQuery(int studentUsi, DateTime beginDate, short schoolYear, int termTypeId, string localCourseCode, string classPeriodName, string classroomIdentificationCode)
        {
            _studentUsi = studentUsi;
            _beginDate = beginDate;
            _schoolYear = schoolYear;
            _termTypeId = termTypeId;
            _localCourseCode = localCourseCode;
            _classPeriodName = classPeriodName;
            _classroomIdentificationCode = classroomIdentificationCode;
        }

        public IQueryable<StudentSectionAssociation> ApplyPredicate(IQueryable<StudentSectionAssociation> inputSet)
        {
            return inputSet.Where(ssa =>
                ssa.StudentUSI == _studentUsi &&
                ssa.BeginDate == _beginDate &&
                ssa.SchoolYear == _schoolYear &&
                ssa.TermTypeId == _termTypeId &&
                ssa.LocalCourseCode == _localCourseCode &&
                ssa.ClassPeriodName == _classPeriodName &&
                ssa.ClassroomIdentificationCode == _classroomIdentificationCode);
        }
    }
}