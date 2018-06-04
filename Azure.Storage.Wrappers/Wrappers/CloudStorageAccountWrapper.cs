using Azure.Storage.Wrappers.Blob.Interfaces;
using Azure.Storage.Wrappers.Blob.Wrappers;
using Azure.Storage.Wrappers.File.Interfaces;
using Azure.Storage.Wrappers.File.Wrappers;
using Azure.Storage.Wrappers.Interfaces;
using Azure.Storage.Wrappers.Table.Interfaces;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Storage.Wrappers.Wrappers
{
    internal class CloudStorageAccountWrapper : ICloudStorageAccount
    {
        private readonly CloudStorageAccount cloudStorageAccountImplementation;

        public CloudStorageAccountWrapper(CloudStorageAccount cloudStorageAccountImplementation)
        {
            this.cloudStorageAccountImplementation = cloudStorageAccountImplementation;
        }

        public ICloudFileClient CreateCloudFileClient()
        {
            return new CloudFileClientWrapper(cloudStorageAccountImplementation.CreateCloudFileClient());
        }

        public ICloudBlobClient CreateCloudBlobClient()
        {
            return new CloudBlobClientWrapper(cloudStorageAccountImplementation.CreateCloudBlobClient());
        }

        public ICloudTableClient CreateCloudTableClient()
        {
            return new CloudTableClientWrapper(cloudStorageAccountImplementation.CreateCloudTableClient());
        }
    }
}