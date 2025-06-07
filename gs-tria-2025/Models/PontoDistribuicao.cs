using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using gs_tria_2025.Enums;

namespace gs_tria_2025.Models
{
    public class PontoDistribuicao
    {
        [Key]
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
        public string Nome { get; set; }
        //chave estrangeira
        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
