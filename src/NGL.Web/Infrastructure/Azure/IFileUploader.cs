using System.Web;

namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileUploader
    {
        string Upload(HttpPostedFileBase file, string container, string fileName);
    }
}