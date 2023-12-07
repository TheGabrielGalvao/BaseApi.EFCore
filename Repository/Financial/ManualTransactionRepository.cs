using Database;
using Domain.Entities.Financial;
using Domain.Interface.Repository.Financial;
using Repository.Common;

namespace Repository.Financial
{
    public class ManualTransactionRepository : BaseRepository<ManualTransactionEntity>, IManualTransactionRepository
    {
        public ManualTransactionRepository(AppDbContext context) : base(context)
        {
        }


    }
}
