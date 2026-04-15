using System.ComponentModel.DataAnnotations;

namespace CashFlow.Web.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        
        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public DateTime DataMovimento { get; set; }
    }
}
