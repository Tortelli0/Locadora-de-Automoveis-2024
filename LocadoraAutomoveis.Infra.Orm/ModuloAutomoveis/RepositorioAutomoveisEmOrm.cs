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

	public override Automovel? SelecionarPorId(int id)
	{
		return ObterRegistros()
			.Include(v => v.GrupoAutomoveis)
			.FirstOrDefault(v => v.Id == id);
	}

	public override List<Automovel> SelecionarTodos()
	{
		return ObterRegistros()
			.Include(v => v.GrupoAutomoveis)
			.ToList();
	}
}
