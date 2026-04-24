using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface IProductAction
{
    List<ProductListDto> GetAllProductsAction(int? categoryId);
    ProductDto? GetProductByIdAction(int id);
    ProductDto CreateProductAction(ProductCreateDto productCreateDto);
    ProductDto? UpdateProductAction(int id, ProductUpdateDto productUpdateDto);
    bool DeleteProductAction(int id);
}


