using System.Collections.Generic;
using System.Linq;
using Humanizer;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using NGL.Web.Models.Student;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentToProfileModelMapperTest
    {
        private StudentToProfileModelMapper _mapper;
        private IMapper<IList<StudentSectionAttendanceEvent>, ProfileModel> _studentAttendancePercentageMapperMock;

        private void SetupWithDownloaderReturning(string downloaderReturns)
        {
            var downloader = Substitute.For<IFileDownloader>();
            downloader.DownloadPath(Arg.Any<string>(), Arg.Any<string>()).Returns(downloaderReturns);
            _studentAttendancePercentageMapperMock = Substitute.For<IMapper<IList<StudentSectionAttendanceEvent>, ProfileModel>>();

            _mapper = new StudentToProfileModelMapper(new StudentToAcademicDetailsMapper(downloader),
                new ParentToProfileParentModelMapper(),
                 new ProfilePhotoUrlFetcher(downloader),
                new StudentProgramStatusToProfileProgramStatusModelMapper(downloader),
                _studentAttendancePercentageMapperMock);
        }

        [Fact]
        public void ShouldMapStudentToProfileModel()
        {
            SetupWithDownloaderReturning("");

            var student = new StudentBuilder().WithParent().WithStudentProgramStatus().WithAttendanceFlags(1).Build();

            var parent = student.StudentParentAssociations.First().Parent;
            var profileModel = new ProfileModel();

            _mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(parent, profileModel.ProfileParentModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
            profileModel.ProgramStatus.ShouldNotBe(null);
            _studentAttendancePercentageMapperMock.Received().Map(Arg.Any<IList<StudentSectionAttendanceEvent>>(), Arg.Any<ProfileModel>());
            profileModel.FlagCount.ShouldBe(student.AttendanceFlags.First().FlagCount);
        }

        [Fact]
        public void ShouldNotMapStudentProgramStatusIfItDoesNotExist()
        {
            SetupWithDownloaderReturning("");

            var student = new StudentBuilder().WithParent().Build();
            student.StudentProgramStatus = null;
            var profileModel = new ProfileModel();

            _mapper.Map(student, profileModel);

            profileModel.ProgramStatus.ShouldBe(null);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithDifferentParentAddress()
        {
            SetupWithDownloaderReturning("");

            var parent = ParentFactory.CreateParentWithAddress();
            var student = new StudentBuilder().WithParent(parent, false).Build();
            var profileModel = new ProfileModel();

            _mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(parent, profileModel.ProfileParentModel);
            ParentAddressShouldBeMapped(parent, profileModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithMultipleParents()
        {
            SetupWithDownloaderReturning("");

            var student = new StudentBuilder().WithParent().WithParent().Build();
            var firstParent = student.StudentParentAssociations.First().Parent;
            var secondParent = student.StudentParentAssociations.ElementAt(1).Parent;
            var profileModel = new ProfileModel();

            _mapper.Map(student, profileModel);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            NativeParentPropertiesShouldBeMapped(firstParent, profileModel.ProfileParentModel);
            NativeParentPropertiesShouldBeMapped(secondParent, profileModel.SecondProfileParentModel);
            StudentParentAssociationShouldBeMapped(student, profileModel);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithAcademicDetails()
        {
            var student = new StudentBuilder().WithParent().WithStudentAcademicDetails().Build();

            var fileName = student.StudentAcademicDetails.First().PerformanceHistoryFile;
            var filePath = "https://ngl.blob.core.windows.net/" + fileName;

            SetupWithDownloaderReturning(filePath);
            
            var profileModel = _mapper.Build(student);

            NativeStudentPropertiesShouldBeMapped(student, profileModel);

            var studentAcademicDetail = student.StudentAcademicDetails.First();
            profileModel.AcademicDetail.SchoolYear.ShouldBe(studentAcademicDetail.SchoolYear);
            profileModel.AcademicDetail.ReadingScore.ShouldBe(studentAcademicDetail.ReadingScore);
            profileModel.AcademicDetail.WritingScore.ShouldBe(studentAcademicDetail.WritingScore);
            profileModel.AcademicDetail.MathScore.ShouldBe(studentAcademicDetail.MathScore);
            profileModel.AcademicDetail.PerformanceHistoryFileUrl.ShouldBe(filePath);
            profileModel.AcademicDetail.PerformanceHistory.ShouldBe(studentAcademicDetail.PerfomanceHistory);
        }

        [Fact]
        public void ShouldMapStudentToProfileModelWithoutAcademicDetails()
        {
            var student = new StudentBuilder().WithParent().Build();


            SetupWithDownloaderReturning(null);

            var profileModel = _mapper.Build(student);
                

            NativeStudentPropertiesShouldBeMapped(student, profileModel);
            profileModel.AcademicDetail.ShouldBe(null);
        }

        [Fact]
        public void ShouldMapWithDefaultValueIfNoProfilePhotoExists()
        {
            SetupWithDownloaderReturning("");
            var student = new StudentBuilder().WithParent().Build();

            var profileModel = _mapper.Build(student);

            profileModel.ProfilePhotoUrl.ShouldBe("/Assets/Images/placeholder.png");
        }

        private static void NativeStudentPropertiesShouldBeMapped(Web.Data.Entities.Student student, ProfileModel profileModel)
        {
            profileModel.StudentUsi.ShouldBe(student.StudentUSI);
            profileModel.FirstName.ShouldBe(student.FirstName);
            profileModel.LastName.ShouldBe(student.LastSurname);
            profileModel.BirthDate.ShouldBe(student.BirthDate);

            var studentRace = student.StudentRaces.First();
            profileModel.Race.ShouldBe(((RaceTypeEnum)studentRace.RaceTypeId).Humanize());
            profileModel.HispanicLatinoEthnicity.ShouldBe(student.HispanicLatinoEthnicity);
            profileModel.Sex.ShouldBe(((SexTypeEnum)student.SexTypeId).Humanize());

            var studentProfileHomeLanguage = profileModel.HomeLanguage;
            studentProfileHomeLanguage.ShouldBe(((LanguageDescriptorEnum)student.StudentLanguages.First().LanguageDescriptorId).Humanize());
        }

        private static void NativeParentPropertiesShouldBeMapped(Parent parent, ProfileParentModel profileParentModel)
        {
            profileParentModel.FirstName.ShouldBe(parent.FirstName);
            profileParentModel.LastName.ShouldBe(parent.LastSurname);
            profileParentModel.Sex.ShouldBe(((SexTypeEnum) parent.SexTypeId.GetValueOrDefault()).Humanize());
            profileParentModel.TelephoneNumber.ShouldBe(parent.ParentTelephones.First().TelephoneNumber);
        }

        private static void StudentParentAssociationShouldBeMapped(Web.Data.Entities.Student student, ProfileModel profileModel)
        {
            var profileParentModel = profileModel.ProfileParentModel;
            var studentParentAssociation = student.StudentParentAssociations.First();
            profileParentModel.Relationship.ShouldBe(
                ((RelationTypeEnum)studentParentAssociation.RelationTypeId).Humanize());

            profileParentModel.SameAddressAsStudent.ShouldBe(studentParentAssociation.LivesWith);
        }

        private static void ParentAddressShouldBeMapped(Parent parent, ProfileModel profileModel)
        {
            var profileParentAddressModel = profileModel.ProfileParentModel.ProfileParentAddressModel;
            var parentHomeAddress = parent.ParentAddresses.First();

            profileParentAddressModel.Address.ShouldBe(parentHomeAddress.StreetNumberName);
            profileParentAddressModel.Address2.ShouldBe(parentHomeAddress.ApartmentRoomSuiteNumber);
            profileParentAddressModel.City.ShouldBe(parentHomeAddress.City);
            profileParentAddressModel.State.ShouldBe(
                ((StateAbbreviationTypeEnum)parentHomeAddress.StateAbbreviationTypeId).Humanize());
            profileParentAddressModel.PostalCode.ShouldBe(parentHomeAddress.PostalCode);
        }
    }
}
