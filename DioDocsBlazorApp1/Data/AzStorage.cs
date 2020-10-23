using Azure.Storage.Blobs;
using System.IO;

namespace DioDocsBlazorApp1.Data
{
    public class AzStorage
    {
        private readonly string storageConnectionString;

        public AzStorage(string connectionstring)
        {
            storageConnectionString = connectionstring;
        }

        public async void UploadExcelAsync(MemoryStream uploadstream)
        {
            BlobContainerClient container = new BlobContainerClient(storageConnectionString, "diodocs");

            BlobClient blob = container.GetBlobClient("Result.xlsx");

            await blob.UploadAsync(uploadstream);
        }

        public async void UploadPdfAsync(MemoryStream uploadstream)
        {
            BlobContainerClient container = new BlobContainerClient(storageConnectionString, "diodocs");

            BlobClient blob = container.GetBlobClient("Result.pdf");

            await blob.UploadAsync(uploadstream);
        }
    }
}
