using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class ItemCarrinho
    {
        [Key]
        public string IdItensCarrinho { get ; set; }    
        public Produto Produto { get; set; }
        [Required]
        [MaxLength(100)]
        public int QntProduto { get; set; }
        [ForeignKey(nameof(Carrinho))]   
        public string IdCarrinho { get; set; }
    }
}
