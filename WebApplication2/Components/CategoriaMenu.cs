using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaMenu(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaService.GetAllCategorias();
            CategoriaViewModel categoriaViewModel = new CategoriaViewModel()
            {
                Categorias = categorias
            };
            return View(categoriaViewModel);
        }
    }
}
