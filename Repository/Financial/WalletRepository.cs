using Database;
using Domain.Entities.Financial;
using Domain.Interface.Repository.Financial;
using Repository.Common;

namespace Repository.Financial
{
    public class WalletRepository : BaseRepository<WalletEntity>, IWalletRepository
    {
        public WalletRepository(AppDbContext context) : base(context)
        {
        }


    }
}
