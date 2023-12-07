using Database;
using Domain.Entities.Product;
using Domain.Interface.Repository.Product;
using Microsoft.EntityFrameworkCore;

namespace Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        public readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductEntity> Create(ProductEntity product)
        {
            _context.Products.Add(product);

            return product;
        }

        public async Task Delete(Guid uuid)
        {
            var productDelete = await _context.Products.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.Products.Remove(productDelete);
        }

        public async Task<IEnumerable<ProductEntity>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> Get(Guid uuid)
        {
            var product = await _context.Products.Include(x => x.ProductCategory).Include(y => y.StockLocation).FirstOrDefaultAsync(c => c.Uuid == uuid);
            return product;
        }

        public async Task<ProductEntity> Update(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return product;
        }
    }
}
