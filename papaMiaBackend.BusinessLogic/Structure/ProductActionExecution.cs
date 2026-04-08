using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.BusinessLogic.Structure;

public class ProductActionExecution : ProductActions, IProductAction
{
    public ProductActionExecution(IMapper mapper, ProductContext db)
        : base(mapper, db)
    {
    }
    public List<ProductDto> GetAllProductsAction()
    {
        return GetAllProductsActionExecution();
    }
}
