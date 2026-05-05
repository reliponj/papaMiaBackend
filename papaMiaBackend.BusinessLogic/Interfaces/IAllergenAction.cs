using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IAllergenAction
{
    List<AllergenDto> GetAllAllergensAction();
    AllergenDto? GetAllergenByIdAction(int id);
    AllergenDto? CreateAllergenAction(AllergenCreateDto dto);
    AllergenDto? UpdateAllergenAction(int id, AllergenUpdateDto dto);
    bool DeleteAllergenAction(int id);
}
