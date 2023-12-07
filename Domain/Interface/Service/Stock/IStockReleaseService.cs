using Domain.Entities.Auth;
using Domain.Entities.Product;
using Domain.Entities.Stock;
using Domain.Interface.Service.Common;
using Domain.Model.Stock;

namespace Domain.Interface.Service.Stock
{
    public interface IStockReleaseService : IBaseService<StockReleaseRequest, StockReleaseResponse>
    {
        Task<StockBalanceEntity> GetBalanceByProductInfo(int productId, int locationId);
        Task StockProcessor(ProductEntity product, StockReleaseDetails details, User user);
    }
}
