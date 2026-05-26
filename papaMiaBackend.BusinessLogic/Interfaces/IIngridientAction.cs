using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IIngridientAction
{
    List<IngridientDto> GetAllIngridientsAction();
    List<IngridientDto> GetActiveIngridientsAction();
    IngridientDto? GetIngridientByIdAction(int id);
    IngridientDto? CreateIngridientAction(IngridientCreateDto dto);
    IngridientDto? UpdateIngridientAction(int id, IngridientUpdateDto dto);
    bool DeleteIngridientAction(int id);
}
