using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;

namespace gs_tria_2025.Validations
{
    public static class EnderecoValidation
    {
        public static void ValidarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new CampoVazioException("CEP");
            }

            string cepCorrigido = cep.Replace("-", "").Replace("/", "").Trim();
            if (cepCorrigido.Length != 8 || !cepCorrigido.All(char.IsDigit))
            {
                throw new CepForaFormatacao();
            }
        }

        public static void ValidarEndereco(Endereco endereco)
        {
            ValidarCep(endereco.Cep);
            ValidarLogradouro(endereco.Logradouro);
            ValidarCidade(endereco.Cidade);
            ValidarNumero(endereco.Numero);
            ValidarUf(endereco.Uf);
        }


        public static void ValidarLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
            {
                throw new CampoVazioException("Logradouro");
            }

            if (logradouro.Length < 3 || logradouro.Length > 100)
            {
                throw new TamanhoInvalidoDeCaracteresException("Logradouro", 100, 3);
            }
        }

        public static void ValidarCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                throw new CampoVazioException("Cidade");
            }

            if (cidade.Length < 2 || cidade.Length > 80)
            {
                throw new TamanhoInvalidoDeCaracteresException("Cidade", 80, 2);
            }
        }

        public static void ValidarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
            {
                throw new CampoVazioException("Número");
            }

            if (numero.Length == 0 || numero.Length > 10)
            {
                throw new TamanhoInvalidoDeCaracteresException("Número", 10, 1);
            }
        }

        public static void ValidarUf(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf))
            {
                throw new CampoVazioException("UF");
            }

            if (uf.Length != 2 || !uf.All(char.IsLetter))
            {
                throw new CampoTamanhoInvalidoException("UF", 2);
            }
        }
    }
}
