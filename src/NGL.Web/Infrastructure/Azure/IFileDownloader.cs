namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileDownloader
    {
        string DownloadPath(string container, string fileName);
    }
}