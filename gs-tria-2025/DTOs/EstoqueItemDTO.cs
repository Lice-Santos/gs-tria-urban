using System.ComponentModel.DataAnnotations;

namespace gs_tria_2025.DTOs
{
    public class EstoqueItemDTO
    {
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a 0.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O ID do item é obrigatório.")]
        public int IdItem { get; set; }

        [Required(ErrorMessage = "O ID do ponto de distribuição é obrigatório.")]
        public int IdPontoDistribuicao { get; set; }
    }
}
