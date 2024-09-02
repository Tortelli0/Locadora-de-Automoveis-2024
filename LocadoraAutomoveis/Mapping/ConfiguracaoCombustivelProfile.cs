using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class ConfiguracaoCombustivelProfile : Profile
{
    public ConfiguracaoCombustivelProfile()
    {
        CreateMap<FormularioConfiguracaoCombusitvelViewModel, ConfiguracaoCombustivel>();
        CreateMap<ConfiguracaoCombustivel, FormularioAutomovelViewModel>();
    }
}