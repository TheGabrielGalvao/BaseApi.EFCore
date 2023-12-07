using Domain.Entities.Product;

namespace Domain.Interface.Repository.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> Get();
        Task<ProductEntity> Get(Guid uuid);
        Task<ProductEntity> Create(ProductEntity product);

        Task<ProductEntity> Update(ProductEntity product);

        Task Delete(Guid uuid);
    }
}
