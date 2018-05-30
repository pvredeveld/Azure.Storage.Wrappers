using Azure.Storage.Wrappers.File.Interfaces;
using Microsoft.WindowsAzure.Storage.File;

namespace Azure.Storage.Wrappers.File.Wrappers
{
    internal class CloudFileShareWrapper : ICloudFileShare
    {
        private readonly CloudFileShare cloudFileShareImplementation;

        public CloudFileShareWrapper(CloudFileShare cloudFileShareImplementation)
        {
            this.cloudFileShareImplementation = cloudFileShareImplementation;
        }

        public ICloudFileDirectory GetRootDirectoryReference()
        {
            return new CloudFileDirectoryWrapper(cloudFileShareImplementation.GetRootDirectoryReference());
        }
    }
}