namespace Galytix.Api.Model.Import;

public class GrossWrittenPremium
{
    public string Country { get; set; }
    public string LineOfBusiness { get; set; }
    public double? Y2008 { get; set; }
    public double? Y2009 { get; set; }
    public double? Y2010 { get; set; }
    public double? Y2011 { get; set; }
    public double? Y2012 { get; set; }
    public double? Y2013 { get; set; }
    public double? Y2014 { get; set; }
    public double? Y2015 { get; set; }

    public double GetAverage()
        => (Y2008.HasValue ? Y2008.Value / 8 : 0) +
           (Y2009.HasValue ? Y2009.Value / 8 : 0) +
           (Y2010.HasValue ? Y2010.Value / 8 : 0) +
           (Y2011.HasValue ? Y2011.Value / 8 : 0) +
           (Y2012.HasValue ? Y2012.Value / 8 : 0) +
           (Y2013.HasValue ? Y2013.Value / 8 : 0) +
           (Y2014.HasValue ? Y2014.Value / 8 : 0) +
           (Y2015.HasValue ? Y2015.Value / 8 : 0);
}