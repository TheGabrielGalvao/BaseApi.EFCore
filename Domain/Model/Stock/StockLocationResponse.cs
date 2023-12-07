using Util.Enumerartor;

namespace Domain.Model.Stock
{
    public class StockLocationResponse
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public EGenericStatus Status { get; set; }
    }
}
