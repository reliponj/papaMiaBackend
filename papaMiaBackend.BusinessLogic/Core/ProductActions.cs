using AutoMapper;
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
    internal List<ProductDto> GetAllProductsActionExecution()
    {
        var entities = Db.Products.ToList();
        return Mapper.Map<List<ProductDto>>(entities);
    }
    internal ProductDto? GetProductByIdActionExecution(int id)
    {
        var entity = Db.Products.FirstOrDefault(p => p.Id == id);
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
        return Mapper.Map<ProductDto>(entity);
    }
    internal ProductDto? UpdateProductActionExecution(int id, ProductUpdateDto productUpdateDto)
    {
        var entity = Db.Products.FirstOrDefault(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        entity.Name = productUpdateDto.Name;
        entity.Description = productUpdateDto.Description;
        entity.Price = productUpdateDto.Price;
        entity.ImageUrl = productUpdateDto.ImageUrl;
        entity.Weight = productUpdateDto.Weight;
        entity.WeightType = productUpdateDto.WeightType;
        entity.Allergens = productUpdateDto.Allergens;
        Db.SaveChanges();
        return Mapper.Map<ProductDto>(entity);
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
