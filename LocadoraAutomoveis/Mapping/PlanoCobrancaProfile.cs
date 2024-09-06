using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class PlanoCobrancaProfile : Profile
{
    public PlanoCobrancaProfile()
    {
		CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

		CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>()
			.ForMember(dest => dest.GruposAutomoveis, opt => opt.MapFrom<GrupoAutomoveisResolver>());
    }
}