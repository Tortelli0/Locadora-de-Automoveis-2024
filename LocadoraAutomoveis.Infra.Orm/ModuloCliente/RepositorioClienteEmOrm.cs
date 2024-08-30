using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente;

public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
{
	public RepositorioClienteEmOrm(LocadoraDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<Cliente> ObterRegistros()
	{
		return dbContext.Clientes;
	}
}
