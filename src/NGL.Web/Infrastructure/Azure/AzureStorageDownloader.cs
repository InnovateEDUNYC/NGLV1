using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageDownloader : IFileDownloader
    {

        public string DownloadPath(string container, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(container);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);

            var sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-10);
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(2);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;
            var sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);

            return blockBlob.Uri + sasContainerToken;
        }
    }
}