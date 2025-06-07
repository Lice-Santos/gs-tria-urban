using gs_tria_2025.Enums;
using System.ComponentModel.DataAnnotations;

namespace gs_tria_2025.DTOs
{
    public class PontoDistribuicaoDTO
    {
        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(250, ErrorMessage = "O nome pode ter no máximo 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O ID do endereço é obrigatório.")]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int IdUsuario { get; set; }
    }
}
