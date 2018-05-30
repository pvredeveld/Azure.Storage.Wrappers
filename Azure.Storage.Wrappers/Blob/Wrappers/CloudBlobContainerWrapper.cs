using Azure.Storage.Wrappers.Blob.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Storage.Wrappers.Blob.Wrappers
{
    internal class CloudBlobContainerWrapper : ICloudBlobContainer
    {
        private readonly CloudBlobContainer container;

        public CloudBlobContainerWrapper(CloudBlobContainer container)
        {
            this.container = container;
        }
        public ICloudBlockBlob GetBlockBlobReference(string path)
        {
            return new CloudBlockBlobWrapper(container.GetBlockBlobReference(path));
       }
    }
}