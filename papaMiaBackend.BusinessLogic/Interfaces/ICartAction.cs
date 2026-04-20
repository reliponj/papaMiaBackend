using papaMiaBackend.Domain.Models.Cart;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface ICartAction
{
    List<CartDto> GetAllCartsAction();
}
