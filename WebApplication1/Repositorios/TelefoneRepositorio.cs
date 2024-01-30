using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class TelefoneRepositorio : ITelefoneRepositorio
    {
        private readonly WebApplication1DBContex _dbContext;

        public TelefoneRepositorio(WebApplication1DBContex webApplication1DBContex)
        {
            _dbContext = webApplication1DBContex;
        }

        public async Task<TelefoneModel> BuscarPorId(int id)
        {
            return await _dbContext.Telefones
                .Include( x => x.Pessoa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<TelefoneModel>> BuscarTodosTelefones()
        {
            return await _dbContext.Telefones
                .Include(x => x.Pessoa)
                .ToListAsync();
        }
        public async Task<TelefoneModel> Adicionar(TelefoneModel telefone)
        {
            await _dbContext.Telefones.AddAsync(telefone);
            await _dbContext.SaveChangesAsync();

            return telefone;
        }
        public async Task<TelefoneModel> Atualizar(TelefoneModel telefone, int id)
        {
            TelefoneModel telefonePorId = await BuscarPorId(id);
            if (telefonePorId == null)
            {
                throw new Exception($"Telefone para o ID: {id} não foi encontrado.");
            }

            telefonePorId.Tipo = telefone.Tipo;
            telefonePorId.Numero = telefone.Numero;
            telefonePorId.PessoaId = telefone.PessoaId;

            _dbContext.Telefones.Update(telefonePorId);
            await _dbContext.SaveChangesAsync();

            return telefonePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TelefoneModel telefonePorId = await BuscarPorId(id);
            if (telefonePorId == null)
            {
                throw new Exception($"Telefone para o ID: {id} não foi encontrado.");
            }

            _dbContext.Telefones.Remove(telefonePorId);
            await _dbContext.SaveChangesAsync();
            
            return true;

        }


    }
}
