using LocadoraAutomoveis.Dominio.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxaEmOrm;

public class RepositorioTaxaEmOrm : RepositorioBaseEmOrm<Taxa>, IRepositorioTaxa
{
	public RepositorioTaxaEmOrm(LocadoraDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<Taxa> ObterRegistros()
	{
		return dbContext.Taxas;
	}

    public List<Taxa> SelecionarMuitos(List<int> idsTaxasSelecionadas)
    {
        return dbContext.Taxas
            .Where(taxa => idsTaxasSelecionadas.Contains(taxa.Id))
            .ToList();
    }

    public List<Taxa> Filtrar(Func<Taxa, bool> predicate)
    {
        return ObterRegistros()
            .Where(predicate)
            .ToList();
    }
}