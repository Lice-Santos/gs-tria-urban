using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace gs_tria_2025.Models
{
    public class EstoqueItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
        //chave estrangeira
        public int IdItem { get; set; }
        public int IdPontoDistribuicao { get; set; }
        [JsonIgnore]
        public virtual Item Item { get; set; }
        [JsonIgnore]
        public virtual PontoDistribuicao PontoDistribuicao { get; set; }


    }
}
