using System.ComponentModel;

namespace Domain.Enum
{
    public enum EStockReleaseStatus
    {
        [Description("Pendente") ]
        PENDING = 0,

        [Description("Lançado")]
        RELEASED = 1,

        [Description("Cancelado")]
        CALCELED = 2,

        [Description("Estornado")]
        REVERSED = 3,
    }
}
