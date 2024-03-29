﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Pedido
    {
        [Key]
        [DisplayName("Identificador do pedido")]
        public int IdPedido { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório!")]

        public string Nome { get; set; }
        [DisplayName("Data do pedido")]
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
        [DisplayName("Total de itens do pedido")]
        public int TotalItensPedido { get; set; }
        [DisplayName("Total do pedido")]
        public double TotalPedido { get; set; }
        [DisplayName("Preparo do pedido")]
        public bool Concluido { get; set; }
        [DisplayName("Entrega do pedido")]
        public bool Entregue { get; set; }
        [DisplayName("Identificador do Cliente")]
        public string Id_User { get; set; }
        public List<PedidoDetalhe> _PedidoDetalhes { get; set; }
        public Usuario _Cliente { get; set; }
        [DisplayName("Conjunto de ID's dos produtos")]
        public string strPedidos { get; set; }

    }
}
