using AutoMapper;
using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.Serviços;
using LocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class AutomovelController : WebControllerBase
{
	private readonly ServicoAutomovel servico;
	private readonly ServicoGrupoAutomoveis servicoGrupos;
	private readonly IMapper mapeador;

	public AutomovelController(ServicoAutomovel servico, ServicoGrupoAutomoveis servicoGrupos, IMapper mapeador)
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

		var automoveis = resultado.Value;

		var listarVeiculosVm = mapeador.Map<IEnumerable<ListarAutomovelViewModel>>(automoveis);

		return View(listarVeiculosVm);
	}


}
