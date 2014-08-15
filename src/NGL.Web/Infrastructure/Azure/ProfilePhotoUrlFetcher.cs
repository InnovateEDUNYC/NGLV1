using Castle.Core.Internal;

namespace NGL.Web.Infrastructure.Azure
{
    public class ProfilePhotoUrlFetcher
    {
        private readonly IFileDownloader _downloader;
        private const string DefaultProfilePhotoUrl = "/Assets/Images/placeholder.png";

        public ProfilePhotoUrlFetcher(IFileDownloader downloader)
        {
            _downloader = downloader;
        }

        public string GetProfilePhotoUrlOrDefault(Data.Entities.Student student)
        {
            var profilePhotoUrl = _downloader.DownloadPath("student", student.StudentUSI + "/profilePhoto");
            if (profilePhotoUrl.IsNullOrEmpty())
                return DefaultProfilePhotoUrl;
            else
                return profilePhotoUrl;
        }
    }
}