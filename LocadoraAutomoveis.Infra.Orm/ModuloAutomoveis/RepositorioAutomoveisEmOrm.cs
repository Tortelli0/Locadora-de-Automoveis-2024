using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
public class RepositorioAutomoveisEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomoveis
{
	public RepositorioAutomoveisEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }

	protected override DbSet<Automovel> ObterRegistros()
	{
		return dbContext.Automoveis;
	}

	//public List<Automoveis> Filtrar(Func<Automoveis, bool> predicate)
	//{
	//    return dbContext.Automoveis
	//        .Where(predicate)
	//        .ToList();
	//}
}
