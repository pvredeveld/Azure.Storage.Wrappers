﻿using Azure.Storage.Wrappers.Interfaces;
using Azure.Storage.Wrappers.Wrappers;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Storage.Wrappers
{
    /// <summary>
    /// Factory class for the CloudStorageAccount.
    /// This factory requires a connectionstring at the moment you fetch the storage account
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
}