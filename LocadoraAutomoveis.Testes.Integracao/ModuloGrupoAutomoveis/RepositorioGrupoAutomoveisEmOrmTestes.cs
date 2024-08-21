using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Testes.Integracao.ModuloGrupoAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioGrupoAutomoveisEmOrmTestes
{
    private LocadoraDbContext dbContext;
    private RepositorioGrupoAutomoveisEmOrm repositorio;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);

        repositorio = new RepositorioGrupoAutomoveisEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorio.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        grupo.Nome = "Teste de Edição";
        repositorio.Editar(grupo);

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_GrupoAutomoveis()
    {
        var grupo = Builder<GrupoAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        repositorio.Excluir(grupo);

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        var grupos = repositorio.SelecionarTodos();

        Assert.IsNull(grupoSelecionado);
        Assert.AreEqual(0, grupos.Count);
    }
}
