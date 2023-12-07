using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerartor;

namespace Domain.Entities.Stock
{
    [Table("StockLocation", Schema = "stock")]
    public class StockLocationEntity : DefaultEntity
    {
        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Description { get; set; }

        public ICollection<StockBalanceEntity>? StockBalances { get; set; }
        public ICollection<StockReleaseEntity>? StockReleases { get; set; }

        public EGenericStatus Status { get; set; }
    }
}
