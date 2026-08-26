using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using PagueiBaratoApi.Domain.Options;
using PagueiBaratoApi.Infrastructure.Adapters.Interfaces;

namespace PagueiBaratoApi.Infrastructure.Adapters;

public class ImagensAdapter : IImagensAdapter
{
    private readonly BlobServiceClient _blobServiceClient;
    private IOptions<AzureStorageOptions> _azureStorageOptions;

    public ImagensAdapter(BlobServiceClient blobServiceClient, IOptions<AzureStorageOptions> azureStorageOptions)
    {
        _blobServiceClient = blobServiceClient;
        _azureStorageOptions = azureStorageOptions;
    }

    public async Task<string?> ResolverUrlAsync(string? path)
    {
        if (string.IsNullOrEmpty(path))
            return null;

        var container = _blobServiceClient.GetBlobContainerClient(_azureStorageOptions.Value.ImagesContainerName);
        return container.GetBlobClient(path).Uri.ToString();
    }
}