using FluentResults;
using LocadoraAutomoveis.WebApp.Extensions;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers.Compartilhado;

public class WebControllerBase : Controller
{
    protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Erro",
            Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
        });

        return RedirectToAction("Index", "Home");
    }

    protected void ApresentarMensagemFalha(Result resultado)
    {
        ViewBag.Mensagem = new MensagemViewModel
        {
            Titulo = "Falha",
            Mensagem = resultado.Errors[0].Message
        };
    }

    protected void ApresentarMensagemSucesso(string mensagem)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Sucesso",
            Mensagem = mensagem
        });
    }
}
