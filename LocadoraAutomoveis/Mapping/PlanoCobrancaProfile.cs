using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class PlanoCobrancaProfile : Profile
{
    public PlanoCobrancaProfile()
    {
		CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>();
		CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

		CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
			.ForMember(
			dest => dest.GrupoAutomoveis,
			opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
			.ForMember(
			dest => dest.GrupoAutomoveis,
			opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

		CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>();
    }
}