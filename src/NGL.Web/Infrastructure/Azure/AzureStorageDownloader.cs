using System;
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

        public string DownloadPath(string container, string fileName)
        {
            var blobContainer = _blobClient.GetContainerReference(container);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);

            var sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(4);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List;
            var sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);

            return blockBlob.Uri + sasContainerToken;
        }
    }
}