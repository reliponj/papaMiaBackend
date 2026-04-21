using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Cart;

namespace papaMiaBackend.BusinessLogic.Core;

public class CartActions
{
    protected readonly IMapper Mapper;
    protected readonly CartContext Db;

    public CartActions(IMapper mapper, CartContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<CartDto> GetAllCartsActionExecution()
    {
        var entities = Db.Carts.Include(c => c.Items).ToList();
        return Mapper.Map<List<CartDto>>(entities);
    }
}
