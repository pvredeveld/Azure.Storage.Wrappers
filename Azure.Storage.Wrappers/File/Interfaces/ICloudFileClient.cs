namespace Azure.Storage.Wrappers.File.Interfaces
{
    /// <summary>
    /// Minimal interface of a CloudFileClient
    /// </summary>
    public interface ICloudFileClient
    {
        /// <summary>
        /// Returns a reference to a <see cref="ICloudFileShare"/> object with the specified name.
        /// </summary>
        /// <param name="shareName">A string containing the name of the share.</param>
        /// <returns>A reference to a share.</returns>
        ICloudFileShare GetShareReference(string shareName);
    }
}