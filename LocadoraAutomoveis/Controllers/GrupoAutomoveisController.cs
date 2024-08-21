using AutoMapper;
using LocadoraAutomoveis.Aplicacao.Serviços;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class GrupoAutomoveisController : WebControllerBase
{
    private readonly ServicoGrupoAutomoveis servico;
    private readonly IMapper mapeador;

    public GrupoAutomoveisController(ServicoGrupoAutomoveis servico, IMapper mapeador)
    {
	    this.servico = servico;
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

	    var grupos = resultado.Value;

	    var listarGruposVm = mapeador.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(grupos);

        return View(listarGruposVm);
    }

    public IActionResult Inserir()
    {
	    return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirGrupoAutomoveisViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(inserirVm);

        var grupo = mapeador.Map<GrupoAutomoveis>(inserirVm);

        var resultado = servico.Inserir(grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
	}

    public IActionResult Editar(int id)
    {
	    var resultado = servico.SelecionarPorId(id);

	    if (resultado.IsFailed)
	    {
		    ApresentarMensagemFalha(resultado.ToResult());

		    return RedirectToAction(nameof(Listar));
	    }

	    var grupo = resultado.Value;

	    var editarVm = mapeador.Map<EditarGrupoAutomoveisViewModel>(grupo);

	    return View(editarVm);
	}

    [HttpPost]
    public ViewResult Editar(EditarGrupoAutomoveisViewModel editarVM)
    {
	    if (!ModelState.IsValid)
		    return View(editarVM);

	    var grupo = mapeador.Map<GrupoAutomoveis>(editarVM);

	    var resultado = servico.Editar(grupo);

	    if (resultado.IsFailed)
	    {
		    ApresentarMensagemFalha(resultado.ToResult());

		    return RedirectToAction(nameof(Listar));
	    }

	    ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");

	    return RedirectToAction(nameof(Listar));
	}

    public IActionResult Excluir(int id)
    {
	    var resultado = servico.SelecionarPorId(id);

	    if (resultado.IsFailed)
	    {
		    ApresentarMensagemFalha(resultado.ToResult());

		    return RedirectToAction(nameof(Listar));
	    }

	    var grupo = resultado.Value;

	    var detalhesVm = mapeador.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

	    return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel detalhesVm)
    {
	    var resultado = servico.Excluir(detalhesVm.Id);

	    if (resultado.IsFailed)
	    {
		    ApresentarMensagemFalha(resultado.ToResult());

		    return RedirectToAction(nameof(Listar));
	    }

	    ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

	    return RedirectToAction(nameof(Listar));
    }

	public ViewResult Detalhes(int id)
	{
		var resultado = servico.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var grupo = resultado.Value;

		var detalhesVm = mapeador.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

		return View(detalhesVm);
	}
}

