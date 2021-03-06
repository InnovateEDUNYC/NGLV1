﻿using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NGL.Web.Data.Entities;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageDownloader : IFileDownloader
    {

        public string DownloadPath(string container, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigManager.BlobConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(container);
            if (blobContainer == null) return null;
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            if (blockBlob == null || !blockBlob.Exists()) return null;
            
            var sasConstraints = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(2),
                Permissions = SharedAccessBlobPermissions.Read
            };
            var sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);

            return blockBlob.Uri + sasContainerToken;
        }
    }
}
