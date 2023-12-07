using Database;
using Domain.Entities.Financial;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Financial;
using Microsoft.EntityFrameworkCore;
using Repository.Common;

namespace Repository.Financial
{
    public class FinancialBalanceRepository : BaseRepository<FinancialBalanceEntity>, IFinancialBalanceRepository
    {
        public FinancialBalanceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<FinancialBalanceEntity> GetBalanceByWallet(int walletId)
        {
            var balance = await _context.FinancialBalances.Where(x => x.WalletId == walletId).FirstOrDefaultAsync() ;

            return balance ?? new FinancialBalanceEntity();
        }
    }
}
