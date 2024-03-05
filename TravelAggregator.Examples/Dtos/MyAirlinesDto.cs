using System.Xml.Serialization;

namespace TravelAggregator.Examples.Dtos;

[XmlRoot("MyAirlinesDto")]
public class MyAirlinesDto
{
    public string Id { get; set; }
    public string SerialNumber { get; set; }
    public string TicketCategory { get; set; }
    public int SeatsAvailable { get; set; }
    public float TicketPrice { get; set; }
    public Location StartLocation { get; set; }
    public Location EndLocation { get; set; }
    public string[]? AcceptedPayments { get; set; }
    public List<Flight> TripSegments { get; set; }
}
