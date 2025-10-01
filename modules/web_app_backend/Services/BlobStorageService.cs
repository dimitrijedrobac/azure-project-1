using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BackendAPI.Services
{
    /// <summary>
    /// Wraps the Azure Blob Storage client to provide simplified methods for
    /// uploading files. A single container is created (if it doesn't already
    /// exist) when the service is constructed. Files are uploaded with
    /// content‑type information preserved and the resulting URI is returned.
    /// </summary>
    public class BlobStorageService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(IConfiguration configuration)
        {
            // Read configuration values for the storage account from
            // appsettings.json. These values should be set using Azure portal
            // application settings when deployed to Azure.
            var accountName = configuration["BlobStorage:AccountName"];
            var accountKey = configuration["BlobStorage:AccountKey"];
            var containerName = configuration["BlobStorage:ContainerName"];

            // Build the connection string manually. This pattern comes from
            // official Azure samples for .NET. See the Azure documentation for
            // details on constructing a connection string for Blob Storage. The
            // endpoint uses the standard core.windows.net suffix.
            var connectionString =
                $"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix=core.windows.net";

            // Create a BlobServiceClient which can be used to create a
            // container client. If the container does not exist it will be
            // created with PublicAccessType.Blob so that images are publicly
            // accessible via URL.
            var blobServiceClient = new BlobServiceClient(connectionString);
            _containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
        }

        /// <summary>
        /// Uploads a stream to Blob Storage and returns the URL of the stored
        /// blob. The caller must provide a unique file name to prevent
        /// collisions. ContentType is set on the blob so that browsers know
        /// how to display the file.
        /// </summary>
        /// <param name="fileStream">Stream containing the file contents</param>
        /// <param name="fileName">Desired name of the blob</param>
        /// <param name="contentType">MIME type of the file</param>
        /// <returns>The absolute URI to the uploaded blob</returns>
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, overwrite: true);
            await blobClient.SetHttpHeadersAsync(new BlobHttpHeaders { ContentType = contentType });
            return blobClient.Uri.ToString();
        }
    }
}