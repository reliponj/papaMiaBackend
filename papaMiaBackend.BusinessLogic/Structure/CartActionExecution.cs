using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Cart;

namespace papaMiaBackend.BusinessLogic.Structure;

public class CartActionExecution : CartActions, ICartAction
{
    public CartActionExecution(IMapper mapper, CartContext db)
        : base(mapper, db)
    {
    }

    public List<CartDto> GetAllCartsAction()
    {
        return GetAllCartsActionExecution();
    }
}
