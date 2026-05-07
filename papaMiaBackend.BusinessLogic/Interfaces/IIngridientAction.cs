using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IIngridientAction
{
    List<IngridientDto> GetAllIngridientsAction();
    IngridientDto? GetIngridientByIdAction(int id);
}
