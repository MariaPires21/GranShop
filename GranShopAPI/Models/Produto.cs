using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public decimal ValorCusto { get; set; }

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public Boolean Destaque { get; set; }
    }
}