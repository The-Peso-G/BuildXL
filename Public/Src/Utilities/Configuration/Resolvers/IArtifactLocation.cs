// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace BuildXL.Utilities.Configuration
{
    /// <summary>
    /// Helper class for downloading and finding tools
    /// </summary>
    public partial interface IArtifactLocation
    {
        /// <summary>
        /// Optional fixed version to use when downloading from the default location
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Url where to download the tool from.
        /// This will override the version used
        /// </summary>
        string ToolUrl { get; }

        /// <summary>
        /// Optional hash to verify that the correct tool was downloaded.
        /// </summary>
        string Hash { get; }
    }
}
