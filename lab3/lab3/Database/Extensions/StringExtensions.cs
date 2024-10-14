namespace lab3.Database.Extensions;

using System.Text.RegularExpressions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string input)
    {
        return string.IsNullOrEmpty(input) ? input : Regex.Match(input, "^_+")?.ToString() + Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }

    public static string ToFullSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        Match match = Regex.Match(input, "^_+");
        string lower = Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        return (match?.ToString() + lower).Replace(" ", "_");
    }

    public static string Truncate(this string value, int maxLength)
    {
        return string.IsNullOrEmpty(value) || value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}