using gs_tria_2025.DTOs;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;

namespace gs_tria_2025.Validations
{
    public static class EstoqueItemValidation
    {
        public static void ValidarExistenciaItem(Item? item)
        {
            if (item == null)
                throw new ObjetoNaoEncontradoException("Item", "operação");

        }

        public static void ValidarExistenciaPonto(PontoDistribuicao? ponto)
        {
            if (ponto == null)
                throw new ObjetoNaoEncontradoException("Ponto de Distribuição", "operação");
        }

        public static void ValidarExistenciaEstoque(EstoqueItem? estoque)
        {
            if (estoque == null)
                throw new ObjetoNaoEncontradoException("Estoque", "operação");

        }

        public static void ValidarEstoque(EstoqueItemDTO estoque)
        {
            if (estoque.Quantidade == 0)
            {
                throw new CampoVazioException("Quantidade");
            }
        }
    }
}
