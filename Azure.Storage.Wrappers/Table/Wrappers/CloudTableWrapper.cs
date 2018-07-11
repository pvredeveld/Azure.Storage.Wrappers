using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.Table.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Storage.Wrappers.Table.Wrappers
{
    internal class CloudTableWrapper : ICloudTable
    {
        private readonly CloudTable cloudTableImpl;

        public CloudTableWrapper(CloudTable cloudTableImpl)
        {
            this.cloudTableImpl = cloudTableImpl;
        }

        public ICloudTableClient ServiceClient => new CloudTableClientWrapper(cloudTableImpl.ServiceClient);

        public string Name => cloudTableImpl.Name;

        public Uri Uri => cloudTableImpl.Uri;

        public StorageUri StorageUri => cloudTableImpl.StorageUri;

        public sealed override string ToString() => cloudTableImpl.ToString();

        public Task<TableResult> ExecuteAsync(TableOperation operation)
        {
            return ExecuteAsync(operation, null, null, CancellationToken.None);
        }

        public Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return ExecuteAsync(operation, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.ExecuteAsync(operation, requestOptions, operationContext, cancellationToken);
        }

        public Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch)
        {
            return ExecuteBatchAsync(batch, null,null, CancellationToken.None);
        }

        public Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return ExecuteBatchAsync(batch, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.ExecuteBatchAsync(batch, requestOptions, operationContext, cancellationToken);
        }

        public Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token)
        {
            return ExecuteQuerySegmentedAsync(query, token, null,null, CancellationToken.None);
        }

        public Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, cancellationToken);
        }

        public Task CreateAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return cloudTableImpl.CreateAsync(requestOptions, operationContext);
        }

        public Task CreateAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.CreateAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return cloudTableImpl.CreateIfNotExistsAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.CreateIfNotExistsAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task DeleteAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return DeleteAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task DeleteAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.DeleteAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return DeleteIfExistsAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.DeleteIfExistsAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task<bool> ExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return ExistsAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task<bool> ExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.ExistsAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task SetPermissionsAsync(TablePermissions permissions)
        {
            return SetPermissionsAsync(permissions, null, null);
        }

        public Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return SetPermissionsAsync(permissions, requestOptions, operationContext, CancellationToken.None);
        }

        public Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.SetPermissionsAsync(permissions, requestOptions, operationContext, cancellationToken);
        }

        public Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return GetPermissionsAsync(requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.GetPermissionsAsync(requestOptions, operationContext, cancellationToken);
        }

        public Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token) where T : ITableEntity, new()
        {
            return ExecuteQuerySegmentedAsync(query, token, null, null);
        }

        public Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            return ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where T : ITableEntity, new()
        {
            return cloudTableImpl.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, cancellationToken);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token) where T : ITableEntity, new()
        {
            return ExecuteQuerySegmentedAsync(query, resolver, token, null, null);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            return ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where T : ITableEntity, new()
        {
            return cloudTableImpl.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, cancellationToken);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token)
        {
            return ExecuteQuerySegmentedAsync(query, resolver, token, null, null);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, CancellationToken.None);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudTableImpl.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, cancellationToken);
        }
    }
}