using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Exceptions;

[ExcludeFromCodeCoverage]
public class DataImportException : Exception
{
    public DataImportException(Exception inner) : base("Error while importing data", inner)
    {
    }
}