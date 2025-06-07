using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;

namespace gs_tria_2025.Validations
{
    public static class ItemValidation
    {
        public static void ValidarCamposObrigatorios(Item item)
        {

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                throw new CampoVazioException("Nome");
            }

            if (string.IsNullOrWhiteSpace(item.Categoria))
            {
                throw new CampoVazioException("Categoria");
            }


            if (item.Nome.Length < 1 || item.Nome.Length > 100)
            {
                throw new TamanhoInvalidoDeCaracteresException("Nome", 100, 1);
            }

            if (item.Categoria.Length < 1 || item.Categoria.Length > 50)
            {
                throw new TamanhoInvalidoDeCaracteresException("Categoria", 50, 1);
            }
        }

        public static void ValidarItemExistenteParaAtualizacao(Item? item)
        {
            if (item == null)
            {
                throw new ObjetoNaoEncontradoException("Item", "atualização");
            }
            ValidarCamposObrigatorios(item);
        }

        public static void ValidarItemExistenteParaExclusao(Item? item)
        {
            if (item == null)
            {
                throw new ObjetoNaoEncontradoException("Item", "exclusão");
            }
        }
    }
}
