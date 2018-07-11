using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Storage.Wrappers.Table.Interfaces
{
    /// <summary>
    /// Provides a client-side logical representation of the Microsoft Azure Table Service. This client is used to configure and execute requests against the Table Service.
    /// </summary>
    /// <remarks>The service client encapsulates the endpoint or endpoints for the Table service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>    
    public interface ICloudTableClient
    {

        /// <summary>
        /// Gets or sets the authentication scheme to use to sign HTTP requests.
        /// </summary>
        /// <remarks>
        /// <para>This property is set only when Shared Key or Shared Key Lite credentials are used; it does not apply to authentication via a shared access signature 
        /// or anonymous access.</para>
        /// </remarks>
        AuthenticationScheme AuthenticationScheme { get; }

        /// <summary>
        /// Gets the base URI for the Table service client at the primary location.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> object containing the base URI used to construct the Table service client at the primary location.</value>
        Uri BaseUri { get; }

        /// <summary>
        /// Gets or sets a buffer manager that implements the <see cref="IBufferManager"/> interface, 
        /// specifying a buffer pool for use with operations against the Table service client.
        /// </summary>
        /// <value>An object of type <see cref="IBufferManager"/>.</value>
        IBufferManager BufferManager { get; }

        /// <summary>
        /// Gets the account credentials used to create the Table service client.
        /// </summary>
        /// <value>A <see cref="StorageCredentials"/> object.</value>
        StorageCredentials Credentials { get; }

        /// <summary>
        /// Gets or sets the default request options for requests made via the Table service client.
        /// </summary>
        /// <value>A <see cref="TableRequestOptions"/> object.</value>
        TableRequestOptions DefaultRequestOptions { get; }

        /// <summary>
        /// Gets the Table service endpoints for both the primary and secondary locations.
        /// </summary>
        /// <value>An object of type <see cref="StorageUri"/> containing Table service URIs for both the primary and secondary locations.</value>
        StorageUri StorageUri { get; }

        /// <summary>
        /// Initiates an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync();
        
        /// <summary>
        /// Initiates an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceProperties"/> that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceProperties"/> that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Table service endpoint.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Table service endpoint.
        /// </summary>
        /// <param name="options">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Table service endpoint.
        /// </summary>
        /// <param name="options">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync(TableRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a reference to the specified table.
        /// </summary>
        /// <param name="tableName">A string containing the name of the table.</param>
        /// <returns>A <see cref="ICloudTable"/> object.</returns>
        ICloudTable GetTableReference(string tableName);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment of tables that start with the specified prefix.
        /// </summary>
        /// <param name="prefix">A string containing the table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResultSegment"/> that represents the asynchronous operation.</returns>
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment of tables that start with the specified prefix.
        /// </summary>
        /// <param name="prefix">A string containing the table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResultSegment"/> that represents the asynchronous operation.</returns>
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);
        
        /// <summary>
        /// Initiates an asynchronous operation to return a result segment of tables that start with the specified prefix.
        /// </summary>
        /// <param name="prefix">A string containing the table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResultSegment"/> that represents the asynchronous operation.</returns>
        Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken);
        
        /// <summary>
        /// Initiates an asynchronous operation to return a result segment of tables.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="TableResultSegment"/> that represents the asynchronous operation.</returns>
        Task<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken);

        /// <summary>
        /// Initiates an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties);

        /// <summary>
        /// Initiates an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);
    }
}