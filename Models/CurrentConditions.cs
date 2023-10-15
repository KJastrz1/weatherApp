public class CurrentConditions
{
    public string LocalObservationDateTime { get; set; }
    public long EpochTime { get; set; }
    public string WeatherText { get; set; }
    public int WeatherIcon { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public bool IsDayTime { get; set; }
    public TemperatureCC Temperature { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}
public class TemperatureCC
{
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
}

public class Metric
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

public class Imperial
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}


