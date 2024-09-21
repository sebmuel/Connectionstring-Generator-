using ConnectionStringGenerator.Abstractions;
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

        //TODO: Add support for other databases
        IConnectionStringGenerator generator = databaseSystem switch
        {
            "postgres" => new PostgresGenerator(),
            "mssql" => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(settings))
        };

        generator.GenerateConnectionString();
        return 0;
    }
}