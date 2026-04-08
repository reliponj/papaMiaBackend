using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.BusinessLogic.Core;

public class ProductActions
{
    protected readonly ProductContext Db;
    internal List<ProductDto> GetAllProductsActionExecution()
    {
        var entities = Db.Products.ToList();
        return entities;
    }
    
}
