using System.Runtime.ConstrainedExecution;
using gs_tria_2025.Models;
using gs_tria_2025.Repository;
using gs_tria_2025.Validations;

namespace gs_tria_2025.Services
{
    public class EnderecoService
    {
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoService(EnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            return await _enderecoRepository.GetAllAsync();
        }

        public async Task<Endereco?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _enderecoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Endereco endereco)
        {
            EnderecoValidation.ValidarEndereco(endereco);

            var existente = await _enderecoRepository.GetByCepAsync(endereco.Cep);
            if (existente != null)
            {
                throw new ArgumentException("Endereço com este CEP já existe.");
            }

            await _enderecoRepository.AddAsync(endereco);
        }


        public async Task UpdateAsync(Endereco endereco)
        {

            var existente = await _enderecoRepository.GetByIdAsync(endereco.Id);
            if (existente == null)
            {
                throw new ArgumentException("Endereço não encontrado para atualização.");
            }
            EnderecoValidation.ValidarEndereco(endereco);

            existente.Logradouro = endereco.Logradouro;
            existente.Numero = endereco.Numero;
            existente.Cep = endereco.Cep;
            existente.Cidade = endereco.Cidade;
            existente.Bairro = endereco.Bairro;
            existente.Uf = endereco.Uf;
            existente.Complemento = endereco.Complemento;

            await _enderecoRepository.UpdateAsync(existente);
        }

        public async Task DeleteAsync(Endereco endereco)
        {
            var existente = await _enderecoRepository.GetByIdAsync(endereco.Id);
            if (existente == null)
            {
                throw new ArgumentException("Endereço não encontrado para exclusão.");
            }
            await _enderecoRepository.DeleteAsync(endereco);
        }

        public async Task<IEnumerable<Endereco>> GetByLogradouroAsync(string logradouro)
        {
            if (logradouro == "")
            {
                throw new ArgumentException("O logradouro não pode estar vazio.");
            }
            return await _enderecoRepository.GetByLogradouroAsync(logradouro);
        }

        public async Task<Endereco> GetByCepAsync(string cep)
        {
            EnderecoValidation.ValidarCep(cep);
            return await _enderecoRepository.GetByCepAsync(cep.Replace("-", "").Replace("/", "").Trim());
        }


        public async Task<IEnumerable<Endereco>> FiltrarAsync(string cidade)
        {
            if (cidade == "")
            {
                throw new ArgumentException("Nenhuma cidade passada.");
            }
            return await _enderecoRepository.FiltrarAsync(cidade);
        }
    }
}
