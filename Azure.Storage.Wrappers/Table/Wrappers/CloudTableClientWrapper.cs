using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.Table.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Storage.Wrappers.Table.Wrappers
{
    internal class CloudTableClientWrapper : ICloudTableClient
    {
        private readonly CloudTableClient cloudTableClientImplementation;

        public CloudTableClientWrapper(CloudTableClient cloudTableClientImplementation)
        {
            this.cloudTableClientImplementation = cloudTableClientImplementation;
        }

        public IBufferManager BufferManager => cloudTableClientImplementation.BufferManager;

        public StorageCredentials Credentials => cloudTableClientImplementation.Credentials;

        public Uri BaseUri => cloudTableClientImplementation.BaseUri;

        public StorageUri StorageUri => cloudTableClientImplementation.StorageUri;

        public TableRequestOptions DefaultRequestOptions => cloudTableClientImplementation.DefaultRequestOptions;

        public ICloudTable GetTableReference(string tableName)
        {
            return new CloudTableWrapper(cloudTableClientImplementation.GetTableReference(tableName));
        }

        public AuthenticationScheme AuthenticationScheme => cloudTableClientImplementation.AuthenticationScheme;

        public Task<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken)
        {
            return ListTablesSegmentedAsync(null, null, currentToken, null, null);
        }

        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken)
        {
            return ListTablesSegmentedAsync(prefix, null, currentToken, null, null);
        }

        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return ListTablesSegmentedAsync(prefix, maxResults, currentToken, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableClientImplementation.ListTablesSegmentedAsync(prefix, maxResults, currentToken, requestOptions, operationContext, cancellationToken);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync()
        {
            return GetServicePropertiesAsync(null, null);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return GetServicePropertiesAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableClientImplementation.GetServicePropertiesAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            return SetServicePropertiesAsync(properties, null, null);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return SetServicePropertiesAsync(properties, requestOptions, operationContext, CancellationToken.None);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableClientImplementation.SetServicePropertiesAsync(properties, requestOptions, operationContext, cancellationToken);
        }

        public Task<ServiceStats> GetServiceStatsAsync()
        {
            return GetServiceStatsAsync(null, null);
        }

        public Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext)
        {
            return GetServiceStatsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableClientImplementation.GetServiceStatsAsync(options, operationContext, cancellationToken);
        }
    }
}