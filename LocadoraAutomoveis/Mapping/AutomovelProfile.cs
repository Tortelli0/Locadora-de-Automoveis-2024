using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class AutomovelProfile : Profile
{
	public AutomovelProfile()
	{
		CreateMap<InserirAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

		CreateMap<EditarAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

		CreateMap<Automovel, DetalhesAutomovelViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<Automovel, ListarAutomovelViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<Automovel, EditarAutomovelViewModel>()
			.ForMember(a => a.Foto, opt => opt.Ignore())
			.ForMember(a => a.GrupoAutomoveis, opt => opt.MapFrom<GrupoAutomoveisResolver>());
	}
}