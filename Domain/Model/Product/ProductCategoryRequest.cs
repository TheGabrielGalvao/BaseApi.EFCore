using Util.Enumerator;

namespace Domain.Model.Product
{
    public class ProductCategoryRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ERegisterStatus Status { get; set; }

    }
}
