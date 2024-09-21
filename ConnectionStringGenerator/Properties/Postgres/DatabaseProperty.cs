using ConnectionStringGenerator.Abstractions;
using Spectre.Console;

namespace ConnectionStringGenerator.Properties.Postgres;

/// <summary>
/// Represents a database property that is a part of a connection string for a PostgreSQL database.
/// The PostgreSQL database property specifies the name of the database to connect to.
/// </summary>
public class DatabaseProperty : ConnectionStringProperty<string?>
{
    private DatabaseProperty(string name, string? value) : base(name, value)
    {
    }

    public override Markup? GetMarkup()
    {
        return string.IsNullOrEmpty(Value) ? null : new Markup($"[blue]{Name}=[/]{Value};");
    }

    public static DatabaseProperty PromptForValue()
    {
        var database = AnsiConsole.Prompt(
            new TextPrompt<string>($"[green bold][[optional]] Specifies the database name you want to connect to: [/]")
                .AllowEmpty());

        return new DatabaseProperty("Database", database);
    }
}