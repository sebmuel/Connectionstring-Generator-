using ConnectionStringGenerator.Abstractions;
using Spectre.Console;

namespace ConnectionStringGenerator.Properties.Postgres;

public class HostProperty : ConnectionStringProperty<string>
{
    private HostProperty(string name, string value) : base(name, value)
    {
    }


    public static HostProperty PromptForValue()
    {
        var host = AnsiConsole.Prompt(new TextPrompt<string>("[green bold]Specifies the host name: [/]")
            .Validate(h => string.IsNullOrEmpty(h)
                ? ValidationResult.Error("Please provide a valid host")
                : ValidationResult.Success()));

        return new HostProperty("Server", host);
    }

    public override Markup GetMarkup()
        => new($"[blue]{Name}=[/]{Value};");
}