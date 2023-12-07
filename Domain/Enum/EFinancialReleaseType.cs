using System.ComponentModel;

namespace Domain.Enum
{
    public enum EFinancialReleaseType
    {
        [Description("Ajuste de Saldo")]
        ADJUST = 0,

        [Description("Transação Manual")]
        MANUAL = 1,

        [Description("Venda")]
        VENDA = 2,

        [Description("Estorno de Lançamento")]
        REVERSAL = 10,
    }
}
