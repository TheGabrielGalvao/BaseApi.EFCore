using Domain.Entities.Auth;
using Domain.Entities.Product;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Stock
{
    [Table("StockRelease", Schema = "stock")]
    public class StockReleaseEntity : DefaultEntity
    {
        [Column(TypeName = "varchar(45)")]
        public string Title { get; set; }

        [Column(TypeName = "decimal(19,9)")]
        public decimal? PreviousBalance { get; set; } = 0;

        [Column(TypeName = "decimal(19,9)")]
        public decimal QuantityReleased { get; set; }

        [Column(TypeName = "decimal(19,9)")]
        public decimal NextBalance { get; set; } = 0;

        public long? StockReleaseId { get; set; }

        public  EReleaseFlow Flow { get; set; }

        public EStockReleaseStatus Status { get; set; }

        public EStockReleaseType StockReleaseType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public long ProductId { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }

        public long StockLocationId { get; set; }
        
        [ForeignKey(nameof(StockLocationId))]
        public StockLocationEntity StockLocation { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
