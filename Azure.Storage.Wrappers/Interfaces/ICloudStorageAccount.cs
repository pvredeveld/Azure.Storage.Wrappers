using Azure.Storage.Wrappers.Blob.Interfaces;
using Azure.Storage.Wrappers.File.Interfaces;

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
    }
}