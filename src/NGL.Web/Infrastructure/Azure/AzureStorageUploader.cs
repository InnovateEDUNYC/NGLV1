using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageUploader : IFileUploader
    {
        public void Upload(HttpPostedFileBase file, string container, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigManager.BlobConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists();

            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            blockBlob.Properties.ContentType = file.ContentType;
            blockBlob.UploadFromStream(file.InputStream);
        }
    }
}