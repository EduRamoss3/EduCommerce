namespace WebApplication2.Models
{
    public class Pessoa
    {
        public int ID { get; set; }    
        public string? Nome { get; set; }
        public string? CPF { get; set; } 
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public DateTime DateNasc { get; set; }

    }
}
