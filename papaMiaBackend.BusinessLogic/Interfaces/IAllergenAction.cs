using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IAllergenAction
{
    List<AllergenDto> GetAllAllergensAction();
    AllergenDto? GetAllergenByIdAction(int id);
}
