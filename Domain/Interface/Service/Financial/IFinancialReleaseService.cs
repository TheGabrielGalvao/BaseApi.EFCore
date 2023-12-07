
using Domain.Entities.Auth;
using Domain.Entities.Financial;
using Domain.Enum;
using Domain.Interface.Service.Common;
using Domain.Model.Financial;

namespace Domain.Interface.Service.Financial
{
    public interface IFinancialReleaseService : IBaseService<FinancialReleaseRequest, FinancialReleaseResponse>
    {
        Task<FinancialBalanceEntity> GetBalanceByWallet(int walletId);
        Task FinancialProcessor(FinancialReleaseDetails details, User user);
        Task<FinancialDashboardResponse> GetDashBoardData();
    }
}
