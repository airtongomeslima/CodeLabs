using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Entidades
{
    public class Cliente
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

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
