using System.ComponentModel;

namespace Domain.Enum
{
    public enum EStockReleaseType
    {
        [Description("Ajuste de Estoque")]
        ADJUST = 0,

        [Description("Entrada de Mercadoria")]
        INCOME = 1,

        [Description("Venda")]
        VENDA = 2,
        
        [Description("Estorno de Lançamento")]
        REVERSAL = 10,
    }
}
