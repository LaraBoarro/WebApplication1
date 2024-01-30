using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
    public interface ITelefoneRepositorio
    {
        Task<List<TelefoneModel>> BuscarTodosTelefones();
        Task<TelefoneModel> BuscarPorId(int id);
        Task<TelefoneModel> Adicionar(TelefoneModel telefone);
        Task<TelefoneModel> Atualizar(TelefoneModel telefone, int id);
        Task<bool> Apagar(int id);
    }
}
