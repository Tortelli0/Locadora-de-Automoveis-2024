using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.Serviços;
using LocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class PlanoCobrancaController : WebControllerBase
{
	private readonly ServicoPlanoCobranca servico;
	private readonly ServicoGrupoAutomoveis servicoGrupos;
	private readonly IMapper mapeador;

	public PlanoCobrancaController(ServicoPlanoCobranca servico, ServicoGrupoAutomoveis servicoGrupos, IMapper mapeador)
	{
		this.servico = servico;
		this.servicoGrupos = servicoGrupos;
		this.mapeador = mapeador;
	}

	public IActionResult Listar()
	{
		var resultado = servico.SelecionarTodos();

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());
			
			return RedirectToAction("Index", "Home");
		}

		var planosCobranca = resultado.Value;

		var listarPlanosVm = mapeador.Map<IEnumerable<ListarP>>();

		return View();
	}
}
