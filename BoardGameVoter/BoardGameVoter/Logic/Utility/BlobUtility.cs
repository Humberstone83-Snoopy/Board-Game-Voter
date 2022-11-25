using ImageMagick;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BoardGameVoter.Logic.Utility
{
    public class BlobUtility
    {
        private readonly CloudBlobClient __BlobClient;

        public BlobUtility(string storageAccountNameOption, string storageAccountKeyOption)
        {
            CloudStorageAccount _StorageAccount = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={storageAccountNameOption};AccountKey={storageAccountKeyOption}");

            __BlobClient = _StorageAccount.CreateCloudBlobClient();
        }

        //public static void ResizeUploadedImage(
        //    [BlobTrigger("images/{name}")] Stream input,
        //    [Blob("scaledimages/{name}", FileAccess.Write)] Stream output)
        //{
        //    SquishImage(input, output);
        //}

        public async Task UploadBlob(string blobContainer, IFormFile file, string directoryName)
        {
            int _FileNameStartLocation = file.FileName.LastIndexOf("//") + 1;
            string _FileName = file.FileName.Substring(_FileNameStartLocation);

            CloudBlobContainer _Container = __BlobClient.GetContainerReference(blobContainer);
            await _Container.CreateIfNotExistsAsync();

            await _Container.SetPermissionsAsync(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            CloudBlockBlob _BlockBlob = _Container.GetBlockBlobReference(directoryName + @"\" + _FileName);

            MemoryStream _Stream = new MemoryStream();
            MagickImage _Image = new MagickImage(file.OpenReadStream());

            _Image.AutoOrient();

            await _Stream.WriteAsync(_Image.ToByteArray(), 0, _Image.ToByteArray().Count());

            _Stream.Position = 0;

            await _BlockBlob.UploadFromStreamAsync(_Stream);
        }

        public async Task<List<IListBlobItem>> GetBlobs(string blobContainer)
        {
            CloudBlobContainer _Container = __BlobClient.GetContainerReference(blobContainer);
            await _Container.CreateIfNotExistsAsync();

            await _Container.SetPermissionsAsync(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            BlobContinuationToken _BlobContinuationToken = null;
            List<IListBlobItem> _BlobItems = new();

            do
            {
                var _Response = await _Container.ListBlobsSegmentedAsync(_BlobContinuationToken);
                _BlobContinuationToken = _Response.ContinuationToken;
                _BlobItems.AddRange(_Response.Results);
            }
            while (_BlobContinuationToken != null);

            return _BlobItems;
        }
    }
}
