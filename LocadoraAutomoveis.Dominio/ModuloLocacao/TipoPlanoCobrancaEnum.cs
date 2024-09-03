using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.Dominio.ModuloLocacao;

public enum TipoPlanoCobrancaEnum
{
    [Display(Name = "Diário")] Diario,
    Controlado,
    Livre
}