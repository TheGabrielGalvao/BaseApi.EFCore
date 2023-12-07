using Util.Enumerator;

namespace Domain.Model.Product
{
    public class ProductCategoryResponse
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ERegisterStatus Status { get; set; }

    }
}
