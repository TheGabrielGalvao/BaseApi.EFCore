using Domain.Entities.Auth;
using Domain.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Stock
{
    [Table("StockBalance", Schema = "stock")]
    public class StockBalanceEntity : DefaultEntity
    {
        [Column(TypeName = "decimal(19,9)")]
        public decimal? Balance { get; set; }

        public long StockLocationId { get; set; }
        
        [ForeignKey(nameof(StockLocationId))]
        public StockLocationEntity StockLocation { get; set; }

        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
