using AutoMapper;
using Newtonsoft.Json;
using TravelAggregator.Service.Dtos;

namespace TravelAggregator.Service.Services.TicketSourceService;

public class AviaTalesService : ITicketSourceService
{
    private readonly ILogger<AviaTalesService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly HttpInteractionService _httpInteraction;


    public AviaTalesService(ILogger<AviaTalesService> logger, IConfiguration configuration, IMapper mapper, HttpInteractionService httpInteraction)
    {
        _logger = logger;
        _configuration = configuration;
        _mapper = mapper;
        _httpInteraction = httpInteraction;

        ServiceTitle = _configuration["AviaTales:Title"]!;
    }

    public string ServiceTitle { get; }

    public async Task<List<TicketDto>> ObtainTicketsAsync()
    {
        _logger.LogInformation("Starting request to {} obtain all service", ServiceTitle);

        string responseContent = await _httpInteraction
            .SendRequest(_configuration["AviaTales:ObtainAll:Uri"], HttpMethod.Get, ServiceTitle);

        var serviceResult = JsonConvert.DeserializeObject<List<AviaTalesResponseDto>>(responseContent);
        if (serviceResult == null)
        {
            _logger.LogWarning("{} response content was empty", ServiceTitle);
            return new List<TicketDto>();
        }

        var result = _mapper.Map<List<TicketDto>>(serviceResult);
        result.ForEach(x =>
        {
            x.Company = ServiceTitle;
            x.TransportType = Constants.TransportType.Plane;
        });

        return result;
    }

    public async Task<TicketDto> ObtainTicketAsync(string ticketNumber)
    {
        _logger.LogInformation("Starting request to {} obtain one service", ServiceTitle);

        string serviceUri = string.Format(_configuration["AviaTales:ObtainOne:Uri"], ticketNumber);

        string responseContent = await _httpInteraction
            .SendRequest(serviceUri, HttpMethod.Get, ServiceTitle);

        var serviceResult = JsonConvert.DeserializeObject<AviaTalesResponseDto>(responseContent);
        if (serviceResult == null)
        {
            _logger.LogWarning("{} response content was empty", ServiceTitle);
            return new TicketDto();
        }

        var result = _mapper.Map<TicketDto>(serviceResult);
        result.Company = ServiceTitle;
        result.TransportType = Constants.TransportType.Plane;

        return result;
    }

    public async Task ReserveTicketAsync(string ticketNumber)
    {
        return;
    }

    public async Task PayReservationTicketAsync(string ticketNumber)
    {
        return;
    }

    public async Task RemoveReservationTicketAsync(string ticketNumber)
    {
        return;
    }
}
