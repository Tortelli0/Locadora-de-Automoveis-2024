using System.Text.Json;
using LocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LocadoraAutomoveis.WebApp.Extensions;

public static class TempDataExtensions
{
    public static void SerializarMensagemViewModel(
        this ITempDataDictionary dicionario, MensagemViewModel mensagemVm)
    {
        dicionario["Mensagem"] = JsonSerializer.Serialize(mensagemVm);
    }

    public static MensagemViewModel? DesserializarMensagemViewModel(this ITempDataDictionary dicionario)
    {
        var mensagemStr = dicionario["Mensagem"]?.ToString();

        if (mensagemStr is null) return null;

        return JsonSerializer.Deserialize<MensagemViewModel>(mensagemStr);
    }
}
