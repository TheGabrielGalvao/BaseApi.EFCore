using Database;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Stock;
using Microsoft.EntityFrameworkCore;
using Repository.Common;

namespace Repository.Stock
{
    public class StockBalanceRepository : BaseRepository<StockBalanceEntity>, IStockBalanceRepository
    {
        public StockBalanceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<StockBalanceEntity> GetBalanceByProductInfo(int productId, int locationId)
        {
            var balance = await _context.StockBalances.Where(x => x.ProductId == productId && x.StockLocationId == locationId).FirstOrDefaultAsync();

            return balance ?? new StockBalanceEntity(); 
        }
    }
}
