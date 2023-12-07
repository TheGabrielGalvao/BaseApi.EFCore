using Domain.Entities.Auth;
using Domain.Entities.Financial;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Fiancial
{
    [Table("FinancialRelease", Schema = "financial")]
    public class FinancialReleaseEntity : DefaultEntity
    {
        public string Title { get; set; }

        public decimal PreviousBalance { get; set; } = 0.00M;

        public decimal ReleasedValue { get; set; } = 0.00M;

        public decimal NextBalance { get; set; } = 0.00M;

        public EReleaseFlow Flow { get; set; }

        public EFinancialReleaseType FinancialReleaseType { get; set; }

        //[ForeignKey(nameof(FinancialReleaseTypeId))]
        //public FinancialReleaseTypeEntity FinancialReleaseType { get; set; }

        public EFinancialReleaseStatus Status { get; set; }

        public long WalletId { get; set; }
        
        [ForeignKey(nameof(WalletId))]
        public WalletEntity Wallet { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public long? TransactionCode { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public long? ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public ContactEntity? Contact { get; set; }

    }
}