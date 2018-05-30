using System.Threading.Tasks;
using Azure.Storage.Wrappers.Blob.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Storage.Wrappers.Blob.Wrappers
{
    internal class CloudBlobClientWrapper : ICloudBlobClient
    {
        private readonly CloudBlobClient cloudBlobClientImplementation;

        public CloudBlobClientWrapper(CloudBlobClient cloudBlobClientImplementation)
        {
            this.cloudBlobClientImplementation = cloudBlobClientImplementation;
        }

        public async Task<ICloudBlobContainer> GetContainerReferenceAsync(string containerName)
        {
            var container = cloudBlobClientImplementation.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            return new CloudBlobContainerWrapper(container);
        }
    }
}