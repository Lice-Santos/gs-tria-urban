using System.ComponentModel.DataAnnotations;

namespace gs_tria_2025.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }

    }
}
