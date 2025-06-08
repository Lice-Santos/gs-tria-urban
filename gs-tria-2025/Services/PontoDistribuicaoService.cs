using gs_tria_2025.DTOs;
using gs_tria_2025.Enums;
using gs_tria_2025.Models;
using gs_tria_2025.Repository;
using gs_tria_2025.Validations;

namespace gs_tria_2025.Services
{
    public class PontoDistribuicaoService
    {
        private readonly PontoDistribuicaoRepository _pontoRepository;
        private readonly EnderecoRepository _enderecoRepository;
        private readonly UsuarioRepository _usuarioRepository;

        // Construtor com injeção de dependências
        public PontoDistribuicaoService(
            PontoDistribuicaoRepository pontoRepository,
            EnderecoRepository enderecoRepository,
            UsuarioRepository usuarioRepository)
        {
            _pontoRepository = pontoRepository;
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetAllAsync()
        {
            return await _pontoRepository.GetAllAsync();
        }

        public async Task<PontoDistribuicao?> GetByIdAsync(int id)
        {
            return await _pontoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PontoDistribuicaoDTO dto)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(dto.IdEndereco);
            PontoDistribuicaoValidation.ValidarExistenciaEndereco(endereco);

            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            PontoDistribuicaoValidation.ValidarExistenciaUsuario(usuario);

            // nova entidade ponto de distribuição
            var ponto = new PontoDistribuicao
            {
                Tipo = dto.Tipo,
                Nome = dto.Nome,
                IdEndereco = dto.IdEndereco,
                IdUsuario = dto.IdUsuario
            };

            PontoDistribuicaoValidation.ValidarPonto(ponto);

            await _pontoRepository.AddAsync(ponto);
        }

        public async Task UpdateAsync(int id, PontoDistribuicaoDTO dto)
        {
            var pontoExistente = await _pontoRepository.GetByIdAsync(id);
            PontoDistribuicaoValidation.ValidarExistenciaPonto(pontoExistente);

            var endereco = await _enderecoRepository.GetByIdAsync(dto.IdEndereco);
            PontoDistribuicaoValidation.ValidarExistenciaEndereco(endereco);

            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            PontoDistribuicaoValidation.ValidarExistenciaUsuario(usuario);

            // Atualiza campos do ponto existente
            pontoExistente.Tipo = dto.Tipo;
            pontoExistente.Nome = dto.Nome;
            pontoExistente.IdEndereco = dto.IdEndereco;
            pontoExistente.IdUsuario = dto.IdUsuario;

            PontoDistribuicaoValidation.ValidarPonto(pontoExistente);

            await _pontoRepository.UpdateAsync(pontoExistente);
        }

        public async Task DeleteAsync(int id)
        {
            var ponto = await _pontoRepository.GetByIdAsync(id);
            PontoDistribuicaoValidation.ValidarExistenciaPonto(ponto);

            await _pontoRepository.DeleteAsync(ponto);
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetByNomeAsync(string nome)
        {
            return await _pontoRepository.GetByNomeAsync(nome);
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetByTipoAsync(Tipo tipo)
        {
            return await _pontoRepository.GetByTipoAsync(tipo);
        }
    }
}
