using AutoMapper;
using OrdNs = papaMiaBackend.Domain.Entities.Order;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderCreateDto, OrdNs.Order>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.Status, o => o.Ignore())
            .ForMember(d => d.Promocode, o => o.Ignore())
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        CreateMap<OrderCreateItemDto, OrdNs.OrderItem>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.OrderId, o => o.Ignore())
            .ForMember(d => d.Order, o => o.Ignore());

        CreateMap<OrdNs.Order, OrderDto>();
        CreateMap<OrdNs.OrderItem, OrderItemDto>();
    }
}
