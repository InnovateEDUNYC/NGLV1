using Castle.Core.Internal;

namespace NGL.Web.Infrastructure.Azure
{
    public class ProfilePhotoUrlFetcher
    {
        private readonly IFileDownloader _downloader;
        private const string DefaultProfilePhotoUrl = "/Assets/Images/placeholder.png";
        private const string DefaultProfilePhotoThumbailUrl = "/Assets/Images/placeholder.png";

        public ProfilePhotoUrlFetcher(IFileDownloader downloader)
        {
            _downloader = downloader;
        }

        public string GetProfilePhotoUrlOrDefault(Data.Entities.Student student)
        {
            var profilePhotoUrl = _downloader.DownloadPath("student", student.StudentUSI + "/profilePhoto");
            return profilePhotoUrl.IsNullOrEmpty() ? DefaultProfilePhotoUrl : profilePhotoUrl;
        }

        public string GetProfilePhotoThumnailUrlOrDefault(int studentUsi)
        {
            var profilePhotoUrl = _downloader.DownloadPath("student", studentUsi + "/profileThumbnail");
            return profilePhotoUrl.IsNullOrEmpty() ? DefaultProfilePhotoThumbailUrl : profilePhotoUrl;
        }
    }
}