using Util.Enumerator;

namespace Domain.Model.Product
{
    public class ProductRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public ERegisterStatus? Status { get; set; }
        public Guid? ProductCategoryUuid { get; set; }

        public bool AffectsStock { get; set; }
        public decimal? MinimalStock { get; set; }
    }
}
