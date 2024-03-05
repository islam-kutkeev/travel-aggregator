using TravelAggregator.Service.Constants;

namespace TravelAggregator.Service.Dtos;

public class ReservationDto
{
    public string? Id { get; set; }
    public string? UserIdentifier { get; set; }
    public string? TicketNumber { get; set; }
    public string? Company { get; set; }
    public ReservationStatus? Status { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
}
