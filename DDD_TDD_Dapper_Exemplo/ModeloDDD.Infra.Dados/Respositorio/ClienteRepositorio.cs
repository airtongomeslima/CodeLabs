using Microsoft.Extensions.Configuration;
using ModeloDDD.Dominio.Entitades;
using ModeloDDD.Dominio.Interfaces.Repositorios;

namespace ModeloDDD.Infra.Dados.Respositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(IConfiguration config) : base(config)
        {
        }
    }
}
