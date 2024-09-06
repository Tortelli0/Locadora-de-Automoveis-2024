using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class TaxaProfile : Profile
{
	public TaxaProfile()
	{
		CreateMap<InserirTaxaViewModel, Taxa>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<EditarTaxaViewModel, Taxa>();

		CreateMap<Taxa, ListarTaxaViewModel>()
			.ForMember(
				dest => dest.TipoCobranca,
				opt => opt.MapFrom(x => x.TipoCobranca.ToString())
			);

		CreateMap<Taxa, DetalhesTaxaViewModel>()
			.ForMember(
				dest => dest.TipoCobranca,
				opt => opt.MapFrom(x => x.TipoCobranca.ToString())
			);

		CreateMap<Taxa, EditarTaxaViewModel>();
	}
}
