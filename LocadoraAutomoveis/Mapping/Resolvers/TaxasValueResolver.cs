using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class TaxasValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioTaxa repositorioTaxa;

    public TaxasValueResolver(IRepositorioTaxa repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        return repositorioTaxa
            .SelecionarTodos()
            .Select(t => new SelectListItem(t.ToString(), t.Id.ToString()));
    }
}