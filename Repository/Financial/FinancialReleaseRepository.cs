using Database;
using Domain.Entities.Fiancial;
using Domain.Interface.Repository.Financial;
using Repository.Common;

namespace Repository.Financial
{
    public class FinancialReleaseRepository : BaseRepository<FinancialReleaseEntity>, IFinancialReleaseRepository
    {
        public FinancialReleaseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
