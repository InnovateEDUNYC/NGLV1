using NGL.Web.Data.Repositories;
using NGL.Web.Models;

namespace NGL.Web.Models.Course
{
    public class CreateModelToCourseMapper : MapperBase<CreateModel, Data.Entities.Course>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModelToCourseMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CreateModel source, Data.Entities.Course target)
        {
            target.EducationOrganizationId = _schoolRepository.GetSchool()
                .EducationOrganization.EducationOrganizationId;
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
            target.NumberOfParts = source.NumberOfParts;
            target.AcademicSubjectDescriptorId = (int?)source.AcademicSubject;
            target.CourseDescription = source.CourseDescription;
            target.DateCourseAdopted = source.DateCourseAdopted;
            target.HighSchoolCourseRequirement = source.HighSchoolCourseRequirement;
            target.CourseGPAApplicabilityTypeId = (int?) source.CourseGPAApplicability;
            target.CourseDefinedByTypeId = (int?) source.CourseDefinedBy;
            target.MinimumAvailableCreditTypeId = (int?) source.MinimumAvailableCreditType;
            target.MinimumAvailableCreditConversion = source.MinimumAvailableCreditConversion;
            target.MinimumAvailableCredit = source.MinimumAvailableCredit;
            target.MaximumAvailableCreditTypeId = (int?) source.MaximumAvailableCreditType;
            target.MaximumAvailableCreditConversion = source.MaximumAvailableCreditConversion;
            target.MaximumAvailableCredit = source.MaximumAvailableCredit;
            target.CareerPathwayTypeId = (int?) source.CareerPathway;
            target.TimeRequiredForCompletion = source.TimeRequiredForCompletion;
        }
    }
}