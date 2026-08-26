namespace PagueiBaratoApi.Domain.Options;

public record AzureStorageOptions
{
    public static readonly string SectionName = "AzureStorage";
    public string ImagesContainerName { get; init; } = string.Empty;
}