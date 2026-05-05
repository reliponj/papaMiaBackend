using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Structure;

public class AllergenActionExecution : AllergenActions, IAllergenAction
{
    public AllergenActionExecution(IMapper mapper, ProductContext db)
        : base(mapper, db)
    {
    }

    public List<AllergenDto> GetAllAllergensAction()
    {
        return GetAllAllergensActionExecution();
    }

    public AllergenDto? GetAllergenByIdAction(int id)
    {
        return GetAllergenByIdActionExecution(id);
    }
}
