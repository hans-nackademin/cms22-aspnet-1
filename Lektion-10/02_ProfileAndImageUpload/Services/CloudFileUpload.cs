using Azure.Storage.Blobs;

namespace _02_ProfileAndImageUpload.Services
{
    public class CloudFileUpload
    {
        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;
        private BlobClient _blobClient;

        public CloudFileUpload(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("StorageAccount"));
            _blobContainerClient = GetBlobContainerClient("profile-images");
        }

        private BlobContainerClient GetBlobContainerClient(string containerName)
        {
            try { return _blobServiceClient.CreateBlobContainer(containerName); }
            catch { return _blobServiceClient.GetBlobContainerClient(containerName); }
        }


        public async Task<string> UploadAsync(IFormFile file)
        {
            var imageName = $"profile_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            using var ms = new MemoryStream();
            file.CopyTo(ms);
            _blobClient = _blobContainerClient.GetBlobClient(imageName);
            ms.Position = 0;
            await _blobClient.UploadAsync(ms);

            return imageName;
        }
    }
}
