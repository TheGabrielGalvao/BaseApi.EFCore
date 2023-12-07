using AutoMapper;
using Domain.Entities.Auth;
using Domain.Entities.Fiancial;
using Domain.Entities.Financial;
using Domain.Enum;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Service.Financial;
using Domain.Model.Financial;
using Service.Common;

namespace Service.Financial
{
    public class FinancialReleaseService : BaseService<FinancialReleaseEntity, FinancialReleaseRequest, FinancialReleaseResponse>, IFinancialReleaseService
    {
        private readonly IFinancialBalanceRepository _balanceRepository;
        public FinancialReleaseService(IFinancialReleaseRepository repository, IFinancialBalanceRepository balanceRepository, IMapper mapper, IUnitOfWork uow) : base(repository, mapper, uow)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task FinancialProcessor(FinancialReleaseDetails details, User user)
        {
            try
            {
                var balance = await GetBalanceByWallet((int)details.Wallet?.Id);
                var currentBalance = balance.Balance;
                var nextBalance = details.Flow == EReleaseFlow.INFLOW ? currentBalance + details.Value : currentBalance - details.Value;


                var financialRelease = new FinancialReleaseEntity()
                {
                    Title = details.Title,
                    Flow = details.Flow,
                    ReleasedValue = details.Value,
                    WalletId = details.Wallet.Id,
                    Wallet = details.Wallet,
                    FinancialReleaseType = details.Type,
                    ContactId = details.Contact?.Id,
                    Contact = details.Contact,
                    UserId = user.Id,
                    User = user,
                    TransactionCode = details.TransactionCode,
                    Status = details.Status,

                };

                await _repository.Create(financialRelease);

                

                if (financialRelease.Status == EFinancialReleaseStatus.COMPLETED)
                {
                    balance.Balance = nextBalance;
                    balance.LastUpdated = DateTime.UtcNow;
                    balance.WalletId = financialRelease.Wallet.Id;
                    balance.Wallet = financialRelease.Wallet;

                    if (balance.Id > 0)
                    {
                        await _balanceRepository.Update(balance);
                    }

                    else
                    {
                        await _balanceRepository.Create(balance);
                    }
                }

                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
            }
        }

        
        public async Task<FinancialBalanceEntity> GetBalanceByWallet(int walletId)
        {
            var balance = await _balanceRepository.GetBalanceByWallet(walletId);

            return balance;
        }

        
        public async Task<FinancialDashboardResponse> GetDashBoardData()
        {
            var financialReleases = await _repository.Get();
            var totalExpenseCompleted = financialReleases.Where(x => x.Flow == EReleaseFlow.OUTFLOW && x.Status == EFinancialReleaseStatus.COMPLETED).Sum(x => x.ReleasedValue);
            var totalRevenueCompleted = financialReleases.Where(x => x.Flow == EReleaseFlow.INFLOW && x.Status == EFinancialReleaseStatus.COMPLETED).Sum(x => x.ReleasedValue);
            
            var totalExpensePending = financialReleases.Where(x => x.Flow == EReleaseFlow.OUTFLOW && x.Status == EFinancialReleaseStatus.PENDING).Sum(x => x.ReleasedValue);
            var totalRevenuePending = financialReleases.Where(x => x.Flow == EReleaseFlow.INFLOW && x.Status == EFinancialReleaseStatus.PENDING).Sum(x => x.ReleasedValue);
            
            var currentBalance = totalRevenueCompleted - totalExpenseCompleted;
            var expectedBalance = totalRevenuePending - totalExpensePending;

            var response = new FinancialDashboardResponse
            {
                TotalExpenseCompleted = totalExpenseCompleted,
                TotalRevenueCompleted = totalRevenueCompleted,
                TotalExpensePending = totalExpensePending,
                TotalRevenuePending = totalRevenuePending,
                CurrentBalance = currentBalance,
                ExpectedBalance = expectedBalance
            };
            
            return response;
        }
        
    }
}
