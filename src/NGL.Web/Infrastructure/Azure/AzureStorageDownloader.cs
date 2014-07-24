using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageDownloader
    {
        private CloudBlobClient _blobClient;

        public AzureStorageDownloader()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobConnectionString"));
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public void Download(HttpPostedFileBase file, string container, string fileName)
        {
            var blobContainer = _blobClient.GetContainerReference(container);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            
            blockBlob.Properties.ContentType = file.ContentType;
            blockBlob.DownloadToStream(file.InputStream);
        }
    }
}