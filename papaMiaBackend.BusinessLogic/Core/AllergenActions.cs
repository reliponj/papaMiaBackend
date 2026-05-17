using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Product;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Core;

public class AllergenActions
{
    protected readonly IMapper Mapper;
    protected readonly ProductContext Db;

    public AllergenActions(IMapper mapper, ProductContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<AllergenDto> GetAllAllergensActionExecution()
    {
        var entities = Db.Allergens.OrderBy(a => a.Name).ToList();
        return Mapper.Map<List<AllergenDto>>(entities);
    }

    internal AllergenDto? GetAllergenByIdActionExecution(int id)
    {
        var entity = Db.Allergens.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<AllergenDto>(entity);
    }

    internal AllergenDto? CreateAllergenActionExecution(AllergenCreateDto dto)
    {
        var entity = Mapper.Map<Allergen>(dto);
        entity.Name = dto.Name;
        Db.Allergens.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<AllergenDto>(entity);
    }

    internal AllergenDto? UpdateAllergenActionExecution(int id, AllergenUpdateDto dto)
    {
        var entity = Db.Allergens.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return null;

        entity.Name = dto.Name;
        Db.SaveChanges();
        return Mapper.Map<AllergenDto>(entity);
    }

    internal bool DeleteAllergenActionExecution(int id)
    {
        var entity = Db.Allergens.FirstOrDefault(a => a.Id == id);
        if (entity is null)
            return false;

        Db.Allergens.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
