using System.ComponentModel;

namespace WebApplication1.Data.Enums
{
    public enum TipoTelefone
    {
        [Description("Celular")]
        Celular = 1,
        [Description("Residencial")]
        Residencial,
        [Description("Comercial")]
        Comercial
    }
}
