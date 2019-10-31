using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
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
            CloudStorageAccount storageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out storageAccount);

            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("diodocs");

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("Result.xlsx");

            await cloudBlockBlob.UploadFromStreamAsync(uploadstream);
        }

        public async void UploadPdfAsync(MemoryStream uploadstream)
        {
            CloudStorageAccount storageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out storageAccount);

            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("diodocs");

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("Result.pdf");

            await cloudBlockBlob.UploadFromStreamAsync(uploadstream);
        }
    }
}
