using System.Web;

namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileUploader
    {
        void Upload(HttpPostedFileBase file, string container, string fileName);
    }
}