using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Exceptions;

[ExcludeFromCodeCoverage]
public class DataContextException : Exception
{
    public DataContextException(Exception inner) : base("Error while initializing data context.", inner)
    {
    }
}