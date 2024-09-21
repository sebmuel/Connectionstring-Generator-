using ConnectionStringGenerator.Abstractions;
using Spectre.Console;

namespace ConnectionStringGenerator.Properties.Postgres;

public class PortProperty : ConnectionStringProperty<int>
{
    private PortProperty(string name, int value) : base(name, value)
    {
    }

    public override Markup GetMarkup()
        => new($"[blue]{Name}=[/]{Value};");

    public static PortProperty PromptForValue()
    {
        var port = AnsiConsole.Prompt(
            new TextPrompt<int>("[green bold]Enter the port: [/]")
                .Validate(p => p <= 0
                    ? ValidationResult.Error("Please provide a valid port")
                    : ValidationResult.Success()));

        return new PortProperty("Port", port);
    }
}