using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD_TDD_Dapper_Exemplo.API.Models
{
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Sobrenome { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public bool Ativo { get; set; }
        
        // public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
