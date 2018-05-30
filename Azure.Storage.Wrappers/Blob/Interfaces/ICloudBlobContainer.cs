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
    }
}