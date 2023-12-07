using Domain.Entities.Auth;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Financial
{
    [Table("ManualTransaction", Schema = "financial")]
    public class ManualTransactionEntity : DefaultEntity
    {
        public EFinancialReleaseStatus Status { get; set; }

        public decimal Value { get; set; } = 0.00M;

        public EReleaseFlow Flow { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; } = DateTime.Now;

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public long? ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public ContactEntity? Contact { get; set; }

        public long WalletId { get; set; }

        [ForeignKey(nameof(WalletId))]
        public WalletEntity Wallet { get; set; }
        
    }

}
