using System;
using Azure.Storage.Wrappers.Interfaces;
using Azure.Storage.Wrappers.Wrappers;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Storage.Wrappers
{
    /// <summary>
    /// Factory class for the CloudStorageAccount
    /// </summary>
    public class CloudStorageAccountFactory : ICloudStorageAccountFactory
    {
        /// <summary>
        /// Fetches a ICloudStorageAccount
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>A <see cref="ICloudStorageAccount"/> object.</returns>
        public ICloudStorageAccount FetchByConnectionString(string connectionString)
        {
            return new CloudStorageAccountWrapper(CloudStorageAccount.Parse(connectionString));
        }
    }

    public interface IConnectionStringProvider
    {
        string ProvideConnectionString();
    }

    /// <summary>
    /// Factory class for the CloudStorageAccount
    /// </summary>
    public class CloudStorageAccountFactory2 : ICloudStorageAccountFactory2
    {
        private readonly Func<string> provider;

        public CloudStorageAccountFactory2(IConnectionStringProvider provider)
        {
            this.provider = provider.ProvideConnectionString;
        }

        public CloudStorageAccountFactory2(Func<string> connectionStringProvider)
        {
            provider = connectionStringProvider;
        }

        /// <summary>
        /// Fetches a ICloudStorageAccount
        /// </summary>
        /// <returns>A <see cref="ICloudStorageAccount"/> object.</returns>
        public ICloudStorageAccount FetchCloudStorageAccount()
        {
            return new CloudStorageAccountWrapper(CloudStorageAccount.Parse(provider.Invoke()));
        }
    }
}