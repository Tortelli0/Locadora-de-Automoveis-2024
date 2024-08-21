using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class GrupoAutomoveisController : Controller
{
    private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

    public GrupoAutomoveisController(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
    {
        this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
    }

    public ViewResult Listar()
    {
        var db = new LocadoraDbContext();
        var repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(db);

        var grupoautomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

        var listarGrupoAutomoveisVm = grupoautomoveis
            .Select(s => new ListarGrupoAutomoveisViewModel
            {
                Id = s.Id,
                Nome = s.Nome
            });

        return View(listarGrupoAutomoveisVm);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    //[HttpPost]
    //public ViewResult Inserir(InserirGrupoAutomoveisViewModel inserirGrupoAutomoveisVm)
    //{
    //    if (!ModelState.IsValid)
    //        return View(inserirGrupoAutomoveisVm);

    //    var db = new LocadoraDbContext();
    //    var repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(db);

    //    var grupoAutomoveis = new GrupoAutomoveis(inserirGrupoAutomoveisVm.Nome);

    //    repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

    //    HttpContext.Response.StatusCode = 201;

    //    var notificacaoVm = new NotificacaoViewModel
    //    {
    //        Mensagem = $"O registro com o ID [{sala.Id}] foi cadastrado com sucesso!",
    //        LinkRedirecionamento = "/sala/listar"
    //    };

    //    return View("mensagens", notificacaoVm);
    //}

    //public ViewResult Editar(int id)
    //{
    //    var db = new LocadoraDbContext();
    //    var repositorioSala = new RepositorioGrupoAutomoveisEmOrm(db);

    //    var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(id);

    //    var editarSalaVm = new EditarSalaViewModel
    //    {
    //        Id = id,
    //        Numero = sala.Numero,
    //        Capacidade = sala.Capacidade
    //    };

    //    return View(editarSalaVm);
    //}

    //[HttpPost]
    //public ViewResult Editar(EditarSalaViewModel editarSalaVm)
    //{
    //    if (!ModelState.IsValid)
    //        return View(editarSalaVm);

    //    var db = new ControleDeCinemaDbContext();
    //    var repositorioSala = new RepositorioSalaEmOrm(db);

    //    var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);
    //    var salaEditada = repositorioSala.SelecionarPorId(editarSalaVm.Id);

    //    salaEditada.Numero = editarSalaVm.Numero;
    //    salaEditada.Capacidade = editarSalaVm.Capacidade;

    //    repositorioSala.Editar(salaOriginal, salaEditada);

    //    var notificacaoVm = new NotificacaoViewModel
    //    {
    //        Mensagem = $"O registro com o ID [{salaEditada.Id}] foi editado com sucesso!",
    //        LinkRedirecionamento = "/sala/listar"
    //    };

    //    return View("mensagens", notificacaoVm);
    //}

    //public ViewResult Excluir(int id)
    //{
    //    var db = new ControleDeCinemaDbContext();
    //    var repositorioSala = new RepositorioSalaEmOrm(db);

    //    var sala = repositorioSala.SelecionarPorId(id);

    //    var excluirSalaVm = new ExcluirSalaViewModel()
    //    {
    //        Id = sala.Id,
    //        Numero = sala.Numero,
    //        Capacidade = sala.Capacidade,
    //        Sessoes = sala.Sessoes
    //            .Select(c => new ListarSessaoSalaViewModel() { DataHorario = c.Horario.ToString() })
    //    };


    //    return View(excluirSalaVm);
    //}

    //[HttpPost, ActionName("excluir")]
    //public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
    //{
    //    var db = new ControleDeCinemaDbContext();
    //    var repositorioSala = new RepositorioSalaEmOrm(db);

    //    var sala = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

    //    repositorioSala.Excluir(sala);

    //    var notificacaoVm = new NotificacaoViewModel
    //    {
    //        Mensagem = $"O registro com o ID [{sala.Id}] foi excluído com sucesso!",
    //        LinkRedirecionamento = "/sala/listar"
    //    };

    //    return View("mensagens", notificacaoVm);
    //}

    //public ViewResult Detalhes(int id)
    //{
    //    var db = new ControleDeCinemaDbContext();
    //    var repositorioSala = new RepositorioSalaEmOrm(db);

    //    var sala = repositorioSala.SelecionarPorId(id);

    //    var detalhesSalaVm = new DetalhesSalaViewModel()
    //    {
    //        Id = sala.Id,
    //        Numero = sala.Numero,
    //        Capacidade = sala.Capacidade,
    //        Sessoes = sala.Sessoes
    //            .Select(c => new ListarSessaoSalaViewModel() { DataHorario = c.Horario.ToString() })
    //    };

    //    return View(detalhesSalaVm);
    //}
}

