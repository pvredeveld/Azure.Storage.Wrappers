namespace Azure.Storage.Wrappers.File.Interfaces
{
    /// <summary>
    /// Minimal interfase of a CloudFileShare
    /// </summary>
    public interface ICloudFileShare
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICloudFileDirectory GetRootDirectoryReference();
    }
}