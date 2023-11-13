using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Vendas
    {
        [Key]
        public int VendaId { get; set; }
        [Required]
        public List<Produto> Produtos { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

    }
}
