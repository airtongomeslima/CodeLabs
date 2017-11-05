using AutoMapper;
using ModeloDDD.Dominio.Entitades;
using ModeloDDD.DTO;

namespace ModeloDDD.Servicos.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
