using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using gs_tria_2025.Repository;
using gs_tria_2025.Validations;

namespace gs_tria_2025.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EnderecoRepository _enderecoRepository;

        public UsuarioService(UsuarioRepository usuarioRepository,
                              EnderecoRepository enderecoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> AddUsuarioAsync(UsuarioDTO dto)
        {
 

            var lista = await _usuarioRepository.FiltrarUsernameAsync(dto.Username);
            if (lista.Any())
                throw new CampoJaExistenteException("Username");

            var endereco = await _enderecoRepository.GetByIdAsync(dto.IdEndereco);
            if (endereco == null)
                throw new ObjetoNaoEncontradoException("Endereço", "vinculação ao usuário");

            var usuario = new Usuario
            {
                NomeCompleto = dto.NomeCompleto,
                Username = dto.Username,
                Email = dto.Email,
                Senha = dto.Senha,
                IdEndereco = dto.IdEndereco,
                Endereco = endereco
            };

            UsuarioValidation.ValidarUsuario(usuario);

            await _usuarioRepository.AddUsuarioAsync(usuario);
            return usuario;
        }

        public async Task UpdateUsuarioAsync(int id, UsuarioDTO dto)
        {
            var existente = await _usuarioRepository.GetByIdAsync(id);
            UsuarioValidation.ValidarUsuarioExistenteParaAtualizacao(existente);

            var endereco = await _enderecoRepository.GetByIdAsync(dto.IdEndereco);
            if (endereco == null)
                throw new ObjetoNaoEncontradoException("Endereço", "vinculação ao usuário");

            existente.NomeCompleto = dto.NomeCompleto;
            existente.Username = dto.Username;
            existente.Email = dto.Email;
            existente.Senha = dto.Senha;
            existente.IdEndereco = dto.IdEndereco;
            existente.Endereco = endereco;

            UsuarioValidation.ValidarUsuario(existente);


            await _usuarioRepository.UpdateAsync(existente);
        }

        public async Task DeleteAsync(int id)
        {
            var existente = await _usuarioRepository.GetByIdAsync(id);
            UsuarioValidation.ValidarUsuarioExistenteParaExclusao(existente);
            await _usuarioRepository.DeleteAsync(existente);
        }

        public async Task<IEnumerable<Usuario>> GetByNomeAsync(string nome)
            => await _usuarioRepository.GetByNomeAsync(nome);

        public async Task<IEnumerable<Usuario>> FiltrarUsernameAsync(string username)
            => await _usuarioRepository.FiltrarUsernameAsync(username);
    }
}
