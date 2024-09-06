using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraAutomoveis.WebApp.Mapping;

public class AutomoveisValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly ServicoAutomovel servicoAutomovel;

    public AutomoveisValueResolver(ServicoAutomovel servicoAutomovel)
    {
        this.servicoAutomovel = servicoAutomovel;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
        {
            var automovelSelecionado = servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

            return [new SelectListItem(automovelSelecionado!.Modelo, automovelSelecionado.Id.ToString())];
        }

        return servicoAutomovel
            .SelecionarTodos(source.EmpresaId)
            .Value
            .Select(a => new SelectListItem(a.Modelo, a.Id.ToString()));
    }
}