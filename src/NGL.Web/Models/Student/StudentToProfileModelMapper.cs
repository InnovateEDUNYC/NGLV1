using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models.Enrollment;

namespace NGL.Web.Models.Student
{
    public class StudentToProfileModelMapper : MapperBase<Data.Entities.Student, ProfileModel>
    {
        private readonly IMapper<Parent, ProfileParentModel> _parentToProfileParentModelMapper;
        private readonly StudentToAcademicDetailsMapper _studentToAcademicDetailsMapper;
        private readonly ProfilePhotoUrlFetcher _profilePhotoUrlFetcher;
        private readonly StudentProgramStatusToProfileProgramStatusModelMapper _studentProgramStatusToProfileProgramStatusModelMapper;
        private readonly IMapper<IList<Data.Entities.StudentSectionAttendanceEvent>, ProfileModel> _studentAttendancePercentageMapper;
        private IMapper<Web.Data.Entities.Student, StudentBiographicalInformationModel> _biographicalInfoMapper;

        public StudentToProfileModelMapper(
            StudentToAcademicDetailsMapper studentToAcademicDetailsMapper, 
            ParentToProfileParentModelMapper parentToProfileParentModelMapper,
            ProfilePhotoUrlFetcher profilePhotoUrlFetcher,
            StudentProgramStatusToProfileProgramStatusModelMapper studentProgramStatusToProfileProgramStatusModelMapper,
            IMapper<IList<Data.Entities.StudentSectionAttendanceEvent>, ProfileModel> studentAttendancePercentageMapper, IMapper<Data.Entities.Student, StudentBiographicalInformationModel> biographicalInfoMapper)
        {
            _parentToProfileParentModelMapper = parentToProfileParentModelMapper;
            _studentToAcademicDetailsMapper = studentToAcademicDetailsMapper;
            _studentProgramStatusToProfileProgramStatusModelMapper = studentProgramStatusToProfileProgramStatusModelMapper;
            _studentAttendancePercentageMapper = studentAttendancePercentageMapper;
            _biographicalInfoMapper = biographicalInfoMapper;
            _profilePhotoUrlFetcher = profilePhotoUrlFetcher;
        }

        public override void Map(Data.Entities.Student source, ProfileModel target)
        {
            MapBasicStudentInfo(source, target);
            MapHomeLanguage(source, target);
            target.ProfilePhotoUrl = _profilePhotoUrlFetcher.GetProfilePhotoUrlOrDefault(source);
            MapStudentAddress(source, target);
            MapParentInformation(source, target);
            _studentAttendancePercentageMapper.Map(source.StudentSectionAttendanceEvents.ToList(), target);
            MapFlagCount(source, target);

			if (!source.StudentAcademicDetails.IsNullOrEmpty())
                target.AcademicDetail = _studentToAcademicDetailsMapper.Build(source);

            MapProgramStatus(source, target);
        }

        private void MapFlagCount(Data.Entities.Student source, ProfileModel target)
        {
            target.FlagCount = !source.AttendanceFlags.IsNullOrEmpty() ? source.AttendanceFlags.First().FlagCount : 0;
        }

        private void MapProgramStatus(Data.Entities.Student source, ProfileModel target)
        {
            var studentProgramStatus = source.StudentProgramStatus;

            if (studentProgramStatus != null)
                target.ProgramStatus = _studentProgramStatusToProfileProgramStatusModelMapper.Build(studentProgramStatus);
            
        }

        private static void MapHomeLanguage(Data.Entities.Student source, ProfileModel target)
        {
            var homeLanguage = GetAllHomeLanguages(source).First();
            target.HomeLanguage = ((LanguageDescriptorEnum) homeLanguage.LanguageDescriptorId).Humanize();
        }

        private void MapBasicStudentInfo(Data.Entities.Student source, ProfileModel target)
        {
            target.StudentUsi = source.StudentUSI;

            target.BiographicalInformation = _biographicalInfoMapper.Build(source);
            target.Race = ((RaceTypeEnum) source.StudentRaces.First().RaceTypeId).Humanize();
        }
            
        private static IEnumerable<StudentLanguage> GetAllHomeLanguages(Data.Entities.Student source)
        {
            return source.StudentLanguages.Where(
                language => language.StudentLanguageUses.Any(
                    languageUse => languageUse.LanguageUseTypeId.Equals((int)LanguageUseTypeEnum.Homelanguage)));
        }

        private static void MapStudentAddress(Data.Entities.Student source, ProfileModel target)
        {
            var studentAddresses = source.StudentAddresses;
            var studentAddress = studentAddresses.First(address => address.AddressTypeId == (int) AddressTypeEnum.Home);
            target.Address = studentAddress.StreetNumberName;
            target.Address2 = studentAddress.ApartmentRoomSuiteNumber;
            target.City = studentAddress.City;
            target.State = ((StateAbbreviationTypeEnum) studentAddress.StateAbbreviationTypeId).Humanize();
            target.PostalCode = studentAddress.PostalCode;
        }


        private void MapParentInformation(Data.Entities.Student source, ProfileModel target)
        {
            var studentParentAssociations = source.StudentParentAssociations;
            var parent1 = studentParentAssociations.First().Parent;
            target.ProfileParentModel = _parentToProfileParentModelMapper.Build(parent1);

            if (studentParentAssociations.Count == 2)
            {
                var parent2 = studentParentAssociations.ElementAt(1).Parent;
                target.SecondProfileParentModel = _parentToProfileParentModelMapper.Build(parent2);
            }
        }

    }
}
