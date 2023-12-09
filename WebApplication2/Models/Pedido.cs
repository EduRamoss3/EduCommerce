using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório!")]
        public string Nome { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "O pedido deve conter o endereço!")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O pedido deve conter o número da residência!")]
        [Range(1,999,ErrorMessage ="O número deve ser entre 1 e 999")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O pedido deve conter o telefone!")]
        public string Telefone { get; set; }
        public List<ItemCarrinho> ProdutosPedido { get; set; }
        [Required]
        public int TotalItensPedido { get; set; }
        public double TotalPedido { get; set; }
        public List<PedidoDetalhe> _PedidoDetalhes { get; set; }

    }
}
