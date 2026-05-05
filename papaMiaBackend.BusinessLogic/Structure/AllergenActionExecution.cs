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

    public AllergenDto? CreateAllergenAction(AllergenCreateDto dto)
    {
        return CreateAllergenActionExecution(dto);
    }

    public AllergenDto? UpdateAllergenAction(int id, AllergenUpdateDto dto)
    {
        return UpdateAllergenActionExecution(id, dto);
    }

    public bool DeleteAllergenAction(int id)
    {
        return DeleteAllergenActionExecution(id);
    }
}
