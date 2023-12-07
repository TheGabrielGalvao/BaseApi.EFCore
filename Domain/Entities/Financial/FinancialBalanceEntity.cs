using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Financial
{
    [Table("FinancialBalance", Schema = "financial")]
    public class FinancialBalanceEntity : DefaultEntity
    {
        public decimal Balance { get; set; } = 0.00M;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public long WalletId { get; set; }

        [ForeignKey(nameof(WalletId))]
        public WalletEntity Wallet { get; set; }
    }
}
