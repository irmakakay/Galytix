using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration;
using Galytix.Api.Model.Import;

namespace Galytix.Api.Services;

[ExcludeFromCodeCoverage]
public sealed class GrossWrittenPremiumMap : ClassMap<GrossWrittenPremium>
{
    public GrossWrittenPremiumMap()
    {
        Map(p => p.Country).Index(0); 
        Map(p => p.LineOfBusiness).Index(3);
        Map(p => p.Y2008).Index(12);
        Map(p => p.Y2009).Index(13);
        Map(p => p.Y2010).Index(14);
        Map(p => p.Y2011).Index(15);
        Map(p => p.Y2012).Index(16);
        Map(p => p.Y2013).Index(17);
        Map(p => p.Y2014).Index(18);
        Map(p => p.Y2015).Index(19);
    }
}