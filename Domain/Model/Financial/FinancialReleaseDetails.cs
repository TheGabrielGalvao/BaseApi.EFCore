using Domain.Entities;
using Domain.Entities.Financial;
using Domain.Enum;

namespace Domain.Model.Financial
{
    public class FinancialReleaseDetails
    {
        public string Title { get; set; }
        public EReleaseFlow Flow { get; set; }
        public EFinancialReleaseType Type { get; set; }
        public EFinancialReleaseStatus Status { get; set; }
        public int TransactionCode { get; set; }
        public decimal Value { get; set; }
        public WalletEntity Wallet { get; set; }
        public ContactEntity? Contact { get; set; }
    }
}
