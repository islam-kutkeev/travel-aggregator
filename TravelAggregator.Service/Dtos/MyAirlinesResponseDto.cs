using System.Xml.Serialization;

namespace TravelAggregator.Service.Dtos;


[XmlRoot("ArrayOfMyAirlinesDto")]
public class MyAirlinesResponseDto
{
    [XmlElement("MyAirlinesDto")]
    public List<MyAirlineResponseData> Data { get; set; }

    [XmlRoot("MyAirlinesDto")]
    public class MyAirlineResponseData
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        public string TicketCategory { get; set; }
        public int SeatsAvailable { get; set; }
        public float TicketPrice { get; set; }
        public PointDto StartLocation { get; set; }
        public PointDto EndLocation { get; set; }

        [XmlArray("AcceptedPayments")]
        [XmlArrayItem("string")]
        public string[]? AcceptedPayments { get; set; }

        [XmlElement("TripSegments")]
        public TripSegments TripSegments { get; set; }
    }

    public class TripSegments
    {
        [XmlElement("Flight")]
        public List<TransitDto> Flights { get; set; }
    }
}
