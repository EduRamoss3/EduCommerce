using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface IPedidoService
    {
        bool CriarPedido(Pedido pedido);
        Pedido VerificarPedido(int id);
    }
}
