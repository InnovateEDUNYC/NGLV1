using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageUploader : IFileUploader
    {
        private readonly CloudBlobClient _blobClient;

        public AzureStorageUploader()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobConnectionString"));
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public string Upload(HttpPostedFileBase file, string container, string fileName)
        {
            var blobContainer = _blobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists();

            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            blockBlob.Properties.ContentType = file.ContentType;
            blockBlob.UploadFromStream(file.InputStream);
            
            return blockBlob.Uri.ToString();
        }
    }
}