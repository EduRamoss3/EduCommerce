using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string CategoriaNome { get; set; }
    }
}
