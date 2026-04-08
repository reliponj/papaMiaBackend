using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;
using papaMiaBackend.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

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
    
}
