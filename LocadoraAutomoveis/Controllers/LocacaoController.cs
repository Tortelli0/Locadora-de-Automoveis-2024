using System.Text.Json;
using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.Aplicacao.ModuloTaxa;
using LocadoraAutomoveis.Dominio.ModuloLocacao;
using LocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class LocacaoController : WebControllerBase
{
    private readonly ServicoLocacao servicoLocacao;
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoCondutor servicoCondutor;
    private readonly ServicoTaxa servicoTaxa;
    private readonly IMapper mapeador;

    public LocacaoController(ServicoAutenticacao servicoAuth, ServicoLocacao servicoLocacao, ServicoAutomovel servicoAutomovel, ServicoCondutor servicoCondutor, ServicoTaxa servicoTaxa, IMapper mapeador) 
        : base(servicoAuth)
    {
        this.servicoLocacao = servicoLocacao;
        this.servicoAutomovel = servicoAutomovel;
        this.servicoCondutor = servicoCondutor;
        this.servicoTaxa = servicoTaxa;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = servicoLocacao.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var locacoes = resultado.Value;

        var listarLocacoesVm = mapeador.Map<IEnumerable<ListarLocacaoViewModel>>(locacoes);

        return View(listarLocacoesVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirLocacaoViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserirVm));

        var locacao = mapeador.Map<Locacao>(inserirVm);

        var confirmarVm = mapeador.Map<ConfirmarAberturaLocacaoViewModel>(locacao);

        TempData["LocacaoParaInsercao"] = JsonSerializer.Serialize(confirmarVm);

        return RedirectToAction("ConfirmarAbertura");
    }

    public IActionResult ConfirmarAbertura()
    {
        if (TempData["LocacaoParaInsercao"] is null)
            return RedirectToAction(nameof(Listar));

        var locacaoDataJson = TempData["LocacaoParaInsercao"]!.ToString();

        var confirmarVm = JsonSerializer.Deserialize<ConfirmarAberturaLocacaoViewModel>(locacaoDataJson);

        return View(confirmarVm);
    }

    [HttpPost]
    public IActionResult ConfirmarAbertura(ConfirmarAberturaLocacaoViewModel confirmarVm)
    {
        var locacao = mapeador.Map<Locacao>(confirmarVm);

        var resultado = servicoLocacao.Inserir(locacao);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"A locação ID [{locacao.Id}] foi aberta com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult RealizarDevolucao(int id)
    {
        var resultado = servicoLocacao.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var locacao = resultado.Value;

        var devolucaoVm = mapeador.Map<RealizarDevolucaoViewModel>(locacao);

        return View(devolucaoVm);
    }

    [HttpPost]
    public IActionResult RealizarDevolucao(RealizarDevolucaoViewModel devolucaoVm)
    {
        var locacao = mapeador.Map<Locacao>(devolucaoVm);

        var confirmarVm = mapeador.Map<ConfirmarDevolucaoLocacaoViewModel>(locacao);

        TempData["LocacaoParaDevolucao"] = JsonSerializer.Serialize(confirmarVm);

        return RedirectToAction("ConfirmarDevolucao");
    }

    public IActionResult ConfirmarDevolucao()
    {
        if (TempData["LocacaoParaDevolucao"] is null)
            return RedirectToAction(nameof(Inserir));

        var locacaoDataJson = TempData["LocacaoParaDevolucao"]!.ToString();

        var confirmarVm = JsonSerializer.Deserialize<ConfirmarDevolucaoLocacaoViewModel>(locacaoDataJson);

        return View(confirmarVm);
    }

    [HttpPost]
    public IActionResult ConfirmarDevolucao(ConfirmarDevolucaoLocacaoViewModel confirmarVm)
    {
        var locacaoOriginal = servicoLocacao.SelecionarPorId(confirmarVm.Id).Value;

        var locacaoAtualizada = mapeador.Map<ConfirmarDevolucaoLocacaoViewModel, Locacao>(confirmarVm, locacaoOriginal);

        var resultado = servicoLocacao.RealizarDevolucao(locacaoAtualizada);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"A locação ID [{locacaoAtualizada.Id}] foi concluída com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    private InserirLocacaoViewModel CarregarDadosFormulario(InserirLocacaoViewModel? formularioVm = null)
    {
        var condutores = servicoCondutor.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;
        var automoveis = servicoAutomovel.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;
        var taxas = servicoTaxa.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;

        if (formularioVm is null)
            formularioVm = new InserirLocacaoViewModel();

        formularioVm.Condutores =
            condutores.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

        formularioVm.Automoveis =
            automoveis.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

        formularioVm.Taxas =
            taxas.Select(c => new SelectListItem(c.ToString(), c.Id.ToString()));

        return formularioVm;
    }
}