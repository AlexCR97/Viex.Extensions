using Microsoft.Extensions.Configuration;

namespace Viex.Extensions.Configuration.Tests;

public class Extensions_Tests
{
    [Theory]
    [InlineData("Logging:Console:LogLevel:SomeClass")]
    public void GetRequiredStringShouldSucceed(string key)
    {
        var configuration = GetConfiguration();

        try
        {
            var value = configuration.GetRequiredString(key);
            Assert.True(value is not null, "Value should not be null");
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }
    }

    [Theory]
    [InlineData("Logging:Console:LogLevel")]
    [InlineData("Logging:Console:LogLevel:SomeNonExistantClass")]
    public void GetRequiredStringShouldFail(string key)
    {
        var configuration = GetConfiguration();

        try
        {
            configuration.GetRequiredString(key);
            Assert.True(false, "An invalid key must be used");
        }
        catch (RequiredConfigurationException)
        {
            Assert.True(true);
        }
        catch (InvalidConfigurationException)
        {
            Assert.True(true);
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }
    }

    [Theory]
    [InlineData("Some:Random:Value")]
    public void GetRequiredIntShouldSucceed(string key)
    {
        var configuration = GetConfiguration();

        try
        {
            configuration.GetRequiredInt(key);
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }
    }

    [Theory]
    [InlineData("Some:Random")]
    [InlineData("Some:Random:IncorrectValue")]
    public void GetRequiredIntShouldFail(string key)
    {
        var configuration = GetConfiguration();

        try
        {
            configuration.GetRequiredInt(key);
            Assert.True(false, "An invalid key must be used");
        }
        catch (RequiredConfigurationException)
        {
            Assert.True(true);
        }
        catch (InvalidConfigurationException)
        {
            Assert.True(true);
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }
    }

    private static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile(@"C:\GitHub\Viex.Extensions\src\Viex.Extensions.Configuration.Tests\appsettings.Test.json")
            .Build();
    }
}
