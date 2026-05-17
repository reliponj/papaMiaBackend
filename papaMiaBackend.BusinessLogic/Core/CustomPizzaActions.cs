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
        var ids = dto.IngridientIds;
        var ingridients = Db.Set<IngNs.Ingridient>()
            .Where(i => ids.Contains(i.Id))
            .ToList();

        var entity = Mapper.Map<PizzaNs.CustomPizza>(dto);
        entity.Ingridients = ingridients;

        Db.CustomPizzas.Add(entity);
        Db.SaveChanges();

        var created = Db.CustomPizzas
            .Include(p => p.Ingridients)
            .First(p => p.Id == entity.Id);

        return Mapper.Map<CustomPizzaDto>(created);
    }
}
