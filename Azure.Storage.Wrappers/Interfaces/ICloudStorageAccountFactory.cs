namespace Azure.Storage.Wrappers.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICloudStorageAccountFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        ICloudStorageAccount FetchByConnectionString(string connectionString);
    }

    public interface ICloudStorageAccountFactory2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICloudStorageAccount FetchCloudStorageAccount();
    }

}