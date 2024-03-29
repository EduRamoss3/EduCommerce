﻿using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.ViewModel
{
    public class PedidoViewModel
    {
        public Pedido _Pedido { get; set; }
        public PedidoDetalhe _PedidoDetalhe { get; set; }
        public List<Produto> _ProdutosPedido { get; set; } = new List<Produto>();
    }
}
