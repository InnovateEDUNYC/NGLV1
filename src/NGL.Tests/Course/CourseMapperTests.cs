using System;
using NGL.Web.Models.Course;
using Shouldly;
using Xunit;

namespace NGL.Tests.Course
{
    public class CourseMapperTests
    {

        [Fact]
        public void ShouldMapCourseEntityToCourseViewModel()
        {
            var courseModel = new CourseModel();
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

            var courseToCourseModelMapper = new CourseToCourseModelMapper();
            courseToCourseModelMapper.Map(courseEntity, courseModel);

            courseModel.CourseCode.ShouldBe("CSC101");
            courseModel.CourseTitle.ShouldBe("Intro to Programming");
            courseModel.NumberOfParts.ShouldBe(1);
            courseModel.AcademicSubjectDescriptorId.ShouldBe(12);
            courseModel.CourseDescription.ShouldBe("Learnin some Java");
            courseModel.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseModel.HighSchoolCourseRequirement.ShouldBe(false);
            courseModel.CourseGPAApplicabilityTypeId.ShouldBe(1);
            courseModel.CourseDefinedByTypeId.ShouldBe(1);
            courseModel.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseModel.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseModel.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseModel.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseModel.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseModel.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseModel.CareerPathwayTypeId.ShouldBe(1);
            courseModel.TimeRequiredForCompletion.ShouldBe(10);
        }

        [Fact]
        public void ShouldMapCourseViewModelToCourseEntity()
        {
            var courseModel = new CourseModel();
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

            var courseToCourseModelMapper = new CourseToCourseModelMapper();
            courseToCourseModelMapper.Map(courseEntity, courseModel);

            courseModel.CourseCode.ShouldBe("CSC101");
            courseModel.CourseTitle.ShouldBe("Intro to Programming");
            courseModel.NumberOfParts.ShouldBe(1);
            courseModel.AcademicSubjectDescriptorId.ShouldBe(12);
            courseModel.CourseDescription.ShouldBe("Learnin some Java");
            courseModel.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseModel.HighSchoolCourseRequirement.ShouldBe(false);
            courseModel.CourseGPAApplicabilityTypeId.ShouldBe(1);
            courseModel.CourseDefinedByTypeId.ShouldBe(1);
            courseModel.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseModel.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseModel.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseModel.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseModel.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseModel.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseModel.CareerPathwayTypeId.ShouldBe(1);
            courseModel.TimeRequiredForCompletion.ShouldBe(10);
        }
    }
}