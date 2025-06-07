using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gs_tria_2025.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Username { get; set; }
        public string NomeCompleto { get; set; }

        //chave estrangeira
        public int IdEndereco { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
    }
}
