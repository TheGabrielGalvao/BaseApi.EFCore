using Domain.Enum;

namespace Domain.Model.Financial
{
    public class ManualTransactionRequest
    {
        public Guid? Uuid { get; set; }
        public EFinancialReleaseStatus Status { get; set; }

        public decimal Value { get; set; } = 0.00M;

        public EReleaseFlow Flow { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }
        public DateTime? DueDate { get; set; } = DateTime.Now;

        public Guid? ContactUuid { get; set; }
    }
}
