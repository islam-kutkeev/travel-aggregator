using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelAggregator.Service.Dtos;
using TravelAggregator.Service.Entities;

namespace TravelAggregator.Service.Repositories.ReservationRepository;

public class ReservationRepository : IReservationRepository
{
    private readonly ILogger<ReservationRepository> _logger;
    private readonly DatabaseContext _dbContext;
    private readonly IMapper _mapper;

    public ReservationRepository(ILogger<ReservationRepository> logger, DatabaseContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ReservationDto>> GetUserReservationsAsync(string userId)
    {
        var reservations = await _dbContext.Reservations
            .Where(x => x.UserIdentifier.Equals(userId) && x.Status != Constants.ReservationStatus.Deleted)
            .ToListAsync();

        return _mapper.Map<List<ReservationDto>>(reservations);
    }

    public async Task<string> PayReservationAsync(string id)
    {
        var reservation = await _dbContext.Reservations
            .FirstOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.Status != Constants.ReservationStatus.Deleted);

        if (reservation != null)
        {
            reservation.Status = Constants.ReservationStatus.Paid;
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Reservation with id: {} successfully paid", id);
            return reservation.TicketNumber;
        }

        throw new InvalidDataException($"Reservation with id: ${id} not found");
    }

    public async Task<ReservationDto> ReserveTicketAsync(TicketDto ticket, string userId)
    {
        var existingReservation = await _dbContext.Reservations
            .FirstOrDefaultAsync(x => x.TicketNumber.Equals(ticket.Number) && x.Status != Constants.ReservationStatus.Deleted);

        if (existingReservation == null)
        {
            var reservation = new Reservation()
            {
                UserIdentifier = userId,
                TicketNumber = ticket.Number,
                Company = ticket.Company,
                Status = Constants.ReservationStatus.Reserved
            };

            await _dbContext.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Reservation with for ticket: {} successfully created", ticket.Number);
            return _mapper.Map<ReservationDto>(reservation);
        }

        throw new InvalidDataException($"Reservation with for ticket: ${ticket.Number} already exists");
    }

    public async Task<string> DeleteReservationTicketAsync(string id)
    {
        var reservation = await _dbContext.Reservations
            .FirstOrDefaultAsync(x =>
                x.Id.ToString().Equals(id) &&
                x.Status != Constants.ReservationStatus.Paid);

        if (reservation != null)
        {
            reservation.Status = Constants.ReservationStatus.Deleted;
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Reservation with id: {} successfully removed", id);
            return reservation.TicketNumber;
        }

        throw new InvalidDataException($"Reservation with id: {id} not found");
    }
}
