using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloCombustivel;
using LocadoraAutomoveis.Dominio.ModuloCombustivel;
using LocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class CombustivelController : WebControllerBase
{
    private readonly ServicoCombustivel servicoCombustivel;
    private readonly IMapper mapeador;

    public CombustivelController(ServicoCombustivel servicoCombustivel, IMapper mapeador)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapeador = mapeador;
    }

    public IActionResult Configurar()
    {
        var resultado = servicoCombustivel.ObterConfiguracao();

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        var configuracaoCombustivel = resultado.Value;

        var formularioVm = mapeador.Map<FormularioConfiguracaoCombusitvelViewModel>(configuracaoCombustivel);

        return View(formularioVm);
    }

    [HttpPost]
    public IActionResult Configurar(FormularioConfiguracaoCombusitvelViewModel formularioVm)
    {
        var config = mapeador.Map<ConfiguracaoCombustivel>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}