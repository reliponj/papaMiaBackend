using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Ingridient;
using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.BusinessLogic.Core;

public class IngridientActions
{
    protected readonly IMapper Mapper;
    protected readonly IngridientContext Db;

    public IngridientActions(IMapper mapper, IngridientContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<IngridientDto> GetAllIngridientsActionExecution()
    {
        var entities = Db.Ingridients
            .OrderBy(i => i.Type)
            .ThenBy(i => i.Name)
            .ToList();
        return Mapper.Map<List<IngridientDto>>(entities);
    }

    internal IngridientDto? GetIngridientByIdActionExecution(int id)
    {
        var entity = Db.Ingridients.FirstOrDefault(i => i.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<IngridientDto>(entity);
    }

    internal IngridientDto? CreateIngridientActionExecution(IngridientCreateDto dto)
    {
        var entity = Mapper.Map<Ingridient>(dto);
        entity.Name = dto.Name;
        Db.Ingridients.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<IngridientDto>(entity);
    }

    internal IngridientDto? UpdateIngridientActionExecution(int id, IngridientUpdateDto dto)
    {
        var entity = Db.Ingridients.FirstOrDefault(i => i.Id == id);
        if (entity is null)
            return null;

        Mapper.Map(dto, entity);
        entity.Name = dto.Name;
        Db.SaveChanges();
        return Mapper.Map<IngridientDto>(entity);
    }

    internal bool DeleteIngridientActionExecution(int id)
    {
        var entity = Db.Ingridients.FirstOrDefault(i => i.Id == id);
        if (entity is null)
            return false;

        Db.Ingridients.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
