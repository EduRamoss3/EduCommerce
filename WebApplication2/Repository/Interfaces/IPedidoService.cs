﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface IPedidoService
    {
        Task<ActionResult> CriarPedido(Pedido pedido);
        Task<ActionResult> VerificarPedido(int id);
        PedidoDetalhe DetalhePedido(int id);
        List<Produto> ProdutosPedido(int id);
        Task<ActionResult<Pedido>> Update(int id, Pedido pedido);
        Task<ActionResult<Pedido>> GetById(int id);
        Task<ActionResult<Pedido>> Delete(int id);
        Task<ActionResult<IEnumerable<Pedido>>> GetAll();
    }
}
