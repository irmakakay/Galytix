using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Galytix.Api.Configuration;
using Galytix.Api.DataAccess;
using Galytix.Api.Exceptions;
using Galytix.Api.Model.Import;
using Microsoft.Extensions.Logging.Abstractions;

namespace Galytix.Api.Services;

[ExcludeFromCodeCoverage]
public static class DataImporter
{
    public static IGwpDataContext Import(ImportSettings configuration)
    {
        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };
            
            using var reader = new StreamReader(configuration.Source);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<GrossWrittenPremiumMap>();
            var records = csv.GetRecords<GrossWrittenPremium>();

            var context = new GwpDataContext(NullLogger<GwpDataContext>.Instance);
            context.Initialize(records);

            return context;
        }
        catch (Exception e)
        {
            Trace.TraceError($"Error in data import: {e}");
            throw new DataImportException(e);
        }
    }
}