using Domain.Entities.Product;

namespace Domain.Interface.Repository.Product
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> Get();
        Task<ProductCategory> Get(Guid uuid);
        Task<ProductCategory> Create(ProductCategory productCategory);

        Task<ProductCategory> Update(ProductCategory productCategory);

        Task Delete(Guid uuid);
    }
}
