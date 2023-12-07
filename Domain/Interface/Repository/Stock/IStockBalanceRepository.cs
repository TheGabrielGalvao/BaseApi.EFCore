using Domain.Entities.Stock;
using Domain.Interface.Repository.Common;

namespace Domain.Interface.Repository.Stock
{
    public interface IStockBalanceRepository : IBaseRepository<StockBalanceEntity>
    {
        Task<StockBalanceEntity> GetBalanceByProductInfo(int productId, int locationId);
    }
}
