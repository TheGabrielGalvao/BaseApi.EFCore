using Domain.Interface.Service.Common;
using Domain.Model.Stock;

namespace Domain.Interface.Service.Stock
{
    public interface IInventoryAdjustmentService : IBaseService<InventoryAdjustmentRequest, InventoryAdjustmentResponse>
    {
    }
}
