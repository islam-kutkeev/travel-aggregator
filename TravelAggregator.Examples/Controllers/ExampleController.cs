using Microsoft.AspNetCore.Mvc;
using TravelAggregator.Examples.Dtos;
using TravelAggregator.Examples.Repositories;

namespace TravelAggregator.Examples.Controllers;

[ApiController]
[Route("api/examples")]
public class ExampleController : ControllerBase
{
    private readonly AviaTalesRepository _aviaTalesRepository;
    private readonly MyAirlinesRepository _myAirlinesRepository;

    public ExampleController(AviaTalesRepository aviaTalesService, MyAirlinesRepository myAirlinesService)
    {
        _aviaTalesRepository = aviaTalesService;
        _myAirlinesRepository = myAirlinesService;
    }

    [HttpGet("avia-tales")]
    public List<AviaTalesDto> GetAviaTalesAll()
    {
        return _aviaTalesRepository.GetTickets();
    }

    [HttpGet("avia-tales/{ticketNum}")]
    public AviaTalesDto? GetAviaTales(string ticketNum)
    {
        return _aviaTalesRepository.GetTicketByNumber(ticketNum);
    }


    [HttpGet("my-airlines")]
    [Produces("application/xml")]
    public List<MyAirlinesDto> GetMyAirlinesAll()
    {
        return _myAirlinesRepository.GetTickets();
    }

    [HttpGet("my-airlines/{ticketNum}")]
    [Produces("application/xml")]
    public MyAirlinesDto? GetMyAirlines(string ticketNum)
    {
        return _myAirlinesRepository.GetTicketByNumber(ticketNum);
    }
}
