using Microsoft.AspNetCore.Identity;

namespace LocadoraAutomoveis.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<int>
{
    public int? EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }

    public Usuario()
    {
        EmailConfirmed = true;
    }
}