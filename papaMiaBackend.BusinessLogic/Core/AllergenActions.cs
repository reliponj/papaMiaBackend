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
}
