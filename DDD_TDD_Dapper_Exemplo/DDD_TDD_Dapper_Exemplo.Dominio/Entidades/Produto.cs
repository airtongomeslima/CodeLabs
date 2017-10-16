using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Entidades
{
    public class Produto
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

        [ForeignKey("ClientId")]
        public virtual Cliente Cliente { get; set; }
    }
}
