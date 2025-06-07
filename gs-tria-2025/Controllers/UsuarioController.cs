using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace gs_tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;



        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            return Ok(await _usuarioService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                var u = await _usuarioService.GetByIdAsync(id);
                if (u == null) return NotFound("Usuário não encontrado.");
                return Ok(u);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsuarioDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var criado = await _usuarioService.AddUsuarioAsync(dto);
                return CreatedAtAction(nameof(GetById),new { id = criado.Id }, criado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _usuarioService.UpdateUsuarioAsync(id, dto);
                return NoContent();
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }

            catch (TamanhoInvalidoDeCaracteresException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (CampoVazioException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.DeleteAsync(id);
                return NoContent();
            }
            catch (ObjetoNaoEncontradoException ex)
            {
                return NotFound(new { StatusCode = 404, ex.Message });
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetByNome(string nome)
            => Ok(await _usuarioService.GetByNomeAsync(nome));

        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetByUsername(string username)
            => Ok(await _usuarioService.FiltrarUsernameAsync(username));
    }
}
