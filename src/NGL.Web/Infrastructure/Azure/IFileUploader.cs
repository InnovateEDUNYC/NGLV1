using System.IO;
using System.Web;

namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileUploader
    {
        void Upload(Stream file, string container, string fileName);
    }
}