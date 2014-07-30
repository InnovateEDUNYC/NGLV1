using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Course;

namespace NGL.Tests.Course
{
    public class CreateCourseModelBuilder
    {
        private const string CourseCode = "MATH101";
        private const string CourseTitle = "Pre Algebra";
        private const int NumberOfParts = 1;
        private const AcademicSubjectDescriptorEnum AcademicSubject = AcademicSubjectDescriptorEnum.Mathematics;
        private const string CourseDescription = "This is a math class";
        private static DateTime DateCourseAdopted = new DateTime(2014, 07, 06);
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


        public CreateModel Build()
        {
            return new CreateModel
            {
                CourseCode = CourseCode,
                CourseTitle = CourseTitle,
                NumberOfParts = NumberOfParts,
                AcademicSubject = AcademicSubject,
                CourseDescription = CourseDescription,
                DateCourseAdopted = DateCourseAdopted,
                HighSchoolCourseRequirement = HighSchoolCourseRequirement,
                CourseGPAApplicability = CourseGpaApplicability,
                CourseDefinedBy = CourseDefinedBy,
                MinimumAvailableCreditType = MinimumAvailableCreditType,
                MinimumAvailableCreditConversion = MinimumAvailableCreditConversion,
                MinimumAvailableCredit = MinimumAvailableCredit,
                MaximumAvailableCreditType = MaximumAvailableCreditType,
                MaximumAvailableCreditConversion = MaximumAvailableCreditConversion,
                MaximumAvailableCredit = MaximumAvailableCredit,
                CareerPathway = CareerPathway,
                TimeRequiredForCompletion = TimeRequiredForCompletion 
            };
        }
    }
}
