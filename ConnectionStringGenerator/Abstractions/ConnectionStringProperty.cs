using Spectre.Console;

namespace ConnectionStringGenerator.Abstractions;

/// <summary>
/// Represents a connection string property with a specified type.
/// postgres: https://www.npgsql.org/doc/connection-string-parameters.html
/// </summary>
/// <typeparam name="TValue">The type of the property value.</typeparam>
public abstract class ConnectionStringProperty<TValue> : IPrintable
{
    protected string Name { get; init; }
    protected TValue Value { get; init; }

    protected ConnectionStringProperty(string name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public abstract Markup? GetMarkup();
}