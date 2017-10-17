using System.ComponentModel.DataAnnotations;

namespace DDD_TDD_Dapper_Exemplo.API.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        
        public virtual ClienteModel Cliente { get; set; }
    }
}
