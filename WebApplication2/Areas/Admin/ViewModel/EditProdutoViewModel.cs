using WebApplication2.Models;

namespace EduCommerceWeb.Areas.Admin.ViewModel
{
    public class EditProdutoViewModel
    {
        public Produto Produto { get; set; }
        public IEnumerable<Categoria> ListCategorias { get; set; }
    }
}
