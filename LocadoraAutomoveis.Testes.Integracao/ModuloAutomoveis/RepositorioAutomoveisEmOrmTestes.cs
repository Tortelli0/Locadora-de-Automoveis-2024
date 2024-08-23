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

		BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorio.Inserir);
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

		var automovel = new Automovel("teste", "teste", "teste", TipoCombustivel.Diesel, 10, grupo.Id);

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
			.With(g => g.Id = 0)
			.Persist();
		
		var automovel = new Automovel("teste", "teste", "teste", TipoCombustivel.Alcool, 10, grupo.Id);

		repositorio.Editar(automovel);

		var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

		Assert.IsNotNull(automovelSelecionado);
		Assert.AreEqual(automovel, automovelSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_Automoveis()
	{
		//Arrange
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var automovel = Builder<Automovel>
			.CreateNew()
			.With(v => v.GrupoAutomoveis = grupo)
			.With(g => g.Id = 0)
			.Persist();

		//Act
		repositorio.Excluir(automovel);

		var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

		var automoveis = repositorio.SelecionarTodos();

		//Assert
		Assert.IsNull(automovelSelecionado);
		Assert.AreEqual(0, automoveis.Count);
	}
}
