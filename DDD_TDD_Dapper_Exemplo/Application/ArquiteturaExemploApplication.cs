using API.Data.SqlServer.Entities;
using API.DTO;
using API.Services.Facades.Interfaces;
using API.Services.Interfaces;
using Teste.Services.Entity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public class ArquiteturaExemploApplication
    {
        readonly IArquiteturaExemploService _arquiteturaExemploService;
        readonly IArquiteturaExemploIntegracaoLegadoFacade _arquiteturaExemploIntegracaoLegadoFacade;

        public ArquiteturaExemploApplication(IArquiteturaExemploService arquiteturaExemploService,
            IArquiteturaExemploIntegracaoLegadoFacade arquiteturaExemploIntegracaoLegadoFacade)
        {
            _arquiteturaExemploService = arquiteturaExemploService;
            _arquiteturaExemploIntegracaoLegadoFacade = arquiteturaExemploIntegracaoLegadoFacade;
        }

        public async Task AdicionarExemplo(ArquiteturaExemploDto arquiteturaExemploDto) => 
            await _arquiteturaExemploService.AdicionarExemplo(arquiteturaExemploDto.Nome, arquiteturaExemploDto.Descricao);

        public async Task AtualizarExemplo(ArquiteturaExemploDto arquiteturaExemploDto) => 
            await _arquiteturaExemploService.AtualizarExemplo(arquiteturaExemploDto.Id, arquiteturaExemploDto.Nome, arquiteturaExemploDto.Descricao);

        public ArquiteturaExemploDto BuscarExemploPorId(int id)
        {
            var arquiteturaExemplo = _arquiteturaExemploService.BuscarExemploPorId(id);

            return Map(arquiteturaExemplo);
        }

        public IList<ArquiteturaExemploDto> BuscarTodosExemplos()
        {
            var exemplos = _arquiteturaExemploService.BuscarTodosExemplos();

            var exemplosDto = new List<ArquiteturaExemploDto>();

            foreach (var item in exemplos)
                exemplosDto.Add(Map(item));

            return exemplosDto;
        }

        public async Task ExcluirExemploPorId(int id) => await _arquiteturaExemploService.ExcluirExemploPorId(id);

        public ClientInfo BuscarClientePorId(int id) => _arquiteturaExemploIntegracaoLegadoFacade.BuscarClientePorId(id);

        public ArquiteturaExemploDto Map(ArquiteturaExemplo arquiteturaExemplo)
        {
            var mapeamento = new ArquiteturaExemploDto
            {
                Id = arquiteturaExemplo.Id,
                Nome = arquiteturaExemplo.Nome,
                Descricao = arquiteturaExemplo.Descricao
            };

            return mapeamento;
        }
    }
}
