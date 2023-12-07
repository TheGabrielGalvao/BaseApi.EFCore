using Domain.Entities.Stock;
using Domain.Interface.Repository.Common;

namespace Domain.Interface.Repository.Stock
{
    public interface IStockLocationRepository : IBaseRepository<StockLocationEntity>
    {
    }
}
