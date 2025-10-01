using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BackendAPI.Services
{
    public class BlobStorageService
    {
        private readonly string? _accountName, _accountKey, _containerName;
        private BlobContainerClient? _containerClient;

        public BlobStorageService(IConfiguration config)
        {
            _accountName   = config["BlobStorage:AccountName"];
            _accountKey    = config["BlobStorage:AccountKey"];
            _containerName = config["BlobStorage:ContainerName"];
        }

        private void EnsureClient()
        {
            if (_containerClient != null) return;

            if (string.IsNullOrWhiteSpace(_accountName) ||
                string.IsNullOrWhiteSpace(_accountKey)  ||
                string.IsNullOrWhiteSpace(_containerName))
            {
                throw new InvalidOperationException("Blob storage is not configured.");
            }

            var cs = $"DefaultEndpointsProtocol=https;AccountName={_accountName};AccountKey={_accountKey};EndpointSuffix=core.windows.net";
            var svc = new BlobServiceClient(cs);
            _containerClient = svc.GetBlobContainerClient(_containerName);
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
        }

        public async Task<string> UploadFileAsync(Stream file, string fileName, string contentType)
        {
            EnsureClient();
            var blob = _containerClient!.GetBlobClient(fileName);
            await blob.UploadAsync(file, overwrite: true);
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders { ContentType = contentType });
            return blob.Uri.ToString();
        }
    }
}
