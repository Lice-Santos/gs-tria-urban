using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;

namespace gs_tria_2025.Validations
{
    public static class UsuarioValidation
    {
        public static void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new CampoVazioException("Email");
            if (usuario.Email.Length > 80)
                throw new TamanhoInvalidoDeCaracteresException("Email", 80, 1);

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new CampoVazioException("Senha");
            if (usuario.Senha.Length > 30)
                throw new TamanhoInvalidoDeCaracteresException("Senha", 30, 1);

            if (string.IsNullOrWhiteSpace(usuario.Username))
                throw new CampoVazioException("Username");
            if (usuario.Username.Length > 30)
                throw new TamanhoInvalidoDeCaracteresException("Username", 30, 1);

            if (string.IsNullOrWhiteSpace(usuario.NomeCompleto))
                throw new CampoVazioException("Nome completo");
            if (usuario.NomeCompleto.Length > 150)
                throw new TamanhoInvalidoDeCaracteresException("Nome completo", 150, 1);
        }

        public static void ValidarUsuarioExistenteParaAtualizacao(Usuario usuario)
        {
            if (usuario == null)
                throw new ObjetoNaoEncontradoException("Usuário", "atualização");
        }

        public static void ValidarUsuarioExistenteParaExclusao(Usuario usuario)
        {
            if (usuario == null)
                throw new ObjetoNaoEncontradoException("Usuário", "exclusão");
        }
    }
}
