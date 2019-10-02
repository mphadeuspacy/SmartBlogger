using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Nls.SmartBlogger.Common;

namespace Nls.SmartBlogger.Core.DomainServices
{
    public interface ICloudBlobStorageService
    {
        IList<string> GetBlobUriListForAccountContainer(string account, string container, string key);
    }

    public class CloudBlobStorageService : ICloudBlobStorageService
    {
        public IList<string> GetBlobUriListForAccountContainer(string account, string containerName, string key)
        {
            CloudBlobClient cloudBlobClient = CreateCloudBlobClient(account, key);

            CloudBlobContainer cloudBlobContainer = CreateCloudBlobContainerIfNotExists(cloudBlobClient, containerName);

            // Retrieve all blob uris as string
            IList<string> blogUriList = cloudBlobContainer.ListBlobs(null, false)
                .Select(blob => ((CloudBlockBlob) blob).Uri.ToString())
                .ToList();

            return blogUriList;
        }

        #region Helpers
        private CloudBlobClient CreateCloudBlobClient(string azureBlobStorageAccount, string key)
        {
            var credentials = new StorageCredentials(azureBlobStorageAccount, key);

            var storageAccount = new CloudStorageAccount(credentials, true);

            return storageAccount.CreateCloudBlobClient();
        }

        private CloudBlobContainer CreateCloudBlobContainerIfNotExists(CloudBlobClient cloudBlobClient, string containerName)
        {
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);

            if (cloudBlobContainer.CreateIfNotExists())
            {
                cloudBlobContainer.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            return cloudBlobContainer;
        } 
        #endregion
    }
}
