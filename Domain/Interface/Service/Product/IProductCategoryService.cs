using Domain.Model.Product;

namespace Domain.Interface.Service.Product
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryResponse>> Get();
        Task<ProductCategoryResponse> Get(Guid uuid);

        Task<ProductCategoryResponse> Create(ProductCategoryRequest request);

        Task<ProductCategoryResponse> Update(Guid uuid, ProductCategoryRequest request);

        Task Delete(Guid uuid);
    }
}
