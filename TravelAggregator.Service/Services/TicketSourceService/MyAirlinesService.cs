using System.Xml.Serialization;
using AutoMapper;
using TravelAggregator.Service.Dtos;

namespace TravelAggregator.Service.Services.TicketSourceService;

public class MyAirlinesService : ITicketSourceService
{

    private readonly ILogger<MyAirlinesService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly HttpInteractionService _httpInteraction;

    public MyAirlinesService(ILogger<MyAirlinesService> logger, IConfiguration configuration, IMapper mapper, HttpInteractionService httpInteraction)
    {
        _logger = logger;
        _configuration = configuration;
        _mapper = mapper;
        _httpInteraction = httpInteraction;

        ServiceTitle = _configuration["MyAirLines:Title"]!;
    }

    public string ServiceTitle { get; }



    public async Task<List<TicketDto>> ObtainTicketsAsync()
    {
        _logger.LogInformation("Starting request to {} obtain all service", ServiceTitle);

        string responseContent = await _httpInteraction
            .SendRequest(_configuration["MyAirLines:ObtainAll:Uri"], HttpMethod.Get, ServiceTitle);
        var serviceResult = new MyAirlinesResponseDto();

        using (StringReader reader = new StringReader(responseContent))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyAirlinesResponseDto));
            serviceResult = (MyAirlinesResponseDto)serializer.Deserialize(reader);
        }

        if (serviceResult == null)
        {
            _logger.LogWarning("{} response content was empty", ServiceTitle);
            return new List<TicketDto>();
        }

        var result = _mapper.Map<List<TicketDto>>(serviceResult.Data);
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

        string serviceUri = string.Format(_configuration["MyAirLines:ObtainOne:Uri"], ticketNumber);

        string responseContent = await _httpInteraction
            .SendRequest(serviceUri, HttpMethod.Get, ServiceTitle);
        var serviceResult = new MyAirlinesResponseDto.MyAirlineResponseData();

        using (StringReader reader = new StringReader(responseContent))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyAirlinesResponseDto.MyAirlineResponseData));
            serviceResult = (MyAirlinesResponseDto.MyAirlineResponseData)serializer.Deserialize(reader);
        }

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
