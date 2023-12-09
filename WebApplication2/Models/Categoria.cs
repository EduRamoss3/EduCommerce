using System.ComponentModel.DataAnnotations;
using WebApplication2.Enums;

namespace WebApplication2.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string CategoriaNome { get; set; }
        public Tipo Tipos { get; set; }
    }
}
