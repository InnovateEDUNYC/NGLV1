using System.Web;

namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileUploader
    {
        string Upload(HttpPostedFileBase file, int studentUSI, string fileCategory, string fileName);
        void UploadProfilePhoto(int studentUsi, HttpPostedFileBase profilePhoto);
    }
}