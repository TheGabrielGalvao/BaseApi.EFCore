using Domain.Enum;
using Domain.Model.Auth;
using Domain.Model.Contact;

namespace Domain.Model.Financial
{
    public class ManualTransactionResponse
    {
        public Guid Uuid { get; set; }
        public EFinancialReleaseStatus Status { get; set; }

        public decimal Value { get; set; } = 0.00M;

        public EReleaseFlow Flow { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; } = DateTime.Now;

        public UserResponse User { get; set; }

        public ContactResponse? Contact { get; set; }
    }
}
