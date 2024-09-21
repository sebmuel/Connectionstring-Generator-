using Spectre.Console.Cli;

namespace ConnectionStringGenerator.Settings;

public class GenerateSettings : CommandSettings
{
    [CommandArgument(0, "<DATABASE_SYSTEM>")]
    public required string DatabaseSystem { get; set; }
}