using Microsoft.Extensions.Configuration;

namespace Viex.Extensions.Configuration;

public static class Extensions
{
    public static string GetRequiredString(this IConfiguration configuration, string key)
    {
        var section = configuration.GetSection(key);

        if (section is null)
            throw new RequiredConfigurationException(key);

        var value = section.Value;

        if (string.IsNullOrWhiteSpace(value))
            throw new RequiredConfigurationException(key);

        return value;
    }

    public static int GetRequiredInt(this IConfiguration configuration, string key)
    {
        var value = configuration[key];

        if (string.IsNullOrWhiteSpace(value))
            throw new RequiredConfigurationException(key);

        if (int.TryParse(value, out var intValue))
            return intValue;

        throw new InvalidConfigurationException(key, typeof(int));
    }
}

public class RequiredConfigurationException : Exception
{
    public RequiredConfigurationException(string key)
        : base($"The configuration variable \"{key}\" is required and has not been set.") { }
}

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string key, Type expectedType)
        : base($"The configuration variable \"{key}\" is invalid. Expected a \"{expectedType.Name}\" type.") { }
}
