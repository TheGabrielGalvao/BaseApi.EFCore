using Domain.Entities.Product;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Stock
{
    [Table("InventoryAdjustment", Schema = "stock")]
    public class InventoryAdjustmentEntity : DefaultEntity
    {
        [Column(TypeName = "varchar(25)")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(19,9)")]
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public EReleaseFlow Flow { get; set; }

        public EStockReleaseStatus Status { get; set; }

        public long ProductId { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }

        public long StockLocationId { get; set; }
        
        [ForeignKey(nameof(StockLocationId))]
        public StockLocationEntity StockLocation { get; set; }
    }

}

