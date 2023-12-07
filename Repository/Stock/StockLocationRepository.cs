using Database;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Stock;
using Repository.Common;

namespace Repository.Stock
{
    public class StockLocationRepository : BaseRepository<StockLocationEntity>, IStockLocationRepository
    {
        public StockLocationRepository(AppDbContext context) : base(context)
        {
        }


    }
}
