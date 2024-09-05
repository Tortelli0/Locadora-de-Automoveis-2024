using System.ComponentModel.DataAnnotations;

namespace LocadoraAutomoveis.Dominio.ModuloAutenticacao;

public enum TipoUsuarioEnum
{
    Empresa,
    [Display(Name = "Funcionário")]Funcionario
}