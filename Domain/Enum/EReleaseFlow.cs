using System.ComponentModel;

namespace Domain.Enum
{
    public enum EReleaseFlow
    {
        [Description("Entrada")]
        INFLOW = 0,

        [Description("Saída")]
        OUTFLOW = 1,
    }
}
