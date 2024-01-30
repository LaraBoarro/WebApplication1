using WebApplication1.Data.Enums;

namespace WebApplication1.Models
{
    public class TelefoneModel
    {
        public int Id { get; set; }
        public TipoTelefone? Tipo { get; set; }
        public string? Numero { get; set; }
        public int? PessoaId { get; set; }
        public PessoaModel? Pessoa { get; set; }
    }
}
