using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;
using papaMiaBackend.Domain.Entities.Product;

namespace papaMiaBackend.BusinessLogic.Core;

public class ProductActions
{
    protected readonly IMapper Mapper;
    protected readonly ProductContext Db;
    public ProductActions(IMapper mapper, ProductContext db)
    {
        Mapper = mapper;
        Db = db;
    }
    internal List<ProductListDto> GetAllProductsActionExecution(
        int? categoryId,
        int[]? allergenExcludeIds,
        string? sortBy,
        string? sortDir)
    {
        IQueryable<Product> query = Db.Products;
        if (categoryId is int cid)
        {
            query = query.Where(p => p.CategoryId == cid);
        }

        if (allergenExcludeIds is { Length: > 0 })
        {
            var ids = allergenExcludeIds.Distinct().ToArray();
            query = query.Where(p => !p.AllergenLinks.Any(a => ids.Contains(a.Id)));
        }

        var byPrice = string.Equals(sortBy?.Trim(), "price", StringComparison.OrdinalIgnoreCase);
        var desc = string.Equals(sortDir?.Trim(), "desc", StringComparison.OrdinalIgnoreCase);

        if (byPrice)
            query = desc
                ? query.OrderByDescending(p => p.Price).ThenBy(p => p.Id)
                : query.OrderBy(p => p.Price).ThenBy(p => p.Id);
        else
            query = desc
                ? query.OrderByDescending(p => p.Name).ThenBy(p => p.Id)
                : query.OrderBy(p => p.Name).ThenBy(p => p.Id);

        return Mapper.Map<List<ProductListDto>>(query.ToList());
    }
    internal ProductDto? GetProductByIdActionExecution(int id)
    {
        var entity = Db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        return Mapper.Map<ProductDto>(entity);
    }
    internal ProductDto CreateProductActionExecution(ProductCreateDto productCreateDto)
    {
        var entity = Mapper.Map<Product>(productCreateDto);
        Db.Products.Add(entity);
        Db.SaveChanges();
        var created = Db.Products.Include(p => p.Category).First(p => p.Id == entity.Id);
        return Mapper.Map<ProductDto>(created);
    }
    internal ProductDto? UpdateProductActionExecution(int id, ProductUpdateDto productUpdateDto)
    {
        var entity = Db.Products.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        Mapper.Map(productUpdateDto, entity);
        Db.SaveChanges();
        var updated = Db.Products.Include(p => p.Category).First(p => p.Id == entity.Id);
        return Mapper.Map<ProductDto>(updated);
    }
    internal bool DeleteProductActionExecution(int id)
    {
        var entity = Db.Products.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return false;
        }
        Db.Products.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
