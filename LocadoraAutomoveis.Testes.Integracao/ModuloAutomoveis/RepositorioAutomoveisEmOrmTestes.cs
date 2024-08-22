using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomoveisEmOrmTestes
{
	private LocadoraDbContext dbContext;
	private RepositorioAutomoveisEmOrmTestes repositorio;

	[TestInitialize]
	public void Inicializar()
	{
		dbContext = new LocadoraDbContext();
		
		dbContext.Automoveis.RemoveRange(dbContext.Automoveis);

		repositorio = new RepositorioAutomoveisEmOrm(dbContext);


	}

}
