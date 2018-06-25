using API.Data.SqlServer.Entities;
using API.Domain.Repositories.Interfaces;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ArquiteturaExemploService : IArquiteturaExemploService
    {
        readonly IArquiteturaExemploRepository _arquiteturaExemploRepository;

        public ArquiteturaExemploService(IArquiteturaExemploRepository arquiteturaExemploRepository)
        {
            _arquiteturaExemploRepository = arquiteturaExemploRepository;
        }

        public async Task AdicionarExemplo(string nome, string descricao)
        {
            var arquiteturaExemplo = new ArquiteturaExemplo(nome, descricao);

            if (!arquiteturaExemplo.ValidarNovoCadastro())
                throw new Exception("Não foi possível realizar novo cadastro! Insira os campos corretamente");

            _arquiteturaExemploRepository.AdicionarExemplo(arquiteturaExemplo);

            await _arquiteturaExemploRepository.SalvarAlteracoesAsync();
        }

        public async Task AtualizarExemplo(int id, string nome, string descricao)
        {
            var arquiteturaExemplo = new ArquiteturaExemplo(id, nome, descricao);

            if (!arquiteturaExemplo.ValidarAtualizacaoDoExemplo())
                throw new Exception("Não foi possível realizar a atualização! Insira os campos corretamente");

            _arquiteturaExemploRepository.AtualizarExemplo(arquiteturaExemplo);

            await _arquiteturaExemploRepository.SalvarAlteracoesAsync();
        }

        public ArquiteturaExemplo BuscarExemploPorId(int id)
        {
            return _arquiteturaExemploRepository.BuscarExemploPorId(id);
        }

        public IList<ArquiteturaExemplo> BuscarTodosExemplos()
        {
            return _arquiteturaExemploRepository.BuscarTodosExemplos();
        }

        public async Task ExcluirExemploPorId(int id)
        {
            _arquiteturaExemploRepository.ExcluirExemploPorId(id);

            await _arquiteturaExemploRepository.SalvarAlteracoesAsync();
        }
    }
}
