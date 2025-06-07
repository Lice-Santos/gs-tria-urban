using gs_tria_2025.DTOs;
using gs_tria_2025.Enums;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs_tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoDistribuicaoController : ControllerBase
    {
        private readonly PontoDistribuicaoService _pontoService;

        public PontoDistribuicaoController(PontoDistribuicaoService pontoService)
        {
            _pontoService = pontoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PontoDistribuicao>>> GetAll()
        {
            var pontos = await _pontoService.GetAllAsync();
            return Ok(pontos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PontoDistribuicao>> GetById(int id)
        {
            var ponto = await _pontoService.GetByIdAsync(id);
            if (ponto == null)
                return NotFound("Ponto de distribuição não encontrado.");

            return Ok(ponto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PontoDistribuicaoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pontoService.AddAsync(dto);
                return Ok("Ponto de distribuição criado com sucesso.");
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return NotFound(new { StatusCode = 400, ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });

            }
            catch (CampoInvalidoException ex)
            {
                return NotFound(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,PontoDistribuicaoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pontoService.UpdateAsync(id, dto);
                return Ok("Ponto de distribuição atualizado com sucesso.");
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return NotFound(new { StatusCode = 400, ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });

            }
            catch (CampoInvalidoException ex)
            {
                return NotFound(new { StatusCode = 400, ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _pontoService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<PontoDistribuicao>>> GetByNome(string nome)
        {
            var pontos = await _pontoService.GetByNomeAsync(nome);
            return Ok(pontos);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult<IEnumerable<PontoDistribuicao>>> GetByTipo(Tipo tipo)
        {
            var pontos = await _pontoService.GetByTipoAsync(tipo);
            return Ok(pontos);
        }
    }
}
