using Domain.Entities.Financial;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Common;

namespace Domain.Interface.Repository.Financial
{
    public interface IFinancialBalanceRepository : IBaseRepository<FinancialBalanceEntity>
    {
        Task<FinancialBalanceEntity> GetBalanceByWallet(int walletId);
    }
}
