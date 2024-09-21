using System.Reflection;
using ConnectionStringGenerator.Abstractions;
using ConnectionStringGenerator.Properties.Postgres;
using Spectre.Console;

namespace ConnectionStringGenerator.ConnectionStrings;

public class PostgresConnectionString : ConnectionString
{
    public HostProperty Host { get; init; }
    public PortProperty Port { get; init; }
    public DatabaseProperty? Database { get; init; }
    public UserProperty User { get; init; }

    private PostgresConnectionString(
        HostProperty host,
        PortProperty port,
        DatabaseProperty database, UserProperty user)
    {
        Host = host;
        Port = port;
        Database = database;
        User = user;
    }

    public static PostgresConnectionString Generate()
    {
        HostProperty host = HostProperty.PromptForValue();
        PortProperty port = PortProperty.PromptForValue();
        DatabaseProperty database = DatabaseProperty.PromptForValue();
        UserProperty user = UserProperty.PromptForValue();
        
        return new PostgresConnectionString(host, port, database, user);
    }

    /// <summary>
    /// Prints the properties of the Postgres connection string in a formatted manner.
    /// The method iterates through the printable properties of the connection string
    /// and uses `AnsiConsole` to display each property with appropriate formatting.
    /// </summary>
    public void Print()
    {
        List<IPrintable> printableProperties = GetPrintableProperties();

        AnsiConsole.Write(new Markup("[green]Here is your Postgres ConnectionString: [/]\n"));

        foreach (Markup? markup in printableProperties.Select(printableProperty => printableProperty.GetMarkup())
                     .OfType<Markup>())
        {
            AnsiConsole.Write(markup);
        }
    }
};