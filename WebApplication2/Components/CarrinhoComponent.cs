using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Components
{
    public class CarrinhoComponent  : ViewComponent
    {
        private readonly Carrinho _carrinho;
        public CarrinhoComponent(Carrinho carrinho)
        {
            _carrinho = carrinho;
        }   
        public IViewComponentResult Invoke()
        {
            var itens = _carrinho.GetItemCarrinhos();
            _carrinho.ItensCarrinhos = itens;
            var carrinhoVM = new CarrinhoViewModel
            {
                CarrinhoCompra = _carrinho,
                CarrinhoCompraTotal = _carrinho.GetTotalCarrinho()
            };
            return View(carrinhoVM);
        }
    }
      
}
