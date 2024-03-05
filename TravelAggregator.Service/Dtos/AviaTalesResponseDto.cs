namespace TravelAggregator.Service.Dtos;

public class AviaTalesResponseDto
{
    public string Id { get; set; }
    public string ReferenceNumber { get; set; }
    public string Category { get; set; }
    public int AvailableSeats { get; set; }
    public float Cost { get; set; }
    public PointDto DepartureLocation { get; set; }
    public PointDto ArrivalLocation { get; set; }
    public string[]? AcceptedPaymentMethods { get; set; }
    public List<TransitDto> Flights { get; set; }
}
