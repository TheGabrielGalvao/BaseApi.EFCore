using Domain.Enum;
using Domain.Model.Auth;
using Domain.Model.Contact;

namespace Domain.Model.Financial
{
    public class FinancialReleaseResponse
    {
        public Guid? Uuid { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EFinancialReleaseStatus Status { get; set; }
        public EFinancialOperation Operation { get; set; }
        public EFinancialReleaseType FinancialReleaseType { get; set; }
        public UserResponse User { get; set; }
        public ContactResponse? Contact { get; set; }

    }
}
