using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class OneDayForecast
{
    public Headline Headline { get; set; }
    [JsonProperty("DailyForecasts")]
    public List<DailyForecasts> DailyForecasts { get; set; }

  
}
public class Headline
{
    public DateTime EffectiveDate { get; set; }
    public long EffectiveEpochDate { get; set; }
    public int Severity { get; set; }
    public string Text { get; set; }
    public string Category { get; set; }
    public DateTime EndDate { get; set; }
    public long EndEpochDate { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}

public class Minimum
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

public class Maximum
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

public class Temperature
{
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
}

public class Day
{
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
}

public class Night
{
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
}

public class DailyForecasts
{
    public DateTime Date { get; set; }
    public long EpochDate { get; set; }
    public Temperature Temperature { get; set; }
    public Day Day { get; set; }
    public Night Night { get; set; }
    public List<string> Sources { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}


