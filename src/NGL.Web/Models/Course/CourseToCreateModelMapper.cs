﻿using NGL.Web.Models;
﻿using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Course
{
    public class CourseToCreateModelMapper : MapperBase<Data.Entities.Course, CreateModel>
    {
        public override void Map(Data.Entities.Course source, CreateModel target)
        {
            target.CourseCode = source.CourseCode;
            target.CourseTitle = source.CourseTitle;
            target.NumberOfParts = source.NumberOfParts;
            target.AcademicSubject = (AcademicSubjectDescriptorEnum?) source.AcademicSubjectDescriptorId;
            target.CourseDescription = source.CourseDescription;
            target.DateCourseAdopted = source.DateCourseAdopted;
            target.HighSchoolCourseRequirement = source.HighSchoolCourseRequirement;
            target.CourseGPAApplicability = (CourseGPAApplicabilityTypeEnum?) source.CourseGPAApplicabilityTypeId;
            target.CourseDefinedBy = (CourseDefinedByTypeEnum?) source.CourseDefinedByTypeId;
            target.MinimumAvailableCreditTypeId = source.MinimumAvailableCreditTypeId;
            target.MinimumAvailableCreditConversion = source.MinimumAvailableCreditConversion;
            target.MinimumAvailableCredit = source.MinimumAvailableCredit;
            target.MaximumAvailableCreditTypeId = source.MaximumAvailableCreditTypeId;
            target.MaximumAvailableCreditConversion = source.MaximumAvailableCreditConversion;
            target.MaximumAvailableCredit = source.MaximumAvailableCredit;
            target.CareerPathway = (CareerPathwayTypeEnum?) source.CareerPathwayTypeId;
            target.TimeRequiredForCompletion = source.TimeRequiredForCompletion;
        }
    }
}