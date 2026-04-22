using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.BusinessLogic.Structure;

public class PromocodeActionExecution : PromocodeActions, IPromocodeAction
{
    public PromocodeActionExecution(IMapper mapper, PromocodeContext db)
        : base(mapper, db)
    {
    }
    public List<PromocodeDto> GetAllPromocodesAction()
    {
        return GetAllPromocodesActionExecution();
    }
    public PromocodeDto? GetPromocodeByIdAction(int id)
    {
        return GetPromocodeByIdActionExecution(id);
    }
}