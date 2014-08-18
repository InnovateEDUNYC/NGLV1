using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.ParentCourse
{
    public class CreateModelToParentCourseMapper : MapperBase<CreateModel, Data.Entities.ParentCourse>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToParentCourseMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.ParentCourse target)
        {
            target.EducationOrganizationId = _schoolRepository.GetSchool().EducationOrganization.EducationOrganizationId;

            target.ParentCourseCode = source.ParentCourseCode;
            target.ParentCourseTitle = source.ParentCourseTitle;
            target.ParentCourseDescription = source.ParentCourseDescription;
        }
    }
}