using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerartor;

namespace Domain.Entities.Financial
{
    [Table("Wallet", Schema = "financial")]
    public class WalletEntity : DefaultEntity
    {
        public string Name { get; set; }

        public EWalletType Type { get; set; }

        public EGenericStatus Status { get; set; }
    }
}
