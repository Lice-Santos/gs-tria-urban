using System.ComponentModel.DataAnnotations;

namespace gs_tria_2025.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }

    }
}
