using TravelAggregator.Service.Dtos;

namespace TravelAggregator.Service.Services.TicketSourceService;

public interface ITicketSourceService
{
    string ServiceTitle { get; }

    /// <summary>
    /// Obtains all available tickets from travel service
    /// (for this scenario, let's assume that the endpoint services do not have filtering capabilities. Therefore, they return everything)
    /// </summary>
    /// <returns> List of <see cref="TicketDto"/></returns>
    Task<List<TicketDto>> ObtainTicketsAsync();

    /// <summary>
    /// Obtains one ticket by number
    /// </summary>
    /// <param name="ticketNumber">Serial number of ticket </param>
    /// <returns><see cref="TicketDto"/></returns>
    Task<TicketDto> ObtainTicketAsync(string ticketNumber);

    /// <summary>
    /// !!! NOT IMPLEMENTED !!!
    /// Reserves ticket
    /// </summary>
    /// <param name="ticketNumber">Serial number of ticket</param>
    Task ReserveTicketAsync(string ticketNumber);

    /// <summary>
    /// !!! NOT IMPLEMENTED !!!
    /// Pays for reservation
    /// </summary>
    /// <param name="ticketNumber">Serial number of ticket</param>
    Task PayReservationTicketAsync(string ticketNumber);

    /// <summary>
    /// !!! NOT IMPLEMENTED !!!
    /// Removes reservation
    /// </summary>
    /// <param name="ticketNumber">Serial number of ticket</param>
    Task RemoveReservationTicketAsync(string ticketNumber);
}
