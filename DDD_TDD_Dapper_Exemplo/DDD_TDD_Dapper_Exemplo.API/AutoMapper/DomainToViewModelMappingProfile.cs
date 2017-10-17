using AutoMapper;
using DDD_TDD_Dapper_Exemplo.API.Models;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;

namespace DDD_TDD_Dapper_Exemplo.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteModel>();
            CreateMap<Produto, ProdutoModel>();
        }
    }
}
