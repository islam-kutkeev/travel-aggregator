using TravelAggregator.Service.Dtos;

namespace TravelAggregator.Service.Repositories.ReservationRepository;

public interface IReservationRepository
{
    /// <summary>
    /// Obtain all user's reservation from database
    /// </summary>
    /// <param name="userId">user identifier</param>
    /// <returns>List of <see cref="ReservationDto"/></returns>
    Task<List<ReservationDto>> GetUserReservationsAsync(string userId);

    /// <summary>
    /// Pays for the reservation
    /// </summary>
    /// <param name="id">reservation identifier</param>
    /// <returns>Ticket number</returns>
    Task<string> PayReservationAsync(string id);

    /// <summary>
    /// Reserves ticket
    /// </summary>
    /// <param name="ticket">ticket information</param>
    /// <param name="userId">user identifier</param>
    /// <returns>Reservation information</returns>
    Task<ReservationDto> ReserveTicketAsync(TicketDto ticket, string userId);

    /// <summary>
    /// Removes user's reservation from database
    /// </summary>
    /// <param name="id">reservation identifier </param>
    /// <returns>Ticket number</returns>
    Task<string> DeleteReservationTicketAsync(string id);
}