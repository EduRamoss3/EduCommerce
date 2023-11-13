using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplication2.Models
{
    public class Usuario
    {
        [Key]
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100,ErrorMessage = "O nome só permite 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [MaxLength(15)]
        [MinLength(15)]
        public string CPF { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "No minimo 8 caracteres.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        [DataType(DataType.DateTime)]
        public DateTime DateNasc { get; set; }
        public string IdCarrinho { get; set; }
        public virtual Carrinho _Carrinho { get; set; }

    }
}
