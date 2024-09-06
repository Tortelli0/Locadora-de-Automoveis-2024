using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class ConfiguracaoCombustivelProfile : Profile
{
    public ConfiguracaoCombustivelProfile()
    {
        CreateMap<FormularioConfiguracaoCombusitvelViewModel, ConfiguracaoCombustivel>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<ConfiguracaoCombustivel, FormularioAutomovelViewModel>();
    }
}