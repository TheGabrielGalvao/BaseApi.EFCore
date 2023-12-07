using Domain.Entities.Fiancial;

namespace Domain.Interface.Repository.Financial
{
    public interface IFinancialReleaseTypeRepository
    {
        Task<IEnumerable<FinancialReleaseTypeEntity>> Get();
        Task<FinancialReleaseTypeEntity> Get(Guid uuid);
        Task<FinancialReleaseTypeEntity> Create(FinancialReleaseTypeEntity transactionType);
        Task<FinancialReleaseTypeEntity> Update(FinancialReleaseTypeEntity transactionType);
        Task Delete(Guid uuid);
    }
}
