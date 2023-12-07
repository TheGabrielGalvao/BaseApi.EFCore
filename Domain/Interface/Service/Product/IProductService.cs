using Domain.Model.Product;

namespace Domain.Interface.Service.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> Get();
        Task<ProductResponse> Get(Guid uuid);

        Task<ProductResponse> Create(ProductRequest request);

        Task<ProductResponse> Update(Guid uuid, ProductRequest request);

        Task Delete(Guid uuid);
    }
}
