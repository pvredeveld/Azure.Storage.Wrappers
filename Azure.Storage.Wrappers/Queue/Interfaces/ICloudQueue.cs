using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Azure.Storage.Wrappers.Queue.Interfaces
{
    /// <summary>
    /// Represents a queue in the Microsoft Azure Queue service.
    /// </summary>
    public interface ICloudQueue
    {
        /// <summary>
        /// Gets the approximate message count for the queue.
        /// </summary>
        /// <value>The approximate message count.</value>
        int? ApproximateMessageCount { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply base64 encoding when adding or retrieving messages.
        /// </summary>
        /// <value><c>true</c> to encode messages; otherwise, <c>false</c>. The default value is <c>true</c>.</value>
        bool EncodeMessage { get; set; }

        /// <summary>
        /// Gets the queue's metadata.
        /// </summary>
        /// <value>An <see cref="IDictionary{TKey,TValue}"/> object containing the queue's metadata.</value>
        IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        /// <value>A string containing the name of the queue.</value>
        string Name { get; }

        /// <summary>
        /// Gets the <see cref="ICloudQueueClient"/> object that represents the Queue service.
        /// </summary>
        /// <value>A <see cref="ICloudQueueClient"/> object.</value>
        ICloudQueueClient ServiceClient { get; }

        /// <summary>
        /// Gets the queue URIs for both the primary and secondary locations.
        /// </summary>
        /// <value>An object of type <see cref="StorageUri"/> containing the queue's URIs for both the primary and secondary locations.</value>
        StorageUri StorageUri { get; }

        /// <summary>
        /// Gets the queue URI for the primary location.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> specifying the absolute URI to the queue at the primary location.</value>
        Uri Uri { get; }

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The <see cref="CloudQueueMessage"/> message passed in will be populated with the pop receipt, message ID, and the insertion/expiration time.</remarks>
        Task AddMessageAsync(CloudQueueMessage message);

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="timeToLive">A <see cref="TimeSpan"/> specifying the maximum time to allow the message to be in the queue, or <c>null</c>.</param>
        /// <param name="initialVisibilityDelay">A <see cref="TimeSpan"/> specifying the interval of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The <see cref="CloudQueueMessage"/> message passed in will be populated with the pop receipt, message ID, and the insertion/expiration time.</remarks>
        Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="timeToLive">A <see cref="TimeSpan"/> specifying the maximum time to allow the message to be in the queue, or <c>null</c>.</param>
        /// <param name="initialVisibilityDelay">A <see cref="TimeSpan"/> specifying the interval of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The <see cref="CloudQueueMessage"/> message passed in will be populated with the pop receipt, message ID, and the insertion/expiration time.</remarks>
        Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task ClearAsync();

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task ClearAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to create a queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task CreateAsync();

        /// <summary>
        /// Initiates an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task CreateAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        /// <remarks>This API requires Create or Write permissions.</remarks>
        Task<bool> CreateIfNotExistsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        /// <remarks>This API requires Create or Write permissions.</remarks>
        Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        /// <remarks>This API requires Create or Write permissions.</remarks>
        Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to delete a queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteAsync();

        /// <summary>
        /// Initiates an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteMessageAsync(CloudQueueMessage message);

        /// <summary>
        /// Initiates an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">A string specifying the message ID.</param>
        /// <param name="popReceipt">A string specifying the pop receipt value.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteMessageAsync(string messageId, string popReceipt);

        /// <summary>
        /// Initiates an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">A string specifying the message ID.</param>
        /// <param name="popReceipt">A string specifying the pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">A string specifying the message ID.</param>
        /// <param name="popReceipt">A string specifying the pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <c>bool</c> that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task FetchAttributesAsync();
        
        /// <summary>
        /// Initiates an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> GetMessageAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue, and specifies how long the message should be 
        /// reserved before it becomes visible, and therefore available for deletion.
        /// </summary>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue, and specifies how long the message should be 
        /// reserved before it becomes visible, and therefore available for deletion.
        /// </summary>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount);

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages from the queue using the 
        /// specified request options and operation context. This operation marks the retrieved messages as invisible in the 
        /// queue for the default visibility timeout period.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages from the queue using the 
        /// specified request options and operation context. This operation marks the retrieved messages as invisible in the 
        /// queue for the default visibility timeout period.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get the permissions settings for the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueuePermissions"/> that represents the asynchronous operation.</returns>
        Task<QueuePermissions> GetPermissionsAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get the permissions settings for the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueuePermissions"/> that represents the asynchronous operation.</returns>
        Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get the permissions settings for the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="QueuePermissions"/> that represents the asynchronous operation.</returns>
        Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> PeekMessageAsync();

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount);

        /// <summary>
        /// Initiates an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek. The maximum number of messages that may be retrieved at one time is 32.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that is an enumerable collection of type <see cref="CloudQueueMessage"/> that represents the asynchronous operation.</returns>
        Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetMetadataAsync();
        
        /// <summary>
        /// Initiates an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        
        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">A <see cref="QueuePermissions"/> object.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(QueuePermissions permissions);

        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">A <see cref="QueuePermissions"/> object.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">A <see cref="QueuePermissions"/> object.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Initiates an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="updateFields">A set of <see cref="MessageUpdateFields"/> values that specify which parts of the message are to be updated.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields);

        /// <summary>
        /// Initiates an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="updateFields">A set of <see cref="MessageUpdateFields"/> values that specify which parts of the message are to be updated.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Initiates an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">A <see cref="CloudQueueMessage"/> object.</param>
        /// <param name="visibilityTimeout">A <see cref="TimeSpan"/> specifying the visibility timeout interval.</param>
        /// <param name="updateFields">A set of <see cref="MessageUpdateFields"/> values that specify which parts of the message are to be updated.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
    }
}