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

        public ICloudBlobContainer GetContainerReference(string containerName)
        {
            var container = cloudBlobClientImplementation.GetContainerReference(containerName);
            return new CloudBlobContainerWrapper(container);
        }
    }
}