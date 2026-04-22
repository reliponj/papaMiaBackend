using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Promocode;
using papaMiaBackend.Domain.Entities.Promocode;

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
    internal PromocodeDto CreatePromocodeActionExecution(PromocodeCreateDto promocodeCreateDto)
    {
        var entity = Mapper.Map<Promocode>(promocodeCreateDto);
        Db.Promocodes.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<PromocodeDto>(entity);
    }
    internal PromocodeDto? UpdatePromocodeActionExecution(int id, PromocodeUpdateDto promocodeUpdateDto)
    {
        var entity = Db.Promocodes.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        entity.Code = promocodeUpdateDto.Code;
        entity.Percent = promocodeUpdateDto.Percent;
        entity.ExpiryDate = promocodeUpdateDto.ExpiryDate;
        entity.IsActive = promocodeUpdateDto.IsActive;
        Db.SaveChanges();
        return Mapper.Map<PromocodeDto>(entity);
    }

}