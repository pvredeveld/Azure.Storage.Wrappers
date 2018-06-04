using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Storage.Wrappers.Table.Interfaces
{
    public interface ICloudTableClient
    {
        AuthenticationScheme AuthenticationScheme { get; }
        Uri BaseUri { get; }
        IBufferManager BufferManager { get; }
        StorageCredentials Credentials { get; }
        TableRequestOptions DefaultRequestOptions { get; }
        StorageUri StorageUri { get; }
        Task<ServiceProperties> GetServicePropertiesAsync();
        Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext);
        Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);
        Task<ServiceStats> GetServiceStatsAsync();
        Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext);
        Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        CloudTable GetTableReference(string tableName);
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext);
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken);
        Task<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken);
        Task SetServicePropertiesAsync(ServiceProperties properties);
        Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext);
        Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);
    }
}