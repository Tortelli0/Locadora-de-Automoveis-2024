
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;

public class RepositorioGrupoAutomoveisEmOrm : RepositorioBaseEmOrm<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
{
    public RepositorioGrupoAutomoveisEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<GrupoAutomoveis> ObterRegistros()
    {
        return dbContext.GrupoAutomoveis;
    }

    public List<GrupoAutomoveis> Filtrar(Func<GrupoAutomoveis, bool> predicate)
    {
        return dbContext.GrupoAutomoveis
            .Where(predicate)
            .ToList();
    }
}