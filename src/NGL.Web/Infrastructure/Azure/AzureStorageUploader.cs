using System;
using System.IO;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using NGL.Web.Data.Entities;
using NGL.Web.ImageTools;

namespace NGL.Web.Infrastructure.Azure
{
    public class AzureStorageUploader : IFileUploader
    {
        public string Upload(HttpPostedFileBase file, int studentUSI, string fileCategory, string fileName)
        {
            if (file == null) return null;

            Func<string, string> makeRelativeFilePathFor = name => string.Format("{0}/{1}/{2}", studentUSI, fileCategory, name);
            var relativePath = makeRelativeFilePathFor(fileName);

            Upload(file.InputStream, ConfigManager.StudentBlobContainer, relativePath);
            return relativePath;
        }

        public void UploadProfilePhoto(int studentUsi, HttpPostedFileBase profilePhoto)
        {
            var photoStream = Resizer.ScaleImage(profilePhoto.InputStream, 200, 200);
            var thumbNailStream = Resizer.ScaleImage(profilePhoto.InputStream, 50, 50);

            Upload(photoStream, ConfigManager.StudentBlobContainer, studentUsi + "/profilePhoto");
            Upload(thumbNailStream, ConfigManager.StudentBlobContainer, studentUsi + "/profileThumbnail");
        }

        private void Upload(Stream file, string container, string fileName)
        {
            if (file == null) 
                return;
 
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigManager.BlobConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists();

            var blockBlob = blobContainer.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(file);
        }
    }
}