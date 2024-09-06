using Microsoft.AspNetCore.Identity;

namespace LocadoraAutomoveis.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<int>
{
    public Usuario()
    {
        EmailConfirmed = true;
    }
}