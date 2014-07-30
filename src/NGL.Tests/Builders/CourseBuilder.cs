using System;
using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class CourseBuilder
    {
        private const string CourseCode = "MATH101";
        private const string CourseTitle = "Pre Algebra";
        private const int NumberOfParts = 1;
        private const AcademicSubjectDescriptorEnum AcademicSubject = AcademicSubjectDescriptorEnum.Mathematics;
        private const string CourseDescription = "This is a math class";
        private static readonly DateTime DateCourseAdopted = new DateTime(2014, 07, 06);
        private const bool HighSchoolCourseRequirement = false;

        private const CourseGPAApplicabilityTypeEnum CourseGpaApplicability =
            CourseGPAApplicabilityTypeEnum.Applicable;

        private const CourseDefinedByTypeEnum CourseDefinedBy = CourseDefinedByTypeEnum.School;
        private const CreditTypeEnum MinimumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
        private const decimal MinimumAvailableCreditConversion = 3m;
        private const decimal MinimumAvailableCredit = 3m;
        private const CreditTypeEnum MaximumAvailableCreditType = CreditTypeEnum.Semesterhourcredit;
        private const decimal MaximumAvailableCreditConversion = 3m;
        private const decimal MaximumAvailableCredit = 3m;
        private const CareerPathwayTypeEnum CareerPathway = CareerPathwayTypeEnum.HospitalityandTourism;
        private const int TimeRequiredForCompletion = 2000;


        public Web.Data.Entities.Course Build()
        {
            return new Web.Data.Entities.Course
            {
                EducationOrganizationId = Constants.EducationOrganizationId,
                CourseCode = CourseCode,
                CourseTitle = CourseTitle,
                NumberOfParts = NumberOfParts,
                AcademicSubjectDescriptorId = (int) AcademicSubject,
                CourseDescription = CourseDescription,
                DateCourseAdopted = DateCourseAdopted,
                HighSchoolCourseRequirement = HighSchoolCourseRequirement,
                CourseGPAApplicabilityTypeId = (int) CourseGpaApplicability,
                CourseDefinedByTypeId = (int) CourseDefinedBy,
                MinimumAvailableCreditTypeId = (int) MinimumAvailableCreditType,
                MinimumAvailableCreditConversion = MinimumAvailableCreditConversion,
                MinimumAvailableCredit = MinimumAvailableCredit,
                MaximumAvailableCreditTypeId = (int) MaximumAvailableCreditType,
                MaximumAvailableCreditConversion = MaximumAvailableCreditConversion,
                MaximumAvailableCredit = MaximumAvailableCredit,
                CareerPathwayTypeId = (int) CareerPathway,
                TimeRequiredForCompletion = TimeRequiredForCompletion
            };
        }

    }
}
