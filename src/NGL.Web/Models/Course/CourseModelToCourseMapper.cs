using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Course
{
    public class CourseModelToCourseMapper : MapperBase<CourseModel, Data.Entities.Course>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CourseModelToCourseMapper(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public override void Map(CourseModel source, Data.Entities.Course target)
        {
            target.EducationOrganizationId = _schoolRepository.GetSchool()
                .EducationOrganization.EducationOrganizationId;
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
            target.NumberOfParts = source.NumberOfParts;
            target.AcademicSubjectDescriptorId = source.AcademicSubjectDescriptorId;
            target.CourseDescription = source.CourseDescription;
            target.DateCourseAdopted = source.DateCourseAdopted;
            target.HighSchoolCourseRequirement = source.HighSchoolCourseRequirement;
            target.CourseGPAApplicabilityTypeId = source.CourseGPAApplicabilityTypeId;
            target.CourseDefinedByTypeId = source.CourseDefinedByTypeId;
            target.MinimumAvailableCreditTypeId = source.MinimumAvailableCreditTypeId;
            target.MinimumAvailableCreditConversion = source.MinimumAvailableCreditConversion;
            target.MinimumAvailableCredit = source.MinimumAvailableCredit;
            target.MaximumAvailableCreditTypeId = source.MaximumAvailableCreditTypeId;
            target.MaximumAvailableCreditConversion = source.MaximumAvailableCreditConversion;
            target.MaximumAvailableCredit = source.MaximumAvailableCredit;
            target.CareerPathwayTypeId = source.CareerPathwayTypeId;
            target.TimeRequiredForCompletion = source.TimeRequiredForCompletion;
        }
    }
}