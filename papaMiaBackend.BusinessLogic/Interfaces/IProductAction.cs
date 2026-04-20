using papaMiaBackend.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IProductAction
{
    List<ProductDto> GetAllProductsAction();
    ProductDto? GetProductByIdAction(int id);
    ProductDto CreateProductAction(ProductDto productDto);
}


