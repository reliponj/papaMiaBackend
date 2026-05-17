using papaMiaBackend.Domain.Models.CustomPizza;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface ICustomPizzaAction
{
    CustomPizzaDto? CreateCustomPizzaAction(CustomPizzaCreateDto dto);
}
