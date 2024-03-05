using TravelAggregator.Service.Constants;

namespace TravelAggregator.Service.Dtos;

public class TicketDto
{
    public string Identifier { get; set; }
    public string Number { get; set; }
    public string? Type { get; set; }
    public string Company { get; set; }
    public int AvailableCount { get; set; }
    public float Price { get; set; }
    public PointDto Departure { get; set; }
    public PointDto Destination { get; set; }
    public TransportType TransportType { get; set; }
    public string[]? PaymentMethods { get; set; }
    public List<TransitDto> Itinerary { get; set; }
}
