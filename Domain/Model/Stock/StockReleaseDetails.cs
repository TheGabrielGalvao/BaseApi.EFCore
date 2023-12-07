using Domain.Enum;

namespace Domain.Model.Stock
{
    public class StockReleaseDetails
    {
        public EReleaseFlow Flow { get; set; }
        public decimal Amount { get; set; }
        public int StockReleaseId { get; set; }
        public EStockReleaseType Type { get; set; }
        public EStockReleaseStatus Status { get; set; }
    }
}
