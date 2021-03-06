// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using BuildXL.Cache.ContentStore.Hashing;
using BuildXL.Cache.ContentStore.Interfaces.Results;
using BuildXL.Cache.ContentStore.Interfaces.Stores;
using BuildXL.Cache.ContentStore.Interfaces.Tracing;

// ReSharper disable All
namespace BuildXL.Cache.ContentStore.Interfaces.FileSystem
{
    /// <summary>
    /// Handles requests that machine to copy a file to itself.
    /// </summary>
    public interface ICopyRequestHandler
    {
        /// <summary>
        /// Requests the machine to copy a file to itself.
        /// </summary>
        /// <param name="context">The context of the operation</param>
        /// <param name="hash">The hash of the file to be copied.</param>
        /// <param name="token">A cancellation token</param>
        Task<BoolResult> HandleCopyFileRequestAsync(Context context, ContentHash hash, CancellationToken token);
    }

    /// <summary>
    /// Handles requests to push content to this machine.
    /// </summary>
    public interface IPushFileHandler
    {
        /// <nodoc />
        Task<PutResult> HandlePushFileAsync(Context context, ContentHash hash, AbsolutePath sourcePath, CancellationToken token);

        /// <nodoc />
        bool CanAcceptContent(Context context, ContentHash hash, out RejectionReason rejectionReason);
    }

    /// <nodoc />
    public enum RejectionReason
    {
        /// <nodoc />   
        Accepted,

        /// <nodoc />
        ContentAvailableLocally,

        /// <nodoc />
        OlderThanLastEvictedContent,

        /// <nodoc />
        NotSupported
    }

    /// <summary>
    /// Handles delete requests to this machine
    /// </summary>
    public interface IDeleteFileHandler
    {
        /// <nodoc />
        Task<DeleteResult> HandleDeleteAsync(Context context, ContentHash contentHash, DeleteContentOptions deleteOptions);
    }
}
