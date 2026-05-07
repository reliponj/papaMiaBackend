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
}
