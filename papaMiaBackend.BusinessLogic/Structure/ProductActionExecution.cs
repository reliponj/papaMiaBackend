using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.BusinessLogic.Structure;

public class ProductActionExecution : ProductActions, IProductAction
{
    public List<ProductDto> GetAllProductsAction()
    {
        return GetAllProductsActionExecution();
    }
}
