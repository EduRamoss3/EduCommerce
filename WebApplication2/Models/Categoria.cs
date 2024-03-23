using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Categoria
    {
        [Key]
        [DisplayName("Identificador da Categoria")]
        public int IdCategoria { get; set; }
        [DisplayName("Nome da Categoria")]
        [Required]
        public string CategoriaNome { get; set; }
    }
}
