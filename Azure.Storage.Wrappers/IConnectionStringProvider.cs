namespace Azure.Storage.Wrappers
{
    /// <summary>
    /// Interface to implement when you what inject a connectionstring provider
    /// </summary>
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// This method is called by the library when a connectionstring is required.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        string ProvideConnectionString();
    }
}