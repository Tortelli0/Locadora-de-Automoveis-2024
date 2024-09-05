using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
{
    PlanoCobranca? FiltarPlano(Func<PlanoCobranca, bool> predicate);
}