using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}