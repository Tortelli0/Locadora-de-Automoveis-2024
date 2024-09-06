using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class GrupoAutomoveisProfile : Profile
{
	public GrupoAutomoveisProfile()
	{
		CreateMap<InserirGrupoAutomoveisViewModel, GrupoAutomoveis>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<EditarGrupoAutomoveisViewModel, GrupoAutomoveis>();

		CreateMap<GrupoAutomoveis, ListarGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, DetalhesGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, EditarGrupoAutomoveisViewModel>();
	}
}
