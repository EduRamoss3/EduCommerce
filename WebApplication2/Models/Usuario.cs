using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WebApplication2.Context;

namespace WebApplication2.Models
{
    public class Usuario
    {
      
        [Key]
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100,ErrorMessage = "O nome só permite 100 caracteres")]
        [DisplayName("Usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [MaxLength(14)]
        [MinLength(14)]
        public string CPF { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "No minimo 8 caracteres.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de nascimento")]
        public DateTime DateNasc { get; set; }
        public string IdCarrinho { get; set; }
        public virtual Carrinho _Carrinho { get; set; }
        public string Id_User { get; set; }   
        public List<Pedido> Pedidos { get; set; }
        public bool PasswordIsValid(string senha)
        {
            if (senha == Senha) { return true; }
            return false;
        }
    }
}
