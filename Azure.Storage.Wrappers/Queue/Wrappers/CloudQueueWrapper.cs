using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.Queue.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Azure.Storage.Wrappers.Queue.Wrappers
{
    internal class CloudQueueWrapper : ICloudQueue
    {
        private readonly CloudQueue cloudQueue;

        public CloudQueueWrapper(CloudQueue cloudQueue)
        {
            this.cloudQueue = cloudQueue;
        }

        public ICloudQueueClient ServiceClient => new CloudQueueClientWrapper(cloudQueue.ServiceClient);

        public Uri Uri => cloudQueue.Uri;

        public StorageUri StorageUri => cloudQueue.StorageUri;

        public string Name => cloudQueue.Name;

        public int? ApproximateMessageCount => cloudQueue.ApproximateMessageCount;

        public bool EncodeMessage
        {
            get => cloudQueue.EncodeMessage;
            set => cloudQueue.EncodeMessage = value;
        }

        public IDictionary<string, string> Metadata => cloudQueue.Metadata;

        public Task CreateAsync()
        {
            return CreateAsync(null, null);
        }

        public Task CreateAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return CreateAsync(options, operationContext, CancellationToken.None);
        }

        public Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.CreateAsync(options, operationContext, cancellationToken);
        }

        public Task<bool> CreateIfNotExistsAsync()
        {
            return CreateIfNotExistsAsync(null, null);
        }

        public Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return CreateIfNotExistsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.CreateIfNotExistsAsync(options, operationContext, cancellationToken);
        }

        public Task DeleteAsync()
        {
            return DeleteAsync(null, null);
        }

        public Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return DeleteAsync(options, operationContext, CancellationToken.None);
        }

        public Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.DeleteAsync(options, operationContext, cancellationToken);
        }

        public Task<bool> DeleteIfExistsAsync()
        {
            return DeleteIfExistsAsync(null, null);
        }

        public Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return DeleteIfExistsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.DeleteIfExistsAsync(options, operationContext, cancellationToken);
        }

        public Task SetPermissionsAsync(QueuePermissions permissions)
        {
            return SetPermissionsAsync(permissions, null, null);
        }

        public Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext)
        {
            return SetPermissionsAsync(permissions, options, operationContext, CancellationToken.None);
        }

        public Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.SetPermissionsAsync(permissions, options, operationContext, cancellationToken);
        }

        public Task<QueuePermissions> GetPermissionsAsync()
        {
            return GetPermissionsAsync(null, null);
        }

        public Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return GetPermissionsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.GetPermissionsAsync(options, operationContext, cancellationToken);
        }

        public Task<bool> ExistsAsync()
        {
            return ExistsAsync(null, null);
        }

        public Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return ExistsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.ExistsAsync(options, operationContext, cancellationToken);
        }

        public Task FetchAttributesAsync()
        {
            return FetchAttributesAsync(null, null);
        }

        public Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return FetchAttributesAsync(options, operationContext, CancellationToken.None);
        }

        public Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.FetchAttributesAsync(options, operationContext, cancellationToken);
        }

        public Task SetMetadataAsync()
        {
            return SetMetadataAsync(null, null);
        }

        public Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return SetMetadataAsync(options, operationContext, CancellationToken.None);
        }

        public Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.SetMetadataAsync(options, operationContext, cancellationToken);
        }

        public Task AddMessageAsync(CloudQueueMessage message)
        {
            return AddMessageAsync(message, new TimeSpan?(), new TimeSpan?(), null, null);
        }

        public Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext)
        {
            return AddMessageAsync(message, timeToLive, initialVisibilityDelay, options, operationContext, CancellationToken.None);
        }

        public Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext,
            CancellationToken cancellationToken)
        {
            return cloudQueue.AddMessageAsync(message, timeToLive, initialVisibilityDelay, options, operationContext, cancellationToken);
        }

        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
        {
            return UpdateMessageAsync(message, visibilityTimeout, updateFields, null, null);
        }

        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext)
        {
            return UpdateMessageAsync(message, visibilityTimeout, updateFields, options, operationContext, CancellationToken.None);
        }

        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext,
            CancellationToken cancellationToken)
        {
            return cloudQueue.UpdateMessageAsync(message, visibilityTimeout, updateFields, options, operationContext, cancellationToken);
        }

        public Task DeleteMessageAsync(CloudQueueMessage message)
        {
            return DeleteMessageAsync(message, null, null);
        }

        public Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext)
        {
            return DeleteMessageAsync(message.Id, message.PopReceipt, options, operationContext);
        }

        public Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            return DeleteMessageAsync(messageId, popReceipt, null, null);
        }

        public Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext)
        {
            return DeleteMessageAsync(messageId, popReceipt, options, operationContext, CancellationToken.None);
        }

        public Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.DeleteMessageAsync(messageId, popReceipt, options, operationContext, cancellationToken);
        }

        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount)
        {
            return GetMessagesAsync(messageCount, new TimeSpan?(), null, null);
        }

        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            return GetMessagesAsync(messageCount, visibilityTimeout, options, operationContext, CancellationToken.None);
        }

        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext,
            CancellationToken cancellationToken)
        {
            return cloudQueue.GetMessagesAsync(messageCount, visibilityTimeout, options, operationContext, cancellationToken);
        }

        public Task<CloudQueueMessage> GetMessageAsync()
        {
            return GetMessageAsync(new TimeSpan?(), null, null);
        }

        public Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            return GetMessageAsync(visibilityTimeout, options, operationContext, CancellationToken.None);
        }

        public Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.GetMessageAsync(visibilityTimeout, options, operationContext, cancellationToken);
        }

        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount)
        {
            return PeekMessagesAsync(messageCount, null, null);
        }

        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext)
        {
            return PeekMessagesAsync(messageCount, null, null, CancellationToken.None);
        }

        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.PeekMessagesAsync(messageCount, options, operationContext, cancellationToken);
        }

        public Task<CloudQueueMessage> PeekMessageAsync()
        {
            return PeekMessageAsync(null, null);
        }

        public Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return PeekMessageAsync(options, operationContext, CancellationToken.None);
        }

        public Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.PeekMessageAsync(options, operationContext, cancellationToken);
        }

        public Task ClearAsync()
        {
            return ClearAsync(null, null);
        }

        public Task ClearAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return ClearAsync(options, operationContext, CancellationToken.None);
        }

        public Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueue.ClearAsync(options, operationContext, cancellationToken);
        }
    }
}