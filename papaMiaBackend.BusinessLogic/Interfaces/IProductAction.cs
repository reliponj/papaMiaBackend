using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IProductAction
{
    List<ProductDto> GetAllProductsAction();
    ProductDto? GetProductByIdAction(int id);
    ProductDto CreateProductAction(ProductCreateDto productCreateDto);
    ProductDto? UpdateProductAction(int id, ProductUpdateDto productUpdateDto);
    bool DeleteProductAction(int id);
}


