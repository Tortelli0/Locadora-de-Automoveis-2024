using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class CondutorProfile : Profile
{
    public CondutorProfile()
    {
        CreateMap<FormularioCondutorViewModel, Condutor>();

        CreateMap<Condutor, ListarCondutorViewModel>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
            .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));

        CreateMap<Condutor, DetalhesCondutorViewModel>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
            .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));
    }
}