using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs_tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueItemController : ControllerBase
    {
        private readonly EstoqueItemService _estoqueService;

        // Injeção de dependência do serviço de estoque
        public EstoqueItemController(EstoqueItemService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        //busca todos os estoques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstoqueItem>>> GetAll()
        {
            var estoques = await _estoqueService.GetAllAsync();
            return Ok(estoques);
        }

        //busca estoque pelo id
        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueItem>> GetById(int id)
        {
            var estoque = await _estoqueService.GetByIdAsync(id);
            if (estoque == null)
                return NotFound("Estoque não encontrado.");

            return Ok(estoque);
        }

        //busca pelo id do item em um estoque
        [HttpGet("item/{idItem}")]
        public async Task<ActionResult<IEnumerable<EstoqueItem>>> GetByItem(int idItem)
        {
            var estoques = await _estoqueService.GetByItemAsync(idItem);
            return Ok(estoques);
        }

        //busca pelo id do item em um ponto de distribuição

        [HttpGet("ponto/{idPonto}")]
        public async Task<ActionResult<IEnumerable<EstoqueItem>>> GetByPontoDistribuicao(int idPonto)
        {
            var estoques = await _estoqueService.GetByPontoDistribuicaoAsync(idPonto);
            return Ok(estoques);
        }

        //post

        [HttpPost]
        public async Task<ActionResult> Post(EstoqueItemDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _estoqueService.AddAsync(dto);
                return Ok("Estoque criado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CampoVazioException ex) {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });

            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });

            }
        }

        //put

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EstoqueItemDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _estoqueService.UpdateAsync(id, dto);
                return Ok("Estoque atualizado com sucesso.");
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });

            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //deleta por id

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _estoqueService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
