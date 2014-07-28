using System.IO;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageUploader : IFileUploader
    {
        public void Upload(Stream file, string container, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigManager.BlobConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists();

            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
//            blockBlob.Properties.ContentType = ;
            blockBlob.UploadFromStream(file);
        }
    }
}