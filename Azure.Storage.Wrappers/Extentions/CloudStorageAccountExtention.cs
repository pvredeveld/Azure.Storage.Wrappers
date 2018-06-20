using Azure.Storage.Wrappers.Blob.Interfaces;
using Azure.Storage.Wrappers.Interfaces;

namespace Azure.Storage.Wrappers.Extentions
{
    /// <summary>
    /// CloudStorageAccount extention class
    /// </summary>
    public static class CloudStorageAccountExtention
    {
        /// <summary>
        /// Gets a reference to a <see cref="ICloudBlobContainer"/> inside the <see cref="ICloudStorageAccount"/>
        /// </summary>
        /// <param name="storageAccount">The <see cref="ICloudStorageAccount"/></param>
        /// <param name="containerName">The name of the container</param>
        /// <returns>An instance of an <see cref="ICloudBlobContainer"/>.</returns>
        public static ICloudBlobContainer GetContainerReference(this ICloudStorageAccount storageAccount, string containerName)
        {
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }
    }
}
