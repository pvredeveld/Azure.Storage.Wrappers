namespace Azure.Storage.Wrappers.File.Interfaces
{
    /// <summary>
    /// Minimal interfase of a CloudFileDirectory
    /// </summary>
    public interface ICloudFileDirectory
    {
        /// <summary>
        /// Returns a <see cref="ICloudFile"/> object that represents a file in this directory.
        /// </summary>
        /// <param name="fileName">A <see cref="System.String"/> containing the name of the file.</param>
        /// <returns>A <see cref="ICloudFile"/> object.</returns>
        ICloudFile GetFileReference(string fileName);
    }
}