using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.BusinessLogic.Core;
public class PromocodeActions
{
    protected readonly IMapper Mapper;
    protected readonly PromocodeContext Db;
    public PromocodeActions(IMapper mapper, PromocodeContext db)
    {
        Mapper = mapper;
        Db = db;
    }
    internal List<PromocodeDto> GetAllPromocodesActionExecution()
    {
        var entities = Db.Promocodes.ToList();
        return Mapper.Map<List<PromocodeDto>>(entities);
    }
    internal PromocodeDto? GetPromocodeByIdActionExecution(int id)
    {
        var entity = Db.Promocodes.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        return Mapper.Map<PromocodeDto>(entity);
    }
}