using Azure.Storage.Wrappers.File.Interfaces;
using Microsoft.WindowsAzure.Storage.File;

namespace Azure.Storage.Wrappers.File.Wrappers
{
    internal class CloudFileDirectoryWrapper : ICloudFileDirectory
    {
        private readonly CloudFileDirectory cloudFileDirectoryImplementation;

        public CloudFileDirectoryWrapper(CloudFileDirectory cloudFileDirectoryImplementation)
        {
            this.cloudFileDirectoryImplementation = cloudFileDirectoryImplementation;
        }

        public ICloudFile GetFileReference(string fileName)
        {
            return new CloudFileWrapper(cloudFileDirectoryImplementation.GetFileReference(fileName));
        }
    }
}