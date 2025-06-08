using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs_tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        // Injeção de dependência do serviço de item

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        //busca todos os itens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            var itens = await _itemService.GetAllAsync();
            return Ok(itens);
        }

        //busca item por id

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
                return NotFound("Item não encontrado.");

            return Ok(item);
        }

        //busca item por nome
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetByNome(string nome)
        {
            var itens = await _itemService.GetByNomeAsync(nome);
            return Ok(itens);
        }

        //busca todos os itens de uma categoria
        [HttpGet("categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetByCategoria(string categoria)
        {
            var itens = await _itemService.GetByCategoriaAsync(categoria);
            return Ok(itens);
        }

        //post
        [HttpPost]
        public async Task<ActionResult> Post(Item item)
        {
            try
            {
                await _itemService.AddAsync(item);
                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new{StatusCode = 404, Message = ex.Message});
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro interno no servidor." });
            }
        }

        //atualiza item
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Item item)
        {
            if (id != item.Id)
                return BadRequest("ID da URL não corresponde ao do corpo da requisição.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _itemService.UpdateAsync(item);
                return NoContent();
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        //deleta por id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
                return NotFound("Item não encontrado.");

            await _itemService.DeleteAsync(item);
            return NoContent();
        }
    }
}
