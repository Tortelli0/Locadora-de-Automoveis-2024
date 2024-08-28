using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class AutomovelProfile : Profile
{
	public AutomovelProfile()
	{
		CreateMap<InserirAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.Foto, 
				opt => opt.MapFrom<FotoValueResolver>());

		CreateMap<EditarAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.Foto, 
				opt => opt.MapFrom<FotoValueResolver>());

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

public class FotoValueResolver : IValueResolver<FormularioAutomovelViewModel, Automovel, byte[]>
{
	public FotoValueResolver() { }

	public byte[] Resolve(FormularioAutomovelViewModel source, Automovel destination, byte[] destMember, ResolutionContext context)
	{
		using (var memoryStream = new MemoryStream())
		{
			source.Foto.CopyTo(memoryStream);

			return memoryStream.ToArray();
		}
	}
}