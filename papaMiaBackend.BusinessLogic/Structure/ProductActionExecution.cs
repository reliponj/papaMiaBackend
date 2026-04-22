using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;

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
    public ProductDto? GetProductByIdAction(int id)
    {
        return GetProductByIdActionExecution(id);
    }

    public ProductDto CreateProductAction(ProductCreateDto productCreateDto)
    {
        return CreateProductActionExecution(productCreateDto);
    }

    public ProductDto? UpdateProductAction(int id, ProductUpdateDto productUpdateDto)
    {
        return UpdateProductActionExecution(id, productUpdateDto);
    }

    public bool DeleteProductAction(int id)
    {
        return DeleteProductActionExecution(id);
    }
}