namespace TravelAggregator.Examples.Dtos;

public class AviaTalesDto
{
    public string Id { get; set; }
    public string ReferenceNumber { get; set; }
    public string Category { get; set; }
    public int AvailableSeats { get; set; }
    public float Cost { get; set; }
    public Location DepartureLocation { get; set; }
    public Location ArrivalLocation { get; set; }
    public string[]? AcceptedPaymentMethods { get; set; }
    public List<Flight> Flights { get; set; }
}

