using AutoMapper;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Entities;

namespace DDDSample.Application.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RamoAtividade, RamoAtividadeViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Dependente, DependenteViewModel>().ReverseMap();
        }
    }
}
