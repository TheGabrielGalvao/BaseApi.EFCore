using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Product
{
    [Table("ProductCategory", Schema = "product")]
    public class ProductCategory : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ERegisterStatus Status { get; set; }
 
    }
}
