using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs_tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> Get()
        {
            return Ok(await _enderecoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);
        }

        [HttpGet("cep/{cep}")]
        public async Task<ActionResult<Endereco>> GetByCep(string cep)
        {
            try
            {
                var endereco = await _enderecoService.GetByCepAsync(cep);
                if (endereco == null) return NotFound();
                return Ok(endereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logradouro/{logradouro}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetByLogradouro(string logradouro)
        {
            var enderecos = await _enderecoService.GetByLogradouroAsync(logradouro);
            if (!enderecos.Any()) return NotFound();
            return Ok(enderecos);
        }

        [HttpGet("cidade/{cidade}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> FiltrarPorCidade(string cidade)
        {
            try
            {
                var enderecos = await _enderecoService.FiltrarAsync(cidade);
                return Ok(enderecos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });

            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Endereco endereco)
        {
            try
            {
                await _enderecoService.AddAsync(endereco);
                return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoTamanhoInvalidoException ex) {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoVazioException ex) {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (CepForaFormatacao ex) {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Endereco endereco)
        {
            if (id != endereco.Id)
                return BadRequest("ID da URL não bate com o corpo da requisição.");

            try
            {
                await _enderecoService.UpdateAsync(endereco);
                return NoContent();
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoTamanhoInvalidoException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (CepForaFormatacao ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null)
                return NotFound($"Endereço com ID {id} não encontrado.");

            await _enderecoService.DeleteAsync(endereco);
            return NoContent();
        }
    }
}
