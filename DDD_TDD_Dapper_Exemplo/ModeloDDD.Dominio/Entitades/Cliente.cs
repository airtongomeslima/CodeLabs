using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDDD.Dominio.Entitades
{
    [Table("", Schema = "")]
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string SobreNome { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string CPF { get; set; }
    }
}
