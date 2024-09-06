using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraAutomoveis.WebApp.Models;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<InserirFuncionarioViewModel, Funcionario>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Funcionario, ListarFuncionarioViewModel>();
    }
}