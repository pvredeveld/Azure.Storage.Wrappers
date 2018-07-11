using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Azure.Storage.Wrappers.Queue.Interfaces
{
    /// <summary>
    /// Provides a client-side logical representation of the Microsoft Azure Queue service. This client is used to configure and execute requests against the Queue service.
    /// </summary>
    public interface ICloudQueueClient
    {
        /// <summary>
        /// Gets or sets a buffer manager that implements the <see cref="IBufferManager"/> interface, 
        /// specifying a buffer pool for use with operations against the Queue service client.
        /// </summary>
        /// <value>An object of type <see cref="IBufferManager"/>.</value>
        IBufferManager BufferManager { get; set; }

        /// <summary>
        /// Gets the account credentials used to create the Queue service client.
        /// </summary>
        /// <value>A <see cref="StorageCredentials"/> object.</value>
        StorageCredentials Credentials { get; }

        /// <summary>
        /// Gets the base URI for the Queue service client, at the primary location.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> object for the Queue service client, at the primary location.</value>
        Uri BaseUri { get; }

        /// <summary>
        /// Gets the Queue service endpoints for both the primary and secondary locations.
        /// </summary>
        /// <value>An object of type <see cref="StorageUri"/> containing Queue service URIs for both the primary and secondary locations.</value>
        StorageUri StorageUri { get; }

        /// <summary>
        /// Gets and sets the default request options for requests made via the Queue service client.
        /// </summary>
        /// <value>A <see cref="QueueRequestOptions"/> object.</value>
        QueueRequestOptions DefaultRequestOptions { get; set; }

        /// <summary>
        /// Gets a value indicating whether the service client is used with Path style or Host style.
        /// </summary>
        /// <value>Is <c>true</c> if use path style URIs; otherwise, <c>false</c>.</value>
        AuthenticationScheme AuthenticationScheme { get; set; }

        /// <summary>
        /// Returns a reference to a <see cref="CloudQueue"/> object with the specified name.
        /// </summary>
        /// <param name="queueName">A string containing the name of the queue.</param>
        /// <returns>A <see cref="CloudQueue"/> object.</returns>
        ICloudQueue GetQueueReference(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment containing a collection of queues.
        /// </summary>      
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueueResultSegment"/> that represents the asynchronous operation.</returns>
        Task<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment containing a collection of queues.
        /// </summary>
        /// <param name="prefix">A string containing the queue name prefix.</param>  
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueueResultSegment"/> that represents the asynchronous operation.</returns>
        Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment containing a collection of queues.
        /// </summary>
        /// <param name="prefix">A string containing the queue name prefix.</param>
        /// <param name="detailsIncluded">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueueResultSegment"/> that represents the asynchronous operation.</returns>
        Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to return a result segment containing a collection of queues.
        /// </summary>
        /// <param name="prefix">A string containing the queue name prefix.</param>
        /// <param name="detailsIncluded">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueueResultSegment"/> that represents the asynchronous operation.</returns>
        Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get service properties for the Queue service.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceProperties"/> that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get service properties for the Queue service.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceProperties"/> that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get service properties for the Queue service.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceProperties"/> that represents the asynchronous operation.</returns>
        Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to set service properties for the Queue service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties);

        /// <summary>
        /// Initiates an asynchronous operation to set service properties for the Queue service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to set service properties for the Queue service.
        /// </summary>
        /// <param name="properties">A <see cref="ServiceProperties"/> object.</param>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Queue service endpoint.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Queue service endpoint.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get service stats for the secondary Queue service endpoint.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="ServiceStats"/> that represents the asynchronous operation.</returns>
        Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
    }
}