using AutoMapper;
using papaMiaBackend.Domain.Entities.Cart;
using papaMiaBackend.Domain.Models.Cart;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<CartItem, CartItemDto>();
        CreateMap<Cart, CartDto>();
    }
}
