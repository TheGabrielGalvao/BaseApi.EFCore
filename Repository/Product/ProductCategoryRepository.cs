using Database;
using Domain.Entities.Product;
using Domain.Interface.Repository.Product;
using Microsoft.EntityFrameworkCore;

namespace Repository.Product
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductCategory> Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);

            return productCategory;
        }

        public async Task Delete(Guid uuid)
        {
            var productCategoryDelete = await _context.ProductCategories.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.ProductCategories.Remove(productCategoryDelete);
        }

        public async Task<IEnumerable<ProductCategory>> Get()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> Get(Guid uuid)
        {
            var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(c => c.Uuid == uuid);
            return productCategory;
        }

        public async Task<ProductCategory> Update(ProductCategory productCategory)
        {
            _context.Entry(productCategory).State = EntityState.Modified;
            return productCategory;
        }
    }
}
