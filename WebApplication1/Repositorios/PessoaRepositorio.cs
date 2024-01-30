using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly WebApplication1DBContex _dbContext;

        public PessoaRepositorio(WebApplication1DBContex webApplication1DBContex)
        {
            _dbContext = webApplication1DBContex;
        }

        public async Task<PessoaModel> BuscarPorId(int id)
        {
            return await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<PessoaModel>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }
        public async Task<PessoaModel> Adicionar(PessoaModel pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }
        public async Task<PessoaModel> Atualizar(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaPorId = await BuscarPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Pessoa para o ID: {id} não foi encontrada.");
            }

            pessoaPorId.Nome = pessoa.Nome;
            pessoaPorId.Cpf = pessoa.Cpf;
            pessoaPorId.Nascimento = pessoa.Nascimento;
            pessoaPorId.Ativo = pessoa.Ativo;

            _dbContext.Pessoas.Update(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return pessoaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            PessoaModel pessoaPorId = await BuscarPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Pessoa para o ID: {id} não foi encontrada.");
            }

            _dbContext.Pessoas.Remove(pessoaPorId);
            await _dbContext.SaveChangesAsync();
            
            return true;

        }


    }
}
