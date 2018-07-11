using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Wrappers.Queue.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Azure.Storage.Wrappers.Queue.Wrappers
{
    internal class CloudQueueClientWrapper : ICloudQueueClient
    {
        private readonly CloudQueueClient cloudQueueClientImpl;

        public CloudQueueClientWrapper(CloudQueueClient cloudQueueClientImpl)
        {
            this.cloudQueueClientImpl = cloudQueueClientImpl;
        }

        public IBufferManager BufferManager
        {
            get => cloudQueueClientImpl.BufferManager;
            set => cloudQueueClientImpl.BufferManager = value;
        }

        public StorageCredentials Credentials => cloudQueueClientImpl.Credentials;

        public Uri BaseUri => cloudQueueClientImpl.BaseUri;

        public StorageUri StorageUri => cloudQueueClientImpl.StorageUri;

        public QueueRequestOptions DefaultRequestOptions
        {
            get => cloudQueueClientImpl.DefaultRequestOptions;
            set => cloudQueueClientImpl.DefaultRequestOptions = value;
        }

        public ICloudQueue GetQueueReference(string queueName)
        {
            return new CloudQueueWrapper(cloudQueueClientImpl.GetQueueReference(queueName));
        }

        public AuthenticationScheme AuthenticationScheme
        {
            get => cloudQueueClientImpl.AuthenticationScheme;
            set => cloudQueueClientImpl.AuthenticationScheme = value;
        }

        public Task<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken)
        {
            return ListQueuesSegmentedAsync(null, QueueListingDetails.None, new int?(), currentToken, null, null);
        }

        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken)
        {
            return ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, new int?(), currentToken, null, null);
        }

        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken,
            QueueRequestOptions options, OperationContext operationContext)
        {
            return ListQueuesSegmentedAsync(prefix, detailsIncluded, maxResults, currentToken, options, operationContext, CancellationToken.None);
        }

        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken,
            QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueueClientImpl.ListQueuesSegmentedAsync(prefix, detailsIncluded, maxResults, currentToken, options, operationContext, cancellationToken);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync()
        {
            return GetServicePropertiesAsync(null, null);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return GetServicePropertiesAsync(options, operationContext, CancellationToken.None);
        }

        public Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueueClientImpl.GetServicePropertiesAsync(options, operationContext, cancellationToken);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            return SetServicePropertiesAsync(properties, null, null);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            return SetServicePropertiesAsync(properties, requestOptions, operationContext, CancellationToken.None);
        }

        public Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueueClientImpl.SetServicePropertiesAsync(properties, requestOptions, operationContext, cancellationToken);
        }

        public Task<ServiceStats> GetServiceStatsAsync()
        {
            return GetServiceStatsAsync(null, null);
        }

        public Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return GetServiceStatsAsync(options, operationContext, CancellationToken.None);
        }

        public Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return cloudQueueClientImpl.GetServiceStatsAsync(options, operationContext, cancellationToken);
        }
    }
}