using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using OrdNs = papaMiaBackend.Domain.Entities.Order;
using PromoNs = papaMiaBackend.Domain.Entities.Promocode;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Core;

public class OrderActions
{
    protected readonly IMapper Mapper;
    protected readonly OrderContext Db;

    public OrderActions(IMapper mapper, OrderContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<OrderDto> GetAllOrdersActionExecution()
    {
        var entities = Db.Orders
            .Include(o => o.Items)
            .Include(o => o.CustomPizzaItems)
            .OrderByDescending(o => o.CreatedAt)
            .ToList();
        return Mapper.Map<List<OrderDto>>(entities);
    }

    internal List<OrderDto> GetOrdersByUserActionExecution(int userId)
    {
        var entities = Db.Orders
            .Include(o => o.Items)
            .Include(o => o.CustomPizzaItems)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt)
            .ToList();
        return Mapper.Map<List<OrderDto>>(entities);
    }

    internal OrderDto? GetOrderByIdActionExecution(int id)
    {
        var entity = Db.Orders
            .Include(o => o.Items)
            .Include(o => o.CustomPizzaItems)
            .FirstOrDefault(o => o.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<OrderDto>(entity);
    }

    internal OrderDto? GetOrderForUserActionExecution(int orderId, int userId)
    {
        var entity = Db.Orders
            .Include(o => o.Items)
            .Include(o => o.CustomPizzaItems)
            .FirstOrDefault(o => o.Id == orderId && o.UserId == userId);
        if (entity is null)
            return null;

        return Mapper.Map<OrderDto>(entity);
    }

    internal OrderDto? CreateOrderActionExecution(OrderCreateDto dto, int? userId)
    {
        if (dto.Items.Count == 0 || dto.Items.Any(i => i.ProductId <= 0 || i.Quantity <= 0))
            return null;
        if (dto.PromocodeId is int promocodeId
            && !Db.Set<PromoNs.Promocode>().Any(p => p.Id == promocodeId))
            return null;

        var entity = Mapper.Map<OrdNs.Order>(dto);
        entity.UserId = userId;
        entity.FirstName = entity.FirstName.Trim();
        entity.LastName = entity.LastName.Trim();
        entity.Phone = entity.Phone.Trim();
        entity.Email = entity.Email.Trim();
        entity.District = entity.District.Trim();
        entity.Address = entity.Address.Trim();
        entity.Note = entity.Note?.Trim();
        entity.CreatedAt = DateTime.UtcNow;
        entity.Status = OrdNs.OrderStatus.New;

        Db.Orders.Add(entity);
        Db.SaveChanges();
        var created = Db.Orders
            .Include(o => o.Items)
            .First(o => o.Id == entity.Id);
        return Mapper.Map<OrderDto>(created);
    }

    internal OrderDto? UpdateOrderActionExecution(int id, OrderUpdateDto dto)
    {
        var entity = Db.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.Id == id);
        if (entity is null)
            return null;

        if (dto.Items.Count == 0 || dto.Items.Any(i => i.ProductId <= 0 || i.Quantity <= 0))
            return null;
        if (dto.PromocodeId is int promocodeId
            && !Db.Set<PromoNs.Promocode>().Any(p => p.Id == promocodeId))
            return null;

        Mapper.Map(dto, entity);
        entity.FirstName = entity.FirstName.Trim();
        entity.LastName = entity.LastName.Trim();
        entity.Phone = entity.Phone.Trim();
        entity.Email = entity.Email.Trim();
        entity.District = entity.District.Trim();
        entity.Address = entity.Address.Trim();
        entity.Note = entity.Note?.Trim();

        entity.Items.Clear();
        foreach (var i in dto.Items)
        {
            entity.Items.Add(new OrdNs.OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            });
        }

        Db.SaveChanges();

        var updated = Db.Orders
            .Include(o => o.Items)
            .First(o => o.Id == id);
        return Mapper.Map<OrderDto>(updated);
    }

    internal bool DeleteOrderActionExecution(int id)
    {
        var entity = Db.Orders.FirstOrDefault(o => o.Id == id);
        if (entity is null)
            return false;

        Db.Orders.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
