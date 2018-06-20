using System.Threading.Tasks;

namespace Azure.Storage.Wrappers.Blob.Interfaces
{
    /// <summary>
    /// Minimal interface of a CloudBlobContainer
    /// </summary>
    public interface ICloudBlobContainer
    {
        /// <summary>
        /// Returns a reference to a <see cref="ICloudBlockBlob"/> object with the specified name.
        /// </summary>
        /// <param name="containerName">A string containing the name of the container.</param>
        /// <returns>An instance of an <see cref="ICloudBlockBlob"/>.</returns>
        ICloudBlockBlob GetBlockBlobReference(string containerName);

        /// <summary>
        /// Create the container if it does not exist
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task<bool> CreateIfNotExistsAsync();
    }
}