using Microsoft.Extensions.Hosting;

namespace WebApplication1.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? Nascimento { get; set; }
        public bool? Ativo { get; set; }
        public List<TelefoneModel>? Telefones { get; set; }
    }
}
