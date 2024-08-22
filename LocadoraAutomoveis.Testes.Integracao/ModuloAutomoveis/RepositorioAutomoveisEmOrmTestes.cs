using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomoveisEmOrmTestes
{
	private LocadoraDbContext dbContext;
	private RepositorioAutomoveisEmOrm repositorio;
	private RepositorioGrupoAutomoveisEmOrm repositorioGrupo;

	[TestInitialize]
	public void Inicializar()
	{
		dbContext = new LocadoraDbContext();
		
		dbContext.Automoveis.RemoveRange(dbContext.Automoveis);

		repositorio = new RepositorioAutomoveisEmOrm(dbContext);
		repositorioGrupo = new RepositorioGrupoAutomoveisEmOrm(dbContext);

		BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorioGrupo.Inserir);
	}

	[TestMethod]
	public void Deve_Inserir_Automoveis()
	{
		//Arrange
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var automovel = new Automoveis("teste", "teste", "teste", "teste", 10, grupo);

		//Act
		repositorio.Inserir(automovel);

		var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

		//Assert
		Assert.IsNotNull(automovelSelecionado);
		Assert.AreEqual(automovel, automovelSelecionado);
	}

	[TestMethod]
	public void Deve_Editar_Automoveis()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(a => a.Id = 0)
			.Persist();
		
		var automovelSelecionado = new Automoveis("teste", "teste", "teste", "teste", 10, grupo);

		repositorio.Editar(automovelSelecionado);

		var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

		var automoveis = repositorio.SelecionarTodos();

		Assert.IsNull(automovelSelecionado);
		Assert.AreEqual();

	}

}
