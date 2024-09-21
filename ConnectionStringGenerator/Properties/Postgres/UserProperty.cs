using ConnectionStringGenerator.Abstractions;
using Spectre.Console;

namespace ConnectionStringGenerator.Properties.Postgres;

public class UserProperty : ConnectionStringProperty<string>
{
    private UserProperty(string name, string value) : base(name, value)
    {
    }

    public override Markup? GetMarkup() => new Markup($"[blue]{Name}=[/]{Value};");

    public static UserProperty PromptForValue()
    {
        var user = AnsiConsole.Prompt(new TextPrompt<string>("[green bold]Enter your Postgres User: [/]").Validate(
            u => string.IsNullOrEmpty(u)
                ? ValidationResult.Error("User cannot be empty")
                : ValidationResult.Success()));

        return new UserProperty("Username", user);
    }
}