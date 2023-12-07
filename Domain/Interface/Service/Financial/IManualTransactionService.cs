using Domain.Interface.Service.Common;
using Domain.Model.Financial;

namespace Domain.Interface.Service.Financial
{
    public interface IManualTransactionService : IBaseService<ManualTransactionRequest, ManualTransactionResponse>
    {
    }
}
