using Spectre.Console;

namespace ConnectionStringGenerator.Abstractions;

public interface IPrintable
{
    public Markup? GetMarkup();
}