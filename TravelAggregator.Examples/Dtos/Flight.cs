namespace TravelAggregator.Examples.Dtos;

public class Flight()
{
    public string Departure { get; set; }
    public string Destination { get; set; }
    public int TimeMin { get; set; }
    public int LayoverTimeMin { get; set; }
}