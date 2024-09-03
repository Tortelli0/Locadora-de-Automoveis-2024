using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.Dominio.ModuloLocacao;

public enum MarcadorCombustivelEnum
{
    Vazio,
    [Display(Name = "Um Quarto")] umQuarto,
    [Display(Name = "Meio Tanque")] MeioTanque,
    [Display(Name = "Três Quartos")] TresQuartos,
    Completo
}