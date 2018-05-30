using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Azure.Storage.Wrappers.File.Interfaces
{
    /// <summary>
    /// Minimal interfase of a CloudFile
    /// </summary>
    public interface ICloudFile
    {
        /// <summary>
        /// Downloads the file's contents as a string.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the file.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>The contents of the file, as a string.</returns>
        Task<string> DownloadTextAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads the file's contents as a string.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the file.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The contents of the file, as a string.</returns>
        Task<string> DownloadTextAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the file.
        /// </summary>
        /// <param name="options">A <see cref="FileRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        Task<bool> ExistsAsync(FileRequestOptions options , OperationContext operationContext , CancellationToken cancellationToken);

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the file.
        /// </summary>
        /// <param name="options">A <see cref="FileRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        Task<bool> ExistsAsync(FileRequestOptions options, OperationContext operationContext);
    }
}