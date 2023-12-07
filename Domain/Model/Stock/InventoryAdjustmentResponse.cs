using Domain.Enum;
using Domain.Model.Product;

namespace Domain.Model.Stock
{
    public class InventoryAdjustmentResponse
    {
        public Guid Uuid { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public EReleaseFlow Flow { get; set; }

        public EStockReleaseStatus Status { get; set; }
        
        public ProductResponse Product { get; set; }

        public StockLocationResponse StockLocation { get; set; }
    }
}
