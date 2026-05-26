using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.CustomPizza;

namespace papaMiaBackend.BusinessLogic.Structure;

public class CustomPizzaActionExecution : CustomPizzaActions, ICustomPizzaAction
{
    public CustomPizzaActionExecution(IMapper mapper, CustomPizzaContext db)
        : base(mapper, db)
    {
    }

    public CustomPizzaDto? CreateCustomPizzaAction(CustomPizzaCreateDto dto)
    {
        return CreateCustomPizzaActionExecution(dto);
    }

    public CustomPizzaDto? GetCustomPizzaByIdAction(int id)
    {
        return GetCustomPizzaByIdActionExecution(id);
    }
}
