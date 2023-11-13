using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Enums;

namespace WebApplication2.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(100,ErrorMessage = "O Tamanho máximo do nome é de 100 caractéres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O preço é requerido!")]
        [MaxLength(100000)]
        public double Preco { get; set; }
        [Required(ErrorMessage ="A data do produto é obrigátoria!")]
        public DateTime DataEntrada { get; set; }
        [Required]
        public Tipo Tipos { get; set; }
        [Required(ErrorMessage = " A quantidade de produtos não pode ser 0")]
        [MaxLength(999)]
        public int Quantidade { get; set; }
        public string ImagemUrl { get; set; }
        [Required(ErrorMessage = " A descrição é obrigatória!")]
        [MaxLength(208)]
        [MinLength(208)]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "'De - por' é obrigatório!")]
        public decimal AntigoPreco { get; set; }
        [Required(ErrorMessage = "Preço À vista é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AVista { get; set; }
        [Required(ErrorMessage = "Preço secundário é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoSecundario { get; set; }
        [Required(ErrorMessage = "Máxima de parcelas é obrigatória!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal MaxVezes { get; set; }
        public Produto(int idProduto, string nome, double preco, DateTime dataEntrada, Tipo tipos, int quantidade, string imagemUrl, string descricaoCurta, decimal antigoPreco, decimal aVista, decimal precoSecundario, decimal maxVezes)
        {
            IdProduto = idProduto;
            Nome = nome;
            Preco = preco;
            DataEntrada = dataEntrada;
            Tipos = tipos;
            Quantidade = quantidade;
            ImagemUrl = imagemUrl;
            DescricaoCurta = descricaoCurta;
            AntigoPreco = antigoPreco;
            AVista = aVista;
            PrecoSecundario = precoSecundario;
            MaxVezes = maxVezes;
        }

        public Produto( string nome, double preco, DateTime dataEntrada, Tipo tipos, int quantidade, string imagemUrl, string descricaoCurta, decimal antigoPreco, decimal aVista, decimal precoSecundario, decimal maxVezes)
        {
            Nome = nome;
            Preco = preco;
            DataEntrada = dataEntrada;
            Tipos = tipos;
            Quantidade = quantidade;
            ImagemUrl = imagemUrl;
            DescricaoCurta = descricaoCurta;
            AntigoPreco = antigoPreco;
            AVista = aVista;
            PrecoSecundario = precoSecundario;
            MaxVezes = maxVezes;
        }

    }
}

