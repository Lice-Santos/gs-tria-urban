using gs_tria_2025.Models;
using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Enums;

namespace gs_tria_2025.Validations
{
    public static class PontoDistribuicaoValidation
    {
        public static void ValidarExistenciaEndereco(Endereco? endereco)
        {
            if (endereco == null)
                throw new ObjetoNaoEncontradoException("Endereco", "ponto de distribuição");
        }

        public static void ValidarExistenciaUsuario(Usuario? usuario)
        {
            if (usuario == null)
                throw new ObjetoNaoEncontradoException("Usuário", "ponto de distribuição");

        }

        public static void ValidarExistenciaPonto(PontoDistribuicao? ponto)
        {
            if (ponto == null)
                throw new ObjetoNaoEncontradoException("Ponto de distribuição não encontrado.", "operação");
        }

        public static void ValidarPonto(PontoDistribuicao? ponto)
        {
            if (ponto.Nome == null)
                throw new CampoVazioException("Nome");

            if (ponto.Tipo.Equals(""))
                throw new CampoVazioException("Tipo");

            if (ponto.Nome.Length < 1 || ponto.Nome.Length > 100)
            {
                throw new TamanhoInvalidoDeCaracteresException("Nome", 100, 1);
            }

            if (!Enum.IsDefined(typeof(Tipo), ponto.Tipo))
                throw new CampoInvalidoException("Tipo");
        }
    }
}
