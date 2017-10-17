using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;

namespace DDD_TDD_Dapper_Exemplo.Infra.Dados.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(IConfiguration config) : base(config)
        {
        }

    }
}
