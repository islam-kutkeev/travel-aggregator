using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAggregator.Service.Dtos;
using TravelAggregator.Service.Services;

namespace TravelAggregator.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TravelController : ControllerBase
{
    private readonly AggregatorService _aggregatorService;

    public TravelController(AggregatorService aggregatorService)
    {
        _aggregatorService = aggregatorService;
    }

    [HttpPost("obtain")]
    public async Task<ResponseDto<List<TicketDto>>> Search([FromBody] SearchRequestDto request)
    {
        return await _aggregatorService.SearchTicketAsync(request);
    }

    [HttpGet("obtain")]
    public async Task<ResponseDto<List<TicketDto>>> GetAll()
    {
        return await _aggregatorService.ObtainAllAsync();
    }

    [HttpGet("obtain/by-ticket-num")]
    public async Task<ResponseDto<TicketDto?>> GetByTicketNum([FromQuery] string ticketNum, [FromQuery] string company)
    {
        return await _aggregatorService.ObtainByTicketNumAsync(ticketNum, company);
    }

    [HttpGet("reserve/{userId}")]
    [Authorize]
    public async Task<ResponseDto<List<ReservationDto>>> GetUserReservations(string userId)
    {
        return await _aggregatorService.GetUserReservationsAsync(userId);
    }

    [HttpPost("reserve")]
    [Authorize]
    public async Task<ResponseDto<string>> Reserve(ReservationDto request)
    {
        return await _aggregatorService
            .CreateReservationAsync(request.TicketNumber, request.UserIdentifier, request.Company);
    }

    [HttpPut("reserve")]
    [Authorize]
    public async Task<ResponseDto> PayReservation(ReservationDto request)
    {
        return await _aggregatorService.PayReservationAsync(request.Id, request.Company);
    }

    [HttpDelete("reserve")]
    [Authorize]
    public async Task<ResponseDto> DeleteReservation(ReservationDto request)
    {
        return await _aggregatorService.DeleteReservationTicketAsync(request.Id, request.Company);
    }
}
