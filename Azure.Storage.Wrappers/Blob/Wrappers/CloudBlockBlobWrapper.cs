using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.Blob.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Storage.Wrappers.Blob.Wrappers
{
    internal class CloudBlockBlobWrapper : ICloudBlockBlob
    {
        private readonly CloudBlockBlob blockBlob;

        public CloudBlockBlobWrapper(CloudBlockBlob blockBlob)
        {
            this.blockBlob = blockBlob;
        }

        public Task UploadTextAsync(string content)
        {
            return blockBlob.UploadTextAsync(content);
        }

        public Task<bool> ExistsAsync()
        {
            return blockBlob.ExistsAsync();
        }

        public Task<string> DownloadTextAsync()
        {
            return blockBlob.DownloadTextAsync();
        }

        public Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, CancellationToken.None);
        }

        public Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blockBlob.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, cancellationToken);
        }
    }
}