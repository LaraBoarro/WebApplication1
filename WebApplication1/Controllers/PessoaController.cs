using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;
using WebApplication1.Wrappers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodasPessoas()
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(int id)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPorId(id);
            return Ok(new Response<PessoaModel>(pessoa));
        }

        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepositorio.Adicionar(pessoaModel);

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel pessoaModel, int id)
        {
            pessoaModel.Id = id;
            PessoaModel pessoa = await _pessoaRepositorio.Atualizar(pessoaModel, id);

            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> Apagar(int id)
        {
            bool apagado = await _pessoaRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
