using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class AutomovelProfile : Profile
{
	public AutomovelProfile()
	{
		CreateMap<InserirAutomovelViewModel, Automovel>();
		CreateMap<EditarAutomovelViewModel, Automovel>();

		CreateMap<Automovel, DetalhesAutomovelViewModel>()
			.ForMember(
				dest => dest.GrupoAutomoveis,
				opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
			);

		CreateMap<Automovel, ListarAutomovelViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis,
				opt => opt.MapFrom(src => src.GrupoAutomoveis.Nome));

		CreateMap<Automovel, EditarAutomovelViewModel>();
	}
}
