using System.ComponentModel.DataAnnotations.Schema;
using TravelAggregator.Service.Constants;

namespace TravelAggregator.Service.Entities;

[Table("reservation")]
public class Reservation
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("user_identifier")]
    public string UserIdentifier { get; set; }

    [Column("ticket_number")]
    public string TicketNumber { get; set; }

    [Column("company")]
    public string Company { get; set; }

    [Column("status")]
    public ReservationStatus Status { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}
