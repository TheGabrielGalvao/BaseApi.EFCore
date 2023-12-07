using Database;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Stock;
using Repository.Common;

namespace Repository.Stock
{
    public class StockReleaseRepository : BaseRepository<StockReleaseEntity>, IStockReleaseRepository
    {
        public StockReleaseRepository(AppDbContext context) : base(context)
        {
        }


    }
}
