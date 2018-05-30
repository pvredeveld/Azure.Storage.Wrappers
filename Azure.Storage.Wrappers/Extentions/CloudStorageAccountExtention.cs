using System.Threading.Tasks;
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
        /// 
        /// </summary>
        /// <param name="storageAccount"></param>
        /// <param name="containerName"></param>
        /// <returns>An instance of an <see cref="ICloudBlobContainer"/>.</returns>
        public static async Task<ICloudBlobContainer> GetContainerReferenceAsync(this ICloudStorageAccount storageAccount, string containerName)
        {
            var blobClient = storageAccount.CreateCloudBlobClient();
            return await blobClient.GetContainerReferenceAsync(containerName);
        }
    }
}
