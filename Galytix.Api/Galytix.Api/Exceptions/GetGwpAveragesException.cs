using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Exceptions;

[ExcludeFromCodeCoverage]
public class GetGwpAveragesException : Exception
{
    public GetGwpAveragesException(Exception inner) : base("Error while getting the Gwp averages.")
    {
    }
}