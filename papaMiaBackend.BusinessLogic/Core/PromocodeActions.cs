using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    internal bool DeletePromocodeActionExecution(int id)
    {
        var entity = Db.Promocodes.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return false;
        }
        Db.Promocodes.Remove(entity);
        Db.SaveChanges();
        return true;
    }

    internal PromocodeValidationResult ValidatePromocodeForUserActionExecution(string code, int userId)
    {
        var trimmed = code.Trim();
        if (trimmed.Length == 0)
            return new PromocodeValidationResult(PromocodeValidationStatus.NotFound);

        var lower = trimmed.ToLowerInvariant();
        var entity = Db.Promocodes.AsNoTracking().FirstOrDefault(p => p.Code.ToLower() == lower);
        if (entity is null)
            return new PromocodeValidationResult(PromocodeValidationStatus.NotFound);

        if (!entity.IsActive)
            return new PromocodeValidationResult(PromocodeValidationStatus.Inactive);

        if (entity.ExpiryDate < DateTime.UtcNow)
            return new PromocodeValidationResult(PromocodeValidationStatus.Expired);

        var alreadyUsed = Db.PromocodeUsages.AsNoTracking()
            .Any(u => u.UserId == userId && u.PromocodeId == entity.Id);
        if (alreadyUsed)
            return new PromocodeValidationResult(PromocodeValidationStatus.AlreadyUsedByUser);

        return new PromocodeValidationResult(PromocodeValidationStatus.Ok, Mapper.Map<PromocodeDto>(entity));
    }
}