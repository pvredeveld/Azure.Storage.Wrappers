namespace Azure.Storage.Wrappers.Blob.Interfaces
{
    /// <summary>
    /// Minimal interface of CloudBlobClient
    /// </summary>
    public interface ICloudBlobClient
    {
        /// <summary>
        /// Returns a reference to a <see cref="ICloudBlobContainer"/> object with the specified name.
        /// Does also a CreateIfNotExists when reference is received.
        /// </summary>
        /// <param name="containerName">A string containing the name of the container.</param>
        /// <returns>An instance of an <see cref="ICloudBlobContainer"/>.</returns>
        ICloudBlobContainer GetContainerReference(string containerName);
    }
}