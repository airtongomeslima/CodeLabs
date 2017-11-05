using AutoMapper;
using ModeloDDD.Dominio.Entitades;
using ModeloDDD.DTO;

namespace ModeloDDD.Servicos.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
