namespace PagueiBaratoApi.Domain.Extensions;

public static class StringExtensions
{
    public static string CapitalizarPrimeiraLetra(this string? value)
    {
        if (string.IsNullOrEmpty(value))
            return value ?? string.Empty;

        return char.ToUpperInvariant(value[0]) + value[1..];
    }

    public static string TrimIfNotNullOrWhiteSpace(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim();
    }
}