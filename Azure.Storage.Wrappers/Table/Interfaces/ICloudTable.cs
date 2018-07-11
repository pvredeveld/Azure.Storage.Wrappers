using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Storage.Wrappers.Table.Interfaces
{
    /// <summary>
    /// Represents a Microsoft Azure table.
    /// </summary>
    public interface ICloudTable
    {

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>A string containing the name of the table.</value>
        string Name { get; }

        /// <summary>
        /// Gets the <see cref="ICloudTableClient"/> object that represents the Table service.
        /// </summary>
        /// <value>A <see cref="ICloudTableClient"/> object .</value>
        ICloudTableClient ServiceClient { get; }

        /// <summary>
        /// Gets the table's URIs for both the primary and secondary locations.
        /// </summary>
        /// <value>An object of type <see cref="StorageUri"/> containing the table's URIs for both the primary and secondary locations.</value>
        StorageUri StorageUri { get; }

        /// <summary>
        /// Gets the table URI for the primary location.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> specifying the absolute URI to the table at the primary location.</value>
        Uri Uri { get; }

        /// <summary>
        /// Initiates an asynchronous operation to create a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task CreateAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Initiates an asynchronous operation to create a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task CreateAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        /// <remarks>This API performs an existence check and therefore requires list permissions.</remarks>
        Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Initiates an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        /// <remarks>This API performs an existence check and therefore requires list permissions.</remarks>
        Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);
        
        /// <summary>
        /// Initiates an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to delete the table if it exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Initiates an asynchronous operation to delete the table if it exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation that executes an asynchronous table operation.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<TableResult> ExecuteAsync(TableOperation operation);

        /// <summary>
        /// Initiates an asynchronous operation that executes an asynchronous table operation.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation that executes an asynchronous table operation.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to execute a batch of operations on a table.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <returns>A <see cref="Task{T}"/> object that is list of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch);

        /// <summary>
        /// Initiates an asynchronous operation to execute a batch of operations on a table.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that is list of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to execute a batch of operations on a table.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that is list of type <see cref="TableResult"/> that represents the asynchronous operation.</returns>
        Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to perform a segmented query on a table.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{DynamicTableEntity}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token);

        /// <summary>
        /// Initiates an asynchronous operation to perform a segmented query on a table.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{DynamicTableEntity}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to perform a segmented query on a table.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{DynamicTableEntity}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);


        /// <summary>
        /// Initiates an asynchronous operation to execute a query in segmented mode and apply the specified <see cref="EntityResolver{T}"/> to the results.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to execute a query in segmented mode and apply the specified <see cref="EntityResolver{T}"/> to the results.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to execute a query in segmented mode and apply the specified <see cref="EntityResolver{T}"/> to the results.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to query a table in segmented mode.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to query a table in segmented mode.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to query a table in segmented mode.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where T : ITableEntity, new();

        /// <summary>
        /// Initiates an asynchronous operation to execute a segmented query and apply the specified <see cref="EntityResolver{T}"/> to the result.
        /// </summary>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{TResult}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token);

        /// <summary>
        /// Initiates an asynchronous operation to execute a segmented query and apply the specified <see cref="EntityResolver{T}"/> to the result.
        /// </summary>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{TResult}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to execute a segmented query and apply the specified <see cref="EntityResolver{T}"/> to the result.
        /// </summary>
        /// <typeparam name="TResult">The type into which the <see cref="EntityResolver{T}"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use.</param>
        /// <param name="resolver">An <see cref="EntityResolver{T}"/> instance which creates a projection of the table query result entities into the specified type <c>TResult</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableQuerySegment{TResult}"/> that represents the asynchronous operation.</returns>
        Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Initiates an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get the permissions settings for the table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TablePermissions"/> that represents the asynchronous operation.</returns>
        Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Initiates an asynchronous operation to get the permissions settings for the table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TablePermissions"/> that represents the asynchronous operation.</returns>
        Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);


        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the table.
        /// </summary>
        /// <param name="permissions">A <see cref="TablePermissions"/> object that represents the permissions to set.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(TablePermissions permissions);

        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the table.
        /// </summary>
        /// <param name="permissions">A <see cref="TablePermissions"/> object that represents the permissions to set.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the table.
        /// </summary>
        /// <param name="permissions">A <see cref="TablePermissions"/> object that represents the permissions to set.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Returns the name of the table.
        /// </summary>
        /// <returns>A string containing the name of the table.</returns>
        string ToString();
    }
}