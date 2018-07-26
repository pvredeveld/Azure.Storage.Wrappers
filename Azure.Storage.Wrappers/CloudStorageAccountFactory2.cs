using System;
using Azure.Storage.Wrappers.Interfaces;
using Azure.Storage.Wrappers.Wrappers;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Storage.Wrappers
{
    /// <summary>
    /// Factory class for the CloudStorageAccount.
    /// </summary>
    public class CloudStorageAccountFactory2 : ICloudStorageAccountFactory2
    {
        private readonly Func<string> provider;

        /// <summary>
        /// ctor that accepts a connectionstring
        /// </summary>
        /// <param name="connectionstring"></param>
        public CloudStorageAccountFactory2(string connectionstring)
        {
            provider = () => connectionstring;
        }
        
        /// <summary>
        /// ctor that accepts a IConnectionStringProvider
        /// </summary>
        /// <param name="provider">An implementation of <see cref="IConnectionStringProvider"/>.</param>
        public CloudStorageAccountFactory2(IConnectionStringProvider provider)
        {
            this.provider = provider.ProvideConnectionString;
        }

        /// <summary>
        /// ctor that accepts a func as connectionstring provider.
        /// </summary>
        /// <param name="connectionStringProvider">A <see cref="Func{TResult}"/> of type <see cref="string"/> that provides the connectionstring. This func is called by the library when a connectionstring is required to create a CloudStorageAccount.</param>
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