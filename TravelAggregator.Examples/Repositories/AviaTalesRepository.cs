using TravelAggregator.Examples.Dtos;

namespace TravelAggregator.Examples.Repositories;

public class AviaTalesRepository
{
    public List<AviaTalesDto> GetTickets()
    {
        return new List<AviaTalesDto>
        {
            new AviaTalesDto
            {
                Id = "1",
                ReferenceNumber = "REF123",
                Category = "Adventure",
                AvailableSeats = 20,
                Cost = 500.25f,
                DepartureLocation = new Location { Place = "CityA", DateTime = DateTimeOffset.Now },
                ArrivalLocation = new Location { Place = "CityB", DateTime = DateTimeOffset.Now.AddHours(2) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityA", Destination = "CityB", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityB", Destination = "CityC", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "2",
                ReferenceNumber = "REF456",
                Category = "Mystery",
                AvailableSeats = 15,
                Cost = 700.75f,
                DepartureLocation = new Location { Place = "CityC", DateTime = DateTimeOffset.Now.AddHours(3) },
                ArrivalLocation = new Location { Place = "CityD", DateTime = DateTimeOffset.Now.AddHours(5) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "Bitcoin" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityC", Destination = "CityD", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityD", Destination = "CityE", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "3",
                ReferenceNumber = "REF789",
                Category = "Romance",
                AvailableSeats = 25,
                Cost = 900.50f,
                DepartureLocation = new Location { Place = "CityE", DateTime = DateTimeOffset.Now.AddHours(6) },
                ArrivalLocation = new Location { Place = "CityF", DateTime = DateTimeOffset.Now.AddHours(8) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityE", Destination = "CityF", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityF", Destination = "CityG", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "4",
                ReferenceNumber = "REF012",
                Category = "Action",
                AvailableSeats = 30,
                Cost = 600.75f,
                DepartureLocation = new Location { Place = "CityG", DateTime = DateTimeOffset.Now.AddHours(9) },
                ArrivalLocation = new Location { Place = "CityH", DateTime = DateTimeOffset.Now.AddHours(11) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "Bitcoin", "PayPal" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityG", Destination = "CityH", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityH", Destination = "CityI", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "5",
                ReferenceNumber = "REF345",
                Category = "Comedy",
                AvailableSeats = 18,
                Cost = 400.50f,
                DepartureLocation = new Location { Place = "CityI", DateTime = DateTimeOffset.Now.AddHours(12) },
                ArrivalLocation = new Location { Place = "CityJ", DateTime = DateTimeOffset.Now.AddHours(14) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityI", Destination = "CityJ", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityJ", Destination = "CityK", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "6",
                ReferenceNumber = "REF678",
                Category = "Fantasy",
                AvailableSeats = 22,
                Cost = 800.00f,
                DepartureLocation = new Location { Place = "CityK", DateTime = DateTimeOffset.Now.AddHours(15) },
                ArrivalLocation = new Location { Place = "CityL", DateTime = DateTimeOffset.Now.AddHours(17) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "Bitcoin", "PayPal" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityK", Destination = "CityL", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityL", Destination = "CityM", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "7",
                ReferenceNumber = "REF901",
                Category = "Drama",
                AvailableSeats = 17,
                Cost = 450.25f,
                DepartureLocation = new Location { Place = "CityM", DateTime = DateTimeOffset.Now.AddHours(18) },
                ArrivalLocation = new Location { Place = "CityN", DateTime = DateTimeOffset.Now.AddHours(20) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityM", Destination = "CityN", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityN", Destination = "CityO", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "8",
                ReferenceNumber = "REF234",
                Category = "Sci-Fi",
                AvailableSeats = 28,
                Cost = 950.75f,
                DepartureLocation = new Location { Place = "CityO", DateTime = DateTimeOffset.Now.AddHours(21) },
                ArrivalLocation = new Location { Place = "CityP", DateTime = DateTimeOffset.Now.AddHours(23) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bitcoin" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityO", Destination = "CityP", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityP", Destination = "CityQ", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "9",
                ReferenceNumber = "REF567",
                Category = "Horror",
                AvailableSeats = 14,
                Cost = 300.50f,
                DepartureLocation = new Location { Place = "CityQ", DateTime = DateTimeOffset.Now.AddHours(24) },
                ArrivalLocation = new Location { Place = "CityR", DateTime = DateTimeOffset.Now.AddHours(26) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bank Transfer" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityQ", Destination = "CityR", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityR", Destination = "CityS", TimeMin = 180, LayoverTimeMin = 45 }
                }
            },
            new AviaTalesDto
            {
                Id = "10",
                ReferenceNumber = "REF890",
                Category = "Thriller",
                AvailableSeats = 21,
                Cost = 850.25f,
                DepartureLocation = new Location { Place = "CityS", DateTime = DateTimeOffset.Now.AddHours(27) },
                ArrivalLocation = new Location { Place = "CityT", DateTime = DateTimeOffset.Now.AddHours(29) },
                AcceptedPaymentMethods = new string[] { "Credit Card", "PayPal", "Bitcoin" },
                Flights = new List<Flight>
                {
                    new Flight { Departure = "CityS", Destination = "CityT", TimeMin = 120, LayoverTimeMin = 30 },
                    new Flight { Departure = "CityT", Destination = "CityU", TimeMin = 180, LayoverTimeMin = 45 }
                }
            }
        };

    }

    public AviaTalesDto? GetTicketByNumber(string number)
    {
        var data = GetTickets();
        return data.FirstOrDefault(x => x.ReferenceNumber.Equals(number));
    }
}
