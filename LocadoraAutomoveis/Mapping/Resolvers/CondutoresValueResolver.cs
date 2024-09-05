using AutoMapper;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class CondutoresValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioCondutor repositorioCondutor;

    public CondutoresValueResolver(IRepositorioCondutor repositorioCondutor)
    {
        this.repositorioCondutor = repositorioCondutor;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
        {
            var condutorSelecionado = repositorioCondutor.SelecionarPorId(source.CondutorId);

            return [new SelectListItem(condutorSelecionado!.Nome, condutorSelecionado.Id.ToString())];
        }

        return repositorioCondutor
            .SelecionarTodos()
            .Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
    }
}