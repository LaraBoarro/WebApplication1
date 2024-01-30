using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepositorio _telefoneRepositorio;

        public TelefoneController(ITelefoneRepositorio telefoneRepositorio)
        {
            _telefoneRepositorio = telefoneRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TelefoneModel>>> BuscarTodosTelefones()
        {
            List<TelefoneModel> telefones = await _telefoneRepositorio.BuscarTodosTelefones();
            return Ok(telefones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TelefoneModel>> BuscarPorId(int id)
        {
            TelefoneModel telefone = await _telefoneRepositorio.BuscarPorId(id);
            return Ok(telefone);
        }

        [HttpPost]
        public async Task<ActionResult<TelefoneModel>> Cadastrar([FromBody] TelefoneModel telefoneModel)
        {
            TelefoneModel telefone = await _telefoneRepositorio.Adicionar(telefoneModel);

            return Ok(telefone);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TelefoneModel>> Atualizar([FromBody] TelefoneModel telefoneModel, int id)
        {
            telefoneModel.Id = id;
            TelefoneModel telefone = await _telefoneRepositorio.Atualizar(telefoneModel, id);

            return Ok(telefone);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefoneModel>> Apagar(int id)
        {
            bool apagado = await _telefoneRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
