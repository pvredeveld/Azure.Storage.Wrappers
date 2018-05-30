using Azure.Storage.Wrappers.File.Interfaces;
using Microsoft.WindowsAzure.Storage.File;

namespace Azure.Storage.Wrappers.File.Wrappers
{
    internal class CloudFileClientWrapper : ICloudFileClient
    {
        private readonly CloudFileClient cloudFileClientImplementation;

        public CloudFileClientWrapper(CloudFileClient cloudFileClientImplementation)
        {
            this.cloudFileClientImplementation = cloudFileClientImplementation;
        }

        public ICloudFileShare GetShareReference(string shareName)
        {
            return new CloudFileShareWrapper(cloudFileClientImplementation.GetShareReference(shareName));
        }
    }
}