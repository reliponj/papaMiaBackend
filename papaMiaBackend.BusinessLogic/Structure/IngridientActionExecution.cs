using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.BusinessLogic.Structure;

public class IngridientActionExecution : IngridientActions, IIngridientAction
{
    public IngridientActionExecution(IMapper mapper, IngridientContext db)
        : base(mapper, db)
    {
    }

    public List<IngridientDto> GetAllIngridientsAction()
    {
        return GetAllIngridientsActionExecution();
    }

    public IngridientDto? GetIngridientByIdAction(int id)
    {
        return GetIngridientByIdActionExecution(id);
    }

    public IngridientDto? CreateIngridientAction(IngridientCreateDto dto)
    {
        return CreateIngridientActionExecution(dto);
    }

    public IngridientDto? UpdateIngridientAction(int id, IngridientUpdateDto dto)
    {
        return UpdateIngridientActionExecution(id, dto);
    }

    public bool DeleteIngridientAction(int id)
    {
        return DeleteIngridientActionExecution(id);
    }
}
