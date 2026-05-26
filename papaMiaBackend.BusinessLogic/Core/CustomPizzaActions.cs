using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;
using IngNs = papaMiaBackend.Domain.Entities.Ingridient;
using papaMiaBackend.Domain.Models.CustomPizza;

namespace papaMiaBackend.BusinessLogic.Core;

public class CustomPizzaActions
{
    protected readonly IMapper Mapper;
    protected readonly CustomPizzaContext Db;

    public CustomPizzaActions(IMapper mapper, CustomPizzaContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal CustomPizzaDto? CreateCustomPizzaActionExecution(CustomPizzaCreateDto dto)
    {
        var ids = dto.IngridientIds.Distinct().ToList();
        if (ids.Count == 0)
            return null;

        var ingridients = Db.Set<IngNs.Ingridient>()
            .Where(i => ids.Contains(i.Id) && i.IsActive)
            .ToList();

        if (ingridients.Count != ids.Count)
            return null;

        var entity = Mapper.Map<PizzaNs.CustomPizza>(dto);
        entity.TotalPrice = ingridients.Sum(i => i.Price);
        entity.Ingridients = ingridients;

        Db.CustomPizzas.Add(entity);
        Db.SaveChanges();

        var created = Db.CustomPizzas
            .Include(p => p.Ingridients)
            .First(p => p.Id == entity.Id);

        return Mapper.Map<CustomPizzaDto>(created);
    }

    internal CustomPizzaDto? GetCustomPizzaByIdActionExecution(int id)
    {
        var entity = Db.CustomPizzas
            .Include(p => p.Ingridients)
            .FirstOrDefault(p => p.Id == id);

        return entity is null ? null : Mapper.Map<CustomPizzaDto>(entity);
    }
}
