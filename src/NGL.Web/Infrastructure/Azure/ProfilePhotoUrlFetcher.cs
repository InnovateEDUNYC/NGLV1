using Castle.Core.Internal;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure.Azure;

namespace NGL.Web.Models.Student
{
    public class ProfilePhotoUrlFetcher
    {
        private readonly IFileDownloader _downloader;
        private readonly IGenericRepository _genericRepository;
        private const string DefaultProfilePhotoUrl = "/Assets/Images/placeholder.png";

        public ProfilePhotoUrlFetcher(IFileDownloader downloader, IGenericRepository genericRepository)
        {
            _downloader = downloader;
            _genericRepository = genericRepository;
        }

        public string GetProfilePhotoUrlOrDefault(Data.Entities.Student student)
        {
            var profilePhotoUrl = _downloader.DownloadPath("student", student.StudentUSI + "/profilePhoto");
            if (profilePhotoUrl.IsNullOrEmpty())
                return DefaultProfilePhotoUrl;
            else
                return profilePhotoUrl;
        }

        public string GetProfilePhotoUrlOrDefault(int studentUsi)
        {
            var student = _genericRepository.Get<Data.Entities.Student>(s => s.StudentUSI == studentUsi);
            return GetProfilePhotoUrlOrDefault(student);
        }
    }
}