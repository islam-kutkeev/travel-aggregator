using AutoMapper;
using TravelAggregator.Service.Dtos;
using TravelAggregator.Service.Entities;

namespace TravelAggregator.Service.Configurations;

public class TicketSourceProfile : Profile
{
    public TicketSourceProfile()
    {
        CreateMap<AviaTalesResponseDto, TicketDto>()
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.ReferenceNumber))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(src => src.AvailableSeats))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Cost))
            .ForMember(dest => dest.Departure, opt => opt.MapFrom(src => src.DepartureLocation))
            .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.ArrivalLocation))
            .ForMember(dest => dest.PaymentMethods, opt => opt.MapFrom(src => src.AcceptedPaymentMethods))
            .ForMember(dest => dest.Itinerary, opt => opt.MapFrom(src => src.Flights))
            .ReverseMap();

        CreateMap<MyAirlinesResponseDto.MyAirlineResponseData, TicketDto>()
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.SerialNumber))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TicketCategory))
            .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(src => src.SeatsAvailable))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketPrice))
            .ForMember(dest => dest.Departure, opt => opt.MapFrom(src => src.StartLocation))
            .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.EndLocation))
            .ForMember(dest => dest.PaymentMethods, opt => opt.MapFrom(src => src.AcceptedPayments))
            .ForMember(dest => dest.Itinerary, opt => opt.MapFrom(src => src.TripSegments.Flights))
            .ReverseMap();

        CreateMap<ReservationDto, Reservation>()
            .ReverseMap();
    }
}
