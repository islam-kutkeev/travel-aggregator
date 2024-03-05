using TravelAggregator.Examples.Dtos;

namespace TravelAggregator.Examples.Repositories;

public class MyAirlinesRepository
{
    public List<MyAirlinesDto> GetTickets()
    {
        return new List<MyAirlinesDto>
        {
            new MyAirlinesDto
            {
                Id = "1",
                SerialNumber = "SN123",
                TicketCategory = "Economy",
                SeatsAvailable = 150,
                TicketPrice = 300.50f,
                StartLocation = new Location { Place = "CityX", DateTime = DateTimeOffset.Now },
                EndLocation = new Location { Place = "CityY", DateTime = DateTimeOffset.Now.AddHours(2) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityX", Destination = "CityY", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityY", Destination = "CityZ", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "2",
                SerialNumber = "SN456",
                TicketCategory = "Business",
                SeatsAvailable = 50,
                TicketPrice = 800.75f,
                StartLocation = new Location { Place = "CityA", DateTime = DateTimeOffset.Now.AddHours(3) },
                EndLocation = new Location { Place = "CityB", DateTime = DateTimeOffset.Now.AddHours(5) },
                AcceptedPayments = new string[] { "Credit Card", "Bitcoin" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityA", Destination = "CityB", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityB", Destination = "CityC", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "3",
                SerialNumber = "SN789",
                TicketCategory = "First Class",
                SeatsAvailable = 20,
                TicketPrice = 1200.50f,
                StartLocation = new Location { Place = "CityD", DateTime = DateTimeOffset.Now.AddHours(6) },
                EndLocation = new Location { Place = "CityE", DateTime = DateTimeOffset.Now.AddHours(8) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityD", Destination = "CityE", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityE", Destination = "CityF", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "4",
                SerialNumber = "SN012",
                TicketCategory = "Economy",
                SeatsAvailable = 100,
                TicketPrice = 250.75f,
                StartLocation = new Location { Place = "CityG", DateTime = DateTimeOffset.Now.AddHours(9) },
                EndLocation = new Location { Place = "CityH", DateTime = DateTimeOffset.Now.AddHours(11) },
                AcceptedPayments = new string[] { "Credit Card", "Bitcoin", "PayPal" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityG", Destination = "CityH", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityH", Destination = "CityI", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "5",
                SerialNumber = "SN345",
                TicketCategory = "Business",
                SeatsAvailable = 30,
                TicketPrice = 600.50f,
                StartLocation = new Location { Place = "CityJ", DateTime = DateTimeOffset.Now.AddHours(12) },
                EndLocation = new Location { Place = "CityK", DateTime = DateTimeOffset.Now.AddHours(14) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityJ", Destination = "CityK", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityK", Destination = "CityL", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "6",
                SerialNumber = "SN678",
                TicketCategory = "First Class",
                SeatsAvailable = 15,
                TicketPrice = 1100.00f,
                StartLocation = new Location { Place = "CityM", DateTime = DateTimeOffset.Now.AddHours(15) },
                EndLocation = new Location { Place = "CityN", DateTime = DateTimeOffset.Now.AddHours(17) },
                AcceptedPayments = new string[] { "Credit Card", "Bitcoin", "PayPal" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityM", Destination = "CityN", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityN", Destination = "CityO", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "7",
                SerialNumber = "SN901",
                TicketCategory = "Economy",
                SeatsAvailable = 80,
                TicketPrice = 350.25f,
                StartLocation = new Location { Place = "CityP", DateTime = DateTimeOffset.Now.AddHours(18) },
                EndLocation = new Location { Place = "CityQ", DateTime = DateTimeOffset.Now.AddHours(20) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityP", Destination = "CityQ", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityQ", Destination = "CityR", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "8",
                SerialNumber = "SN234",
                TicketCategory = "Business",
                SeatsAvailable = 40,
                TicketPrice = 900.75f,
                StartLocation = new Location { Place = "CityS", DateTime = DateTimeOffset.Now.AddHours(21) },
                EndLocation = new Location { Place = "CityT", DateTime = DateTimeOffset.Now.AddHours(23) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bitcoin" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityS", Destination = "CityT", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityT", Destination = "CityU", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "9",
                SerialNumber = "SN567",
                TicketCategory = "First Class",
                SeatsAvailable = 25,
                TicketPrice = 1000.50f,
                StartLocation = new Location { Place = "CityV", DateTime = DateTimeOffset.Now.AddHours(24) },
                EndLocation = new Location { Place = "CityW", DateTime = DateTimeOffset.Now.AddHours(26) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityV", Destination = "CityW", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityW", Destination = "CityX", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new MyAirlinesDto
            {
                Id = "10",
                SerialNumber = "SN890",
                TicketCategory = "Economy",
                SeatsAvailable = 120,
                TicketPrice = 400.25f,
                StartLocation = new Location { Place = "CityY", DateTime = DateTimeOffset.Now.AddHours(27) },
                EndLocation = new Location { Place = "CityZ", DateTime = DateTimeOffset.Now.AddHours(29) },
                AcceptedPayments = new string[] { "Credit Card", "PayPal", "Bitcoin" },
                TripSegments = new List<Flight>
                {
                    new Flight { Departure = "CityY", Destination = "CityZ", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityZ", Destination = "CityA", TimeMin = 180, LayoverTimeMin = 45 }
                }
            }
        };
    }

    public MyAirlinesDto? GetTicketByNumber(string number)
    {
        var data = GetTickets();
        return data.FirstOrDefault(x => x.SerialNumber.Equals(number));
    }
}
