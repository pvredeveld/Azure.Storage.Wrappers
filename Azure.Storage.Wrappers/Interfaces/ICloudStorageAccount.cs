using Azure.Storage.Wrappers.Blob.Interfaces;
using Azure.Storage.Wrappers.File.Interfaces;
using Azure.Storage.Wrappers.Queue.Interfaces;
using Azure.Storage.Wrappers.Table.Interfaces;

namespace Azure.Storage.Wrappers.Interfaces
{
    /// <summary>
    /// Minimal interface for CloudStorageAccount
    /// </summary>
    public interface ICloudStorageAccount
    {
        /// <summary>
        /// Creates the File service client.
        /// </summary>
        /// <returns>A <see cref="ICloudFileClient"/> object.</returns>
        ICloudFileClient CreateCloudFileClient();

        /// <summary>
        /// Creates the Blob service client.
        /// </summary>
        /// <returns>A <see cref="ICloudBlobClient"/> object.</returns>
        ICloudBlobClient CreateCloudBlobClient();

        /// <summary>
        /// Creates a Table service client.
        /// </summary>
        /// <returns>A <see cref="ICloudTableClient"/> object.</returns>
        ICloudTableClient CreateCloudTableClient();

        /// <summary>
        /// Creates a Queue service client.
        /// </summary>
        /// <returns>A <see cref="ICloudQueueClient"/> object.</returns>
        ICloudQueueClient CreateCloudQueueClient();
    }
}