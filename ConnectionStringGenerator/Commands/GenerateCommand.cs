using ConnectionStringGenerator.Generators;
using ConnectionStringGenerator.Settings;
using Spectre.Console;
using Spectre.Console.Cli;


namespace ConnectionStringGenerator.Commands;

public class GenerateCommand : Command<GenerateSettings>
{
    public override int Execute(CommandContext context, GenerateSettings settings)
    {
        var databaseSystem = settings.DatabaseSystem.ToLower();
        
        PostgresGenerator generator = databaseSystem switch
        {
            "postgres" => new PostgresGenerator(),
            _ => throw new ArgumentOutOfRangeException(nameof(settings))
        };

        generator.GenerateConnectionString();
        return 0;
    }
}