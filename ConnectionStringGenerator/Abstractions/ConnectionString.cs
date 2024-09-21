using System.Reflection;

namespace ConnectionStringGenerator.Abstractions;

public abstract class ConnectionString
{
    /// <summary>
    /// Retrieves a list of properties from the connection string that implement the IPrintable interface.
    /// This method uses reflection to inspect the properties of the current instance and includes only those
    /// that can be cast to IPrintable.
    /// </summary>
    /// <returns>A list of properties implementing the IPrintable interface.</returns>
    protected virtual List<IPrintable> GetPrintableProperties()
    {
        var printableProps = new List<IPrintable>();
        PropertyInfo[] properties = this.GetType().GetProperties();

        foreach (PropertyInfo VARIABLE in properties)
        {
            if (VARIABLE.GetValue(this) is IPrintable printable)
            {
                printableProps.Add(printable);
            }
        }

        return printableProps;
    }
}