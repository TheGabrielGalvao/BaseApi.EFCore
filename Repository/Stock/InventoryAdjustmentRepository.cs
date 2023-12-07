using Database;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Stock;
using Microsoft.EntityFrameworkCore;
using Repository.Common;

namespace Repository.Stock
{
    public class InventoryAdjustmentRepository : BaseRepository<InventoryAdjustmentEntity>, IInventoryAdjustmentRepository
    {
        public InventoryAdjustmentRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<InventoryAdjustmentEntity>> Get() {
            var response = await _context.InventoryAdjustments.Include(x => x.Product).Include(y => y.StockLocation).ToListAsync();
            return response;
        }
    }
}
