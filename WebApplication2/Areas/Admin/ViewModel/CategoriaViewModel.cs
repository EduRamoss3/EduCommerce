using WebApplication2.Migrations;
using WebApplication2.Models;
using Categoria = WebApplication2.Models.Categoria;

namespace WebApplication2.Areas.Admin.ViewModel
{
    public class CategoriaViewModel
    {
        public Categoria _Categoria { get; set; }
        public List<Categoria> ListNomes{ get; set; }
    }
}
