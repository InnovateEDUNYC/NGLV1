using System;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Course;
using NSubstitute;
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
                AcademicSubjectDescriptorId = (int)AcademicSubjectDescriptorEnum.EnglishLanguageArts,
                CourseDescription = "Learnin some Java",
                DateCourseAdopted = new DateTime(2014, 07, 03),
                HighSchoolCourseRequirement = false,
                CourseGPAApplicabilityTypeId = (int)CourseGPAApplicabilityTypeEnum.Applicable,
                CourseDefinedByTypeId = (int)CourseDefinedByTypeEnum.LEA,
                MinimumAvailableCreditTypeId = 1,
                MinimumAvailableCreditConversion = new decimal(3.0),
                MinimumAvailableCredit = new decimal(3.0),
                MaximumAvailableCreditTypeId = 1,
                MaximumAvailableCreditConversion = new decimal(3.0),
                MaximumAvailableCredit = new decimal(3.0),
                CareerPathwayTypeId = (int)CareerPathwayTypeEnum.AgricultureFoodandNaturalResources,
                TimeRequiredForCompletion = 10,
            };

            var courseToCreateModelMapper = new CourseToCreateModelMapper();
            courseToCreateModelMapper.Map(courseEntity, courseCreateModel);

            courseCreateModel.CourseCode.ShouldBe("CSC101");
            courseCreateModel.CourseTitle.ShouldBe("Intro to Programming");
            courseCreateModel.NumberOfParts.ShouldBe(1);
            courseCreateModel.AcademicSubject.ShouldBe(AcademicSubjectDescriptorEnum.EnglishLanguageArts);
            courseCreateModel.CourseDescription.ShouldBe("Learnin some Java");
            courseCreateModel.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseCreateModel.HighSchoolCourseRequirement.ShouldBe(false);
            courseCreateModel.CourseGPAApplicability.ShouldBe(CourseGPAApplicabilityTypeEnum.Applicable);
            courseCreateModel.CourseDefinedBy.ShouldBe(CourseDefinedByTypeEnum.LEA);
            courseCreateModel.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseCreateModel.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseCreateModel.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseCreateModel.CareerPathway.ShouldBe(CareerPathwayTypeEnum.AgricultureFoodandNaturalResources);
            courseCreateModel.TimeRequiredForCompletion.ShouldBe(10);
        }

        [Fact]
        public void ShouldMapCreateModelToCourse()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(
                new School
                {
                    EducationOrganization = new EducationOrganization { EducationOrganizationId = 1 }
                });

            var courseEntity = new Web.Data.Entities.Course();
            var courseCreateModel = new CreateModel
            {
                CourseCode = "CSC101",
                CourseTitle = "Intro to Programming",
                NumberOfParts = 1,
                AcademicSubject = AcademicSubjectDescriptorEnum.EnglishLanguageArts,
                CourseDescription = "Learnin some Java",
                DateCourseAdopted = new DateTime(2014, 07, 03),
                HighSchoolCourseRequirement = false,
                CourseGPAApplicability = CourseGPAApplicabilityTypeEnum.Applicable,
                CourseDefinedBy = CourseDefinedByTypeEnum.LEA,
                MinimumAvailableCreditTypeId = 1,
                MinimumAvailableCreditConversion = new decimal(3.0),
                MinimumAvailableCredit = new decimal(3.0),
                MaximumAvailableCreditTypeId = 1,
                MaximumAvailableCreditConversion = new decimal(3.0),
                MaximumAvailableCredit = new decimal(3.0),
                CareerPathway = CareerPathwayTypeEnum.AgricultureFoodandNaturalResources,
                TimeRequiredForCompletion = 10,
            };

            var createModelToCourseMapper = new CreateModelToCourseMapper(schoolRepository);
            createModelToCourseMapper.Map(courseCreateModel, courseEntity);

            courseEntity.CourseCode.ShouldBe("CSC101");
            courseEntity.CourseTitle.ShouldBe("Intro to Programming");
            courseEntity.NumberOfParts.ShouldBe(1);
            courseEntity.AcademicSubjectDescriptorId.ShouldBe((int)AcademicSubjectDescriptorEnum.EnglishLanguageArts);
            courseEntity.CourseDescription.ShouldBe("Learnin some Java");
            courseEntity.DateCourseAdopted.ShouldBe(new DateTime(2014, 07, 03));
            courseEntity.HighSchoolCourseRequirement.ShouldBe(false);
            courseEntity.CourseGPAApplicabilityTypeId.ShouldBe((int)CourseGPAApplicabilityTypeEnum.Applicable);
            courseEntity.CourseDefinedByTypeId.ShouldBe((int)CourseDefinedByTypeEnum.LEA);
            courseEntity.MinimumAvailableCreditTypeId.ShouldBe(1);
            courseEntity.MinimumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseEntity.MinimumAvailableCredit.ShouldBe(new decimal(3.0));
            courseEntity.MaximumAvailableCreditTypeId.ShouldBe(1);
            courseEntity.MaximumAvailableCreditConversion.ShouldBe(new decimal(3.0));
            courseEntity.MaximumAvailableCredit.ShouldBe(new decimal(3.0));
            courseEntity.CareerPathwayTypeId.ShouldBe((int)CareerPathwayTypeEnum.AgricultureFoodandNaturalResources);
            courseEntity.TimeRequiredForCompletion.ShouldBe(10);
        }
    }
}