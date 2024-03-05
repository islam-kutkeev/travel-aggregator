using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using TravelAggregator.Service.Dtos;
using TravelAggregator.Service.Repositories.ReservationRepository;
using TravelAggregator.Service.Services.TicketSourceService;

namespace TravelAggregator.Service.Services;

public class AggregatorService
{
    private readonly ILogger<AggregatorService> _logger;
    private readonly IEnumerable<ITicketSourceService> _ticketSourceServices;
    private readonly IReservationRepository _reservationRepository;
    private readonly CacheService _cacheService;

    public AggregatorService(ILogger<AggregatorService> logger, IEnumerable<ITicketSourceService> ticketSourceServices, IReservationRepository reservationRepository, CacheService cacheService)
    {
        _logger = logger;
        _ticketSourceServices = ticketSourceServices;
        _reservationRepository = reservationRepository;
        _cacheService = cacheService;
    }

    /// <summary>
    /// Finds tickets from all sources with specified conditions
    /// </summary>
    /// <param name="searchRequest">conditions</param>
    /// <returns>List of <see cref="ResponseDto"/> tickets that fits conditions</returns>
    public async Task<ResponseDto<List<TicketDto>>> SearchTicketAsync(SearchRequestDto searchRequest)
    {
        var result = new ResponseDto<List<TicketDto>>();
        try
        {
            var tickets = await ObtainAllAsync();

            var filteredTickets = tickets.Data
            .Where(ticket =>
                (!searchRequest.FromDate.HasValue || ticket.Departure.DateTime >= searchRequest.FromDate.Value) &&
                (!searchRequest.ToDate.HasValue || ticket.Departure.DateTime <= searchRequest.ToDate.Value) &&
                (!searchRequest.MinPrice.HasValue || ticket.Price >= searchRequest.MinPrice.Value) &&
                (!searchRequest.MaxPrice.HasValue || ticket.Price <= searchRequest.MaxPrice.Value) &&
                (!searchRequest.MinLayovers.HasValue || ticket.Itinerary.Count >= searchRequest.MinLayovers.Value) &&
                (!searchRequest.MaxLayovers.HasValue || ticket.Itinerary.Count <= searchRequest.MaxLayovers.Value) &&
                (string.IsNullOrEmpty(searchRequest.Company) || ticket.Company.Equals(searchRequest.Company, StringComparison.OrdinalIgnoreCase))
            )
            .ToList();

            if (!string.IsNullOrEmpty(searchRequest.SortBy))
            {
                switch (searchRequest.SortBy.ToLower())
                {
                    case "price":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.Price).ToList();
                        break;
                    case "company":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.Company).ToList();
                        break;
                    case "type":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.Type).ToList();
                        break;
                    case "seats":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.AvailableCount).ToList();
                        break;
                    case "departure":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.Departure.Place).ToList();
                        break;
                    case "arrival":
                        filteredTickets = filteredTickets.OrderBy(ticket => ticket.Destination.Place).ToList();
                        break;
                    default:
                        break;
                }
            }

            result.Data = filteredTickets;
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while trying to find tickets with conditions {@Conditions}", searchRequest);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }

    /// <summary>
    /// Obtains all tickets from all sources
    /// </summary>
    /// <returns>List of <see cref="ResponseDto"/> with all tickets</returns>
    public async Task<ResponseDto<List<TicketDto>>> ObtainAllAsync()
    {
        var result = new ResponseDto<List<TicketDto>>();
        try
        {
            var cacheTickets = await _cacheService.GetFromCacheAsync<List<TicketDto>>("all-tickets");
            if (cacheTickets != null)
            {
                result.Data = cacheTickets;
                return result;
            }

            var services = new List<Func<Task<List<TicketDto>>>>();
            foreach (var ticketService in _ticketSourceServices)
            {
                services.Add(() => ticketService.ObtainTicketsAsync());
            }

            if (services == null)
            {
                throw new NullReferenceException("Not found required services");
            }

            result.Data = (await Task.WhenAll(services.Select(x => x())))
                .SelectMany(result => result)
                .ToList();

            await _cacheService.SetToCacheAsync<List<TicketDto>>("all-tickets", result.Data, TimeSpan.FromMinutes(1));
            _logger.LogInformation("All tickets was obtained successfully");
        }
        catch (Exception ex)
        {
            string message = "Error occurred while obtaining all tickets";
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }

    /// <summary>
    /// Obtains ticket from specified source by ticket number
    /// </summary>
    /// <param name="ticketNum">ticket number</param>
    /// <param name="company">specified source</param>
    /// <returns><see cref="ResponseDto"/> with ticket information from specified source</returns>
    public async Task<ResponseDto<TicketDto?>> ObtainByTicketNumAsync(string ticketNum, string company)
    {
        var result = new ResponseDto<TicketDto>();
        try
        {
            var cacheTicket = await _cacheService.GetFromCacheAsync<TicketDto>(ticketNum);
            if (cacheTicket != null)
            {
                result.Data = cacheTicket;
                return result;
            }

            var service = GetServiceByCompany(company);
            result.Data = await service.ObtainTicketAsync(ticketNum);

            await _cacheService.SetToCacheAsync<TicketDto>(ticketNum, result.Data, TimeSpan.FromMinutes(3));
            _logger.LogInformation("Ticket {} was obtained successfully", ticketNum);
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while obtaining ticket by ticket number {0} and company {1}", ticketNum, company);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }


    /// <summary>
    /// Obtains all user's reservations
    /// </summary>
    /// <param name="userId">user identifier</param>
    /// <returns><see cref="ResponseDto"/> with list of all user's reservations</returns>
    public async Task<ResponseDto<List<ReservationDto>>> GetUserReservationsAsync(string userId)
    {
        var result = new ResponseDto<List<ReservationDto>>();
        try
        {
            result.Data = await _reservationRepository.GetUserReservationsAsync(userId);
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while obtaining all user's reservations by {}", userId);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }

    /// <summary>
    /// Creates new reservation for specified user at specified source
    /// </summary>
    /// <param name="ticketNum">ticket number</param>
    /// <param name="userId">user identifier</param>
    /// <param name="company">specified source</param>
    /// <returns><see cref="ResponseDto"/></returns>
    public async Task<ResponseDto<string>> CreateReservationAsync(string ticketNum, string userId, string company)
    {
        var result = new ResponseDto<string>();
        try
        {
            var ticket = await ObtainByTicketNumAsync(ticketNum, company);
            if (ticket.Data.AvailableCount > 0)
            {
                var reservation = await _reservationRepository.ReserveTicketAsync(ticket.Data, userId);
                var service = GetServiceByCompany(company);
                await service.ReserveTicketAsync(reservation.TicketNumber);
                result.Data = reservation.Id;
            }

            _logger.LogWarning("No available seats for ticket {}", ticketNum);
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while creating reservation by ticket number {0} and company {1} for user {2}", ticketNum, company, userId);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }


    /// <summary>
    /// Pay existing reservation at specified source
    /// </summary>
    /// <param name="id">reservation identifier</param>
    /// <param name="company">specified source</param>
    /// <returns><see cref="ResponseDto"/></returns>
    public async Task<ResponseDto> PayReservationAsync(string id, string company)
    {
        var result = new ResponseDto();
        try
        {
            string ticketNumber = await _reservationRepository.PayReservationAsync(id);

            // Fast solution
            // Better create a worker that will check all reservation with specified status
            // and process them in third party service
            var service = GetServiceByCompany(company);
            await service.PayReservationTicketAsync(ticketNumber);
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while trying to pay reservation by id {0} and company {1}", id, company);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }

    /// <summary>
    /// Removes reservation at specified source
    /// </summary>
    /// <param name="id">reservation identifier</param>
    /// <param name="company">specified source</param>
    /// <returns><see cref="ResponseDto"/></returns>
    public async Task<ResponseDto> DeleteReservationTicketAsync(string id, string company)
    {
        var result = new ResponseDto();
        try
        {
            string ticketNumber = await _reservationRepository.DeleteReservationTicketAsync(id);

            // Fast solution
            // Better create a worker that will check all reservation with specified status
            // and process them in third party service
            var service = GetServiceByCompany(company);
            await service.PayReservationTicketAsync(ticketNumber);
        }
        catch (Exception ex)
        {
            string message = string.Format("Error occurred while trying to remove reservation by id {0} and company {1}", id, company);
            result.Code = 1;
            result.Message = message;
            _logger.LogError(ex, message);
        }

        return result;
    }

    /// <summary>
    /// Obtains implementation of <see cref="ITicketSourceService"/> from container pool
    /// </summary>
    /// <param name="company">implementation</param>
    /// <param name="caller">method invokes the operation</param>
    /// <returns>Implementation of <see cref="ITicketSourceService"/></returns>
    private ITicketSourceService GetServiceByCompany(string company, [CallerMemberName] string caller = null)
    {
        var service = _ticketSourceServices.FirstOrDefault(x => x.ServiceTitle.Equals(company));

        if (service == null)
        {
            _logger.LogWarning("Not found required service for invoke at {}", caller);
            throw new NullReferenceException("Not found required service");
        }

        return service;
    }
}
