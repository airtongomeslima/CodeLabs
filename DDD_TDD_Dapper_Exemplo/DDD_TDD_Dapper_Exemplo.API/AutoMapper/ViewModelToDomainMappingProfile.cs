using AutoMapper;
using DDD_TDD_Dapper_Exemplo.API.Models;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;

namespace DDD_TDD_Dapper_Exemplo.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteModel, Cliente>();
            CreateMap<ProdutoModel, Produto>();
        }
    }
}
