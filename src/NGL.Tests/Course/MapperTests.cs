using System;
using NGL.Web.Models.Course;
using Shouldly;
using Xunit;

namespace NGL.Tests.Course
{
    public class MapperTests
    {

        [Fact]
        public void ShouldMapCourseToCreateModel()
        {
            var courseCreateModel = new CreateModel();
            var courseEntity = new Web.Data.Entities.Course
            {
                CourseCode = "CSC101",
                CourseTitle = "Intro to Programming",
                NumberOfParts = 1,
                AcademicSubjectDescriptorId = 12,
                CourseDescription = "Learnin some Java",
                DateCourseAdopted = new DateTime(2014, 07, 03),
                HighSchoolCourseRequirement = false,
                CourseGPAApplicabilityTypeId = 1,
                CourseDefinedByTypeId = 1,
                MinimumAvailableCreditTypeId = 1,
                MinimumAvailableCreditConversion = new decimal(3.0),
                MinimumAvailableCredit = new decimal(3.0),
                MaximumAvailableCreditTypeId = 1,
                MaximumAvailableCreditConversion = new decimal(3.0),
                MaximumAvailableCredit = new decimal(3.0),
                CareerPathwayTypeId = 1,
                TimeRequiredForCompletion = 10,
            };

            var courseToCreateModelMapper = new CourseToCreateModelMapper();
            courseToCreateModelMapper.Map(courseEntity, courseCreateModel);

            courseCreateModel.CourseCode.ShouldBe("CSC101");
            courseCreateModel.CourseTitle.ShouldBe("Intro to Programming");
            courseCreateModel.NumberOfParts.ShouldBe(1);
            courseCreateModel.AcademicSubjectDescriptorId.ShouldBe(12);
            courseCreateModel.CourseDescription.ShouldBe("Learnin some Java");
            courseCreateModel.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseCreateModel.HighSchoolCourseRequirement.ShouldBe(false);
            courseCreateModel.CourseGPAApplicabilityTypeId.ShouldBe(1);
            courseCreateModel.CourseDefinedByTypeId.ShouldBe(1);
            courseCreateModel.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.CareerPathwayTypeId.ShouldBe(1);
            courseCreateModel.TimeRequiredForCompletion.ShouldBe(10);
        }

        [Fact]
        public void ShouldMapCreateModelToCourse()
        {
            var courseCreateModel = new CreateModel();
            var courseEntity = new Web.Data.Entities.Course
            {
                CourseCode = "CSC101",
                CourseTitle = "Intro to Programming",
                NumberOfParts = 1,
                AcademicSubjectDescriptorId = 12,
                CourseDescription = "Learnin some Java",
                DateCourseAdopted = new DateTime(2014, 07, 03),
                HighSchoolCourseRequirement = false,
                CourseGPAApplicabilityTypeId = 1,
                CourseDefinedByTypeId = 1,
                MinimumAvailableCreditTypeId = 1,
                MinimumAvailableCreditConversion = new decimal(3.0),
                MinimumAvailableCredit = new decimal(3.0),
                MaximumAvailableCreditTypeId = 1,
                MaximumAvailableCreditConversion = new decimal(3.0),
                MaximumAvailableCredit = new decimal(3.0),
                CareerPathwayTypeId = 1,
                TimeRequiredForCompletion = 10,
                CourseIdentity = 1
            };

            var courseToCreateModelMapper = new CourseToCreateModelMapper();
            courseToCreateModelMapper.Map(courseEntity, courseCreateModel);

            courseCreateModel.CourseCode.ShouldBe("CSC101");
            courseCreateModel.CourseTitle.ShouldBe("Intro to Programming");
            courseCreateModel.NumberOfParts.ShouldBe(1);
            courseCreateModel.AcademicSubjectDescriptorId.ShouldBe(12);
            courseCreateModel.CourseDescription.ShouldBe("Learnin some Java");
            courseCreateModel.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseCreateModel.HighSchoolCourseRequirement.ShouldBe(false);
            courseCreateModel.CourseGPAApplicabilityTypeId.ShouldBe(1);
            courseCreateModel.CourseDefinedByTypeId.ShouldBe(1);
            courseCreateModel.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.CareerPathwayTypeId.ShouldBe(1);
            courseCreateModel.TimeRequiredForCompletion.ShouldBe(10);
        }
    }
}