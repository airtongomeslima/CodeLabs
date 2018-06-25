using API.Data.SqlServer.Entities;
using API.Domain.Infrastructure.Data.Interfaces;
using API.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.Repositories
{
    public class ArquiteturaExemploRepository : IArquiteturaExemploRepository
    {
        readonly ITesteUnitOfWork _TesteUnitOfWork;

        public ArquiteturaExemploRepository(ITesteUnitOfWork TesteUnitOfWork)
        {
            _TesteUnitOfWork = TesteUnitOfWork;
        }

        public void AdicionarExemplo(ArquiteturaExemplo arquiteturaExemplo) => _TesteUnitOfWork.ArquiteturaExemploRepository.Add(arquiteturaExemplo);

        public void AtualizarExemplo(ArquiteturaExemplo arquiteturaExemplo) => _TesteUnitOfWork.ArquiteturaExemploRepository.Update(arquiteturaExemplo);

        public ArquiteturaExemplo BuscarExemploPorId(int id)
        {
            var arquiteturaExemplo = _TesteUnitOfWork.ArquiteturaExemploRepository.Queryable?
                                        .Where(_ => _.Id == id)?
                                        .FirstOrDefault();

            return arquiteturaExemplo;
        }

        public IList<ArquiteturaExemplo> BuscarTodosExemplos()
        {
            var exemplos = _TesteUnitOfWork.ArquiteturaExemploRepository.Queryable?
                                        .ToList();

            return exemplos;
        }

        public void ExcluirExemploPorId(int id)
        {
            var arquiteturaExemplo = BuscarExemploPorId(id);

            if (arquiteturaExemplo == null)
                throw new Exception("Arquitetura exemplo não existe na base de dados");

            _TesteUnitOfWork.ArquiteturaExemploRepository.Delete(arquiteturaExemplo);
        }

        public async Task SalvarAlteracoesAsync() => await _TesteUnitOfWork.CommitAsync();
    }
}
