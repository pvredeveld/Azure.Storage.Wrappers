using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.File.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Azure.Storage.Wrappers.File.Wrappers
{
    internal class CloudFileWrapper : ICloudFile
    {
        private readonly CloudFile cloudFileImplementation;

        public CloudFileWrapper(CloudFile cloudFileImplementation)
        {
            this.cloudFileImplementation = cloudFileImplementation;
        }

        public Task<string> DownloadTextAsync(AccessCondition accessCondition, FileRequestOptions fileRequestOptions, OperationContext operationContext)
        {
            return DownloadTextAsync(accessCondition, fileRequestOptions, operationContext, CancellationToken.None);
        }

        public async Task<string> DownloadTextAsync(AccessCondition accessCondition , FileRequestOptions fileRequestOptions, OperationContext operationContext, CancellationToken token)
        {
            return await cloudFileImplementation.DownloadTextAsync(accessCondition, fileRequestOptions, operationContext,token);
        }

        public Task<bool> ExistsAsync(FileRequestOptions options, OperationContext operationContext)
        {
            return cloudFileImplementation.ExistsAsync(options, operationContext, CancellationToken.None);
        }

        public async Task<bool> ExistsAsync(FileRequestOptions options , OperationContext operationContext , CancellationToken token)
        {
            return await cloudFileImplementation.ExistsAsync(options, operationContext, token);
        }
    }
}