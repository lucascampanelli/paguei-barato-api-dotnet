namespace PagueiBaratoApi.Domain.Extensions;

public static class StringExtensions
{
    public static string TrimIfNotNullOrWhiteSpace(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim();
    }
}